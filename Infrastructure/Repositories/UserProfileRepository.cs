using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class UserProfileRepository(DatabaseContext context) : BaseRepository<UserProfilesEntity>(context)
{
    private readonly DatabaseContext _context = context;

    public override UserProfilesEntity GetById(Expression<Func<UserProfilesEntity, bool>> predicate)
    {
        return _context.UserProfiles.Include(up => up.User).FirstOrDefault(predicate)!;
    }
}
