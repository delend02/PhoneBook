namespace PhoneBook.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetAll();
        T Find(Func<T, bool> predicate);
        IEnumerable<T> FindAll(Func<T, bool> predicate);
        T GetByID(ulong id);
        IEnumerable<T> GetByID(List<ulong> id);
        T Get(T entity);
        void Create(T item);
        void Update(T item);
        void Delete(ulong id);
        void DeleteRange(IEnumerable<T> entity);
        void Save();
    }
}
