using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using WcfChat;

namespace WcfChatHost
{
    public class Host
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(WcfChatService)))
            {
                ConfigurateHost(host);

                host.Open();

                Console.WriteLine("Host is running");
                Console.WriteLine("Press any button to terminate it");
                Console.ReadLine();

                host.Close();
            }
        }

        private static void ConfigurateHost(ServiceHost host)
        {
            var binding = new NetTcpBinding();
            binding.PortSharingEnabled = true;
            binding.Security.Mode = SecurityMode.None;
            host.AddServiceEndpoint(typeof(IWcfChatSevice), binding, "net.tcp://localhost:8080/WcfChatService");

            host.Description.Behaviors.Remove<ServiceDebugBehavior>();
            host.Description.Behaviors.Remove<ServiceMetadataBehavior>();

            var behaviour = new ServiceMetadataBehavior();
            behaviour.HttpGetEnabled = false;
            behaviour.HttpsGetEnabled = false;
            host.Description.Behaviors.Add(behaviour);
        }
    }
}
