namespace exorecapapi.Repositories
{
    public interface IRepository<T, U>
         where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
       
        U Add(T obj);

    }
}