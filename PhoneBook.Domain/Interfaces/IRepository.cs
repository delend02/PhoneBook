namespace PhoneBook.Domain.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();
        T Find(Func<T, bool> predicate);
        T GetByID(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
