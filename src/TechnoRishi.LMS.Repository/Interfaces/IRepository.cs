namespace TechnoRishi.LMS.Repository.Interfaces;

public interface IRepository<T> 
{
    Task<T> Get(int id, CancellationToken token);

    Task<List<T>> GetAll< T2>(T2 filter, CancellationToken cancellationToken)  where T2 : class;

    Task<T> Add(T entity, CancellationToken token);

    Task<bool> Update(object id, T entity, CancellationToken token);

    Task<bool> Delete(int id, CancellationToken token) ;
}