using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories
{
    public class UserProfileRepository : BaseRepository<UserProfilesEntity>
    {
        public UserProfileRepository(DatabaseContext context) : base(context)
        {
        }
    }

}
