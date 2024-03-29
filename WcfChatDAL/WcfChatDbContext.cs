﻿using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;

namespace WcfChatDAL
{
    public class WcfChatDbContext : DbContext
    {
        private static readonly DatabaseLogger _dbLogger = new DatabaseLogger("logs.txt", true);

        public DbSet<Message> Messages { get; set; }

        public WcfChatDbContext() : base("name=WcfChatConnection")
        {
            _dbLogger.StartLogging();
            DbInterception.Add(_dbLogger);
        }

        protected override void Dispose(bool disposing)
        {
            DbInterception.Remove(_dbLogger);
            _dbLogger.StartLogging();
            base.Dispose(disposing);
        }
    }
}
