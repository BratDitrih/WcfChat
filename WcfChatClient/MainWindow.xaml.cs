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
                _client = new WcfChatSeviceClient(new System.ServiceModel.InstanceContext(this));
                string userName = null;
                Dispatcher.Invoke(() => userName = txtUserName.Text);
                var result = await Task.Run(() => _client.Connect(userName));
                _id = result;
                _isConnect = true;
                txtUserName.IsEnabled = false;
                btnConnect.Content = "Отключиться";
            }
            else
            {
                await Task.Run(() => _client.Disconnect(_id));
                _isConnect = false;
                txtUserName.IsEnabled = true;
                btnConnect.Content = "Подключиться";
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
            throw new NotImplementedException();
        }

        public void EndGetMessage(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_client == null) return;
            IAsyncResult result = _client.BeginDisconnect(_id, _ => _client = null, null);
        }
    }
}
