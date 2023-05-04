using System;
using System.Collections.Generic;

namespace WcfChatDAL
{
    public interface IRepository<T> : IDisposable where T : Message
    {
        void Add(T entity);
        void AddRange(IList<T> entities);
        T GetOne(int id);
        IList<T> GetAll();
        void Update(T entity);
        void Delete(int id);
        void Save();
    }
}
