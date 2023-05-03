using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WcfChatClient.WcfChatServiceReference;

namespace WcfChatClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IWcfChatSeviceCallback
    {
        private bool _isConnect = false;
        private WcfChatSeviceClient _client = null;
        private string _id;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            if (_isConnect == false)
            {
                txtUserName.IsEnabled = false;
                btnConnect.IsEnabled = false;
                Mouse.OverrideCursor = Cursors.Wait;

                _client = new WcfChatSeviceClient(new System.ServiceModel.InstanceContext(this), "NetTcpBinding_IWcfChatSevice");
                var messages = _client.GetAllMessages();
                foreach (var message in messages)
                {
                    listMessages.Items.Add(message);
                }
                string userName = null;
                Dispatcher.Invoke(() => userName = txtUserName.Text);
                var result = await Task.Run(() => _client.Connect(userName));
                _id = result;

                _isConnect = true;
                btnConnect.Content = "Отключиться";
                btnConnect.IsEnabled = true;
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            else
            {
                btnConnect.IsEnabled = false;
                Mouse.OverrideCursor = Cursors.Wait;

                await Task.Run(() => _client.Disconnect(_id));
                _client = null;

                _isConnect = false;
                btnConnect.Content = "Подключиться";
                btnConnect.IsEnabled = true;
                txtUserName.IsEnabled = true;
                Mouse.OverrideCursor = Cursors.Arrow;
                txtUserName.Style = FindResource("GrayTextStyle") as Style;
            }
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (_client == null) return;
            if (e.Key == Key.Enter)
            {
                _client.SendMessage(txtMessage.Text, _id);
                txtMessage.Text = string.Empty;
            }
        }

        private void txtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Style = null;
        }

        private void txtMessage_LostFocus(object sender, RoutedEventArgs e)
        {
            txtMessage.ClearValue(TextBox.TextProperty);
            txtMessage.Style = FindResource("GrayTextStyle") as Style;
        }

        public void GetMessage(string message)
        {
            Dispatcher.Invoke(() =>
            {
                listMessages.Items.Add(message);
                listMessages.ScrollToBottom();
            });
        }

        public IAsyncResult BeginGetMessage(string message, AsyncCallback callback, object asyncState)
        {
            Action<string> getMessageFunc = GetMessage;
            return getMessageFunc.BeginInvoke(message, callback, asyncState);
        }

        public void EndGetMessage(IAsyncResult result)
        {
            var getMessageFunc = ((Action<string>)result.AsyncState);
            getMessageFunc.EndInvoke(result);
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_client == null) return;
            if (_isConnect)
            {
                await Dispatcher.BeginInvoke(new Action(async () =>
                {
                    await Task.Run(() => _client.Disconnect(_id));
                    _client = null;
                    _isConnect = false;
                }));
            }
        }
    }
}
