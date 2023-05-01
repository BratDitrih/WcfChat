﻿using System;
using System.ServiceModel;

namespace WcfChatService
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public OperationContext OperationContext { get; set; }
    }
}
