using RepositoryWithDapperAnd.NetCore.Interfaces.Repository;
using RepositoryWithDapperAnd.NetCore.Models;

namespace RepositoryWithDapperAnd.NetCore.Repository
{
    public class AddressRepository: RepositoryBase<Address>, IAddressRepository
    {
    }
}
