﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfChatClient.WcfChatServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WcfChatServiceReference.IWcfChatSevice", CallbackContract=typeof(WcfChatClient.WcfChatServiceReference.IWcfChatSeviceCallback))]
    public interface IWcfChatSevice {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfChatSevice/Connect", ReplyAction="http://tempuri.org/IWcfChatSevice/ConnectResponse")]
        string Connect(string userName);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IWcfChatSevice/Connect", ReplyAction="http://tempuri.org/IWcfChatSevice/ConnectResponse")]
        System.IAsyncResult BeginConnect(string userName, System.AsyncCallback callback, object asyncState);
        
        string EndConnect(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfChatSevice/Disconnect", ReplyAction="http://tempuri.org/IWcfChatSevice/DisconnectResponse")]
        void Disconnect(string id);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IWcfChatSevice/Disconnect", ReplyAction="http://tempuri.org/IWcfChatSevice/DisconnectResponse")]
        System.IAsyncResult BeginDisconnect(string id, System.AsyncCallback callback, object asyncState);
        
        void EndDisconnect(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWcfChatSevice/SendMessage")]
        void SendMessage(string message, string senderUserId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, AsyncPattern=true, Action="http://tempuri.org/IWcfChatSevice/SendMessage")]
        System.IAsyncResult BeginSendMessage(string message, string senderUserId, System.AsyncCallback callback, object asyncState);
        
        void EndSendMessage(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfChatSevice/GetAllMessages", ReplyAction="http://tempuri.org/IWcfChatSevice/GetAllMessagesResponse")]
        string[] GetAllMessages();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IWcfChatSevice/GetAllMessages", ReplyAction="http://tempuri.org/IWcfChatSevice/GetAllMessagesResponse")]
        System.IAsyncResult BeginGetAllMessages(System.AsyncCallback callback, object asyncState);
        
        string[] EndGetAllMessages(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWcfChatSeviceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWcfChatSevice/GetMessage")]
        void GetMessage(string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, AsyncPattern=true, Action="http://tempuri.org/IWcfChatSevice/GetMessage")]
        System.IAsyncResult BeginGetMessage(string message, System.AsyncCallback callback, object asyncState);
        
        void EndGetMessage(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWcfChatSeviceChannel : WcfChatClient.WcfChatServiceReference.IWcfChatSevice, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ConnectCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public ConnectCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetAllMessagesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetAllMessagesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string[] Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WcfChatSeviceClient : System.ServiceModel.DuplexClientBase<WcfChatClient.WcfChatServiceReference.IWcfChatSevice>, WcfChatClient.WcfChatServiceReference.IWcfChatSevice {
        
        private BeginOperationDelegate onBeginConnectDelegate;
        
        private EndOperationDelegate onEndConnectDelegate;
        
        private System.Threading.SendOrPostCallback onConnectCompletedDelegate;
        
        private BeginOperationDelegate onBeginDisconnectDelegate;
        
        private EndOperationDelegate onEndDisconnectDelegate;
        
        private System.Threading.SendOrPostCallback onDisconnectCompletedDelegate;
        
        private BeginOperationDelegate onBeginSendMessageDelegate;
        
        private EndOperationDelegate onEndSendMessageDelegate;
        
        private System.Threading.SendOrPostCallback onSendMessageCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetAllMessagesDelegate;
        
        private EndOperationDelegate onEndGetAllMessagesDelegate;
        
        private System.Threading.SendOrPostCallback onGetAllMessagesCompletedDelegate;
        
        public WcfChatSeviceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public WcfChatSeviceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public WcfChatSeviceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public WcfChatSeviceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public WcfChatSeviceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public event System.EventHandler<ConnectCompletedEventArgs> ConnectCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> DisconnectCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> SendMessageCompleted;
        
        public event System.EventHandler<GetAllMessagesCompletedEventArgs> GetAllMessagesCompleted;
        
        public string Connect(string userName) {
            return base.Channel.Connect(userName);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginConnect(string userName, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginConnect(userName, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndConnect(System.IAsyncResult result) {
            return base.Channel.EndConnect(result);
        }
        
        private System.IAsyncResult OnBeginConnect(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string userName = ((string)(inValues[0]));
            return this.BeginConnect(userName, callback, asyncState);
        }
        
        private object[] OnEndConnect(System.IAsyncResult result) {
            string retVal = this.EndConnect(result);
            return new object[] {
                    retVal};
        }
        
        private void OnConnectCompleted(object state) {
            if ((this.ConnectCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.ConnectCompleted(this, new ConnectCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void ConnectAsync(string userName) {
            this.ConnectAsync(userName, null);
        }
        
        public void ConnectAsync(string userName, object userState) {
            if ((this.onBeginConnectDelegate == null)) {
                this.onBeginConnectDelegate = new BeginOperationDelegate(this.OnBeginConnect);
            }
            if ((this.onEndConnectDelegate == null)) {
                this.onEndConnectDelegate = new EndOperationDelegate(this.OnEndConnect);
            }
            if ((this.onConnectCompletedDelegate == null)) {
                this.onConnectCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnConnectCompleted);
            }
            base.InvokeAsync(this.onBeginConnectDelegate, new object[] {
                        userName}, this.onEndConnectDelegate, this.onConnectCompletedDelegate, userState);
        }
        
        public void Disconnect(string id) {
            base.Channel.Disconnect(id);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginDisconnect(string id, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginDisconnect(id, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndDisconnect(System.IAsyncResult result) {
            base.Channel.EndDisconnect(result);
        }
        
        private System.IAsyncResult OnBeginDisconnect(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string id = ((string)(inValues[0]));
            return this.BeginDisconnect(id, callback, asyncState);
        }
        
        private object[] OnEndDisconnect(System.IAsyncResult result) {
            this.EndDisconnect(result);
            return null;
        }
        
        private void OnDisconnectCompleted(object state) {
            if ((this.DisconnectCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.DisconnectCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void DisconnectAsync(string id) {
            this.DisconnectAsync(id, null);
        }
        
        public void DisconnectAsync(string id, object userState) {
            if ((this.onBeginDisconnectDelegate == null)) {
                this.onBeginDisconnectDelegate = new BeginOperationDelegate(this.OnBeginDisconnect);
            }
            if ((this.onEndDisconnectDelegate == null)) {
                this.onEndDisconnectDelegate = new EndOperationDelegate(this.OnEndDisconnect);
            }
            if ((this.onDisconnectCompletedDelegate == null)) {
                this.onDisconnectCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDisconnectCompleted);
            }
            base.InvokeAsync(this.onBeginDisconnectDelegate, new object[] {
                        id}, this.onEndDisconnectDelegate, this.onDisconnectCompletedDelegate, userState);
        }
        
        public void SendMessage(string message, string senderUserId) {
            base.Channel.SendMessage(message, senderUserId);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginSendMessage(string message, string senderUserId, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSendMessage(message, senderUserId, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndSendMessage(System.IAsyncResult result) {
            base.Channel.EndSendMessage(result);
        }
        
        private System.IAsyncResult OnBeginSendMessage(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string message = ((string)(inValues[0]));
            string senderUserId = ((string)(inValues[1]));
            return this.BeginSendMessage(message, senderUserId, callback, asyncState);
        }
        
        private object[] OnEndSendMessage(System.IAsyncResult result) {
            this.EndSendMessage(result);
            return null;
        }
        
        private void OnSendMessageCompleted(object state) {
            if ((this.SendMessageCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SendMessageCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SendMessageAsync(string message, string senderUserId) {
            this.SendMessageAsync(message, senderUserId, null);
        }
        
        public void SendMessageAsync(string message, string senderUserId, object userState) {
            if ((this.onBeginSendMessageDelegate == null)) {
                this.onBeginSendMessageDelegate = new BeginOperationDelegate(this.OnBeginSendMessage);
            }
            if ((this.onEndSendMessageDelegate == null)) {
                this.onEndSendMessageDelegate = new EndOperationDelegate(this.OnEndSendMessage);
            }
            if ((this.onSendMessageCompletedDelegate == null)) {
                this.onSendMessageCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSendMessageCompleted);
            }
            base.InvokeAsync(this.onBeginSendMessageDelegate, new object[] {
                        message,
                        senderUserId}, this.onEndSendMessageDelegate, this.onSendMessageCompletedDelegate, userState);
        }
        
        public string[] GetAllMessages() {
            return base.Channel.GetAllMessages();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetAllMessages(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetAllMessages(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string[] EndGetAllMessages(System.IAsyncResult result) {
            return base.Channel.EndGetAllMessages(result);
        }
        
        private System.IAsyncResult OnBeginGetAllMessages(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginGetAllMessages(callback, asyncState);
        }
        
        private object[] OnEndGetAllMessages(System.IAsyncResult result) {
            string[] retVal = this.EndGetAllMessages(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetAllMessagesCompleted(object state) {
            if ((this.GetAllMessagesCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetAllMessagesCompleted(this, new GetAllMessagesCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetAllMessagesAsync() {
            this.GetAllMessagesAsync(null);
        }
        
        public void GetAllMessagesAsync(object userState) {
            if ((this.onBeginGetAllMessagesDelegate == null)) {
                this.onBeginGetAllMessagesDelegate = new BeginOperationDelegate(this.OnBeginGetAllMessages);
            }
            if ((this.onEndGetAllMessagesDelegate == null)) {
                this.onEndGetAllMessagesDelegate = new EndOperationDelegate(this.OnEndGetAllMessages);
            }
            if ((this.onGetAllMessagesCompletedDelegate == null)) {
                this.onGetAllMessagesCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetAllMessagesCompleted);
            }
            base.InvokeAsync(this.onBeginGetAllMessagesDelegate, null, this.onEndGetAllMessagesDelegate, this.onGetAllMessagesCompletedDelegate, userState);
        }
    }
}
