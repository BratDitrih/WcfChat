using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfChatDAL
{
    public class MessageRepository : IRepository<Message>
    {
        private readonly WcfChatDbContext _dbContext;
        private readonly DbSet<Message> _table;

        public MessageRepository()
        {
            _dbContext = new WcfChatDbContext();
            _table = _dbContext.Set<Message>();
        }

        public void Add(Message entity)
        {
            _table.Add(entity);
            Save();
        }

        public void AddRange(IList<Message> entities)
        {
            _table.AddRange(entities);
            Save();
        }

        public Message GetOne(int id)
        {
            return _table.Find(id);
        }
        
        public IList<Message> GetAll()
        {
            return _table.ToList();
        }

        public void Update(Message entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
           _dbContext.Entry(new Message { Id = id}).State = EntityState.Deleted;
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
