using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryWithDapperAnd.NetCore.Interfaces.Generic
{
    public interface IRepositoryBase<TEntity> : IDataBaseOperation<TEntity> where TEntity : class
    {
        Task<TEntity> GetWithPersonalFilterAsync(string campo, object valor);

        Task<IEnumerable<TEntity>> GetListWithPersonalFilterAsync(string campo, object valor);
 
    }
}
