using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WcfChatClient.WcfChatServiceReference;
using System.ServiceModel;

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
                
                try
                {
                    _client = new WcfChatSeviceClient(new InstanceContext(this), "NetTcpBinding_IWcfChatSevice");
                    var messages = _client.GetAllMessages();
                    foreach (var message in messages)
                    {
                        listMessages.Items.Add(message);
                    }
                }
                catch (Exception ex)
                {
                    if (MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error) == MessageBoxResult.OK)
                    {
                        Close();
                    }
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

                try
                {
                    await Task.Run(() => _client.Disconnect(_id));
                }
                catch (Exception ex)
                {
                    if (MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error) == MessageBoxResult.OK)
                    {
                        Close();
                    }
                }
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
                try
                {
                    _client.SendMessage(txtMessage.Text, _id);
                    txtMessage.Text = string.Empty;
                }
                 catch (Exception ex)
                {
                    if (MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error) == MessageBoxResult.OK)
                    {
                        Close();
                    }
                }
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_client == null) return;
            if (_isConnect)
            {
                Dispatcher.Invoke(new Action(async () =>
                {
                    await Task.Run(() => _client.Disconnect(_id));
                    _client = null;
                    _isConnect = false;
                }));
            }
        }
    }
}
