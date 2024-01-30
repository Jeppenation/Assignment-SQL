using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories
{
    public class UserAuthenticationRepository : BaseRepository<UserAuthenticationsEntity>
    {
        public UserAuthenticationRepository(DatabaseContext context) : base(context)
        {
        }
    }

}
