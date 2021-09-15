using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryWithDapperAnd.NetCore.Interfaces.Generic
{
    public interface IDataBaseOperation<TEntidade> where TEntidade : class
    {
        Task<int> RegisterAsync(TEntidade entidade);       
        Task<int> UpdateAsync(TEntidade entidade);       
        Task<int> DeleteAsync(TEntidade entidade);        
        Task<TEntidade> GetAsync(int Id);       
        Task<IEnumerable<TEntidade>> GetAllAsync();    
    }
}
