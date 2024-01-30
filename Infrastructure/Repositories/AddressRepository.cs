using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories
{
    public class AddressRepository : BaseRepository<AddressesEntity>
    {
        public AddressRepository(DatabaseContext context) : base(context)
        {
        }
    }

}
