using Infrastructure.Contexts;
using System.Diagnostics;

namespace Infrastructure.Repositories;

public class UserProfileRepository(DatabaseContext context) : BaseRepository<UserProfileRepository>(context)
{
    private readonly DatabaseContext _context = context;
    
}
