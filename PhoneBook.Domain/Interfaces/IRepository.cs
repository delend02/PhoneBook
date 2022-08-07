using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();
        T Find(Func<T, bool> predicate);
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
