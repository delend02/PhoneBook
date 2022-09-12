namespace PhoneBook.Domain.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();
        T Find(Func<T, bool> predicate);
        IEnumerable<T> FindAll(Func<T, bool> predicate);
        T GetByID(ulong id);
        void Create(T item);
        void Update(T item);
        void Delete(ulong id);
        void Save();
    }
}
