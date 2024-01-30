using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories
{
    public class UserAddressRepository : BaseRepository<UserAddressesEntity>
    {
        public UserAddressRepository(DatabaseContext context) : base(context)
        {
        }
    }

}
