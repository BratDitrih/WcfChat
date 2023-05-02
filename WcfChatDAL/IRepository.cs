using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
