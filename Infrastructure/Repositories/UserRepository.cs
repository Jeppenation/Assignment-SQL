using Infrastructure.Contexts;
using Infrastructure.Entities;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class UserRepository(DatabaseContext context)
    {
        private readonly DatabaseContext _context = context;

        // Create
        public UsersEntity Create(UsersEntity user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        // Read all
        public IEnumerable<UsersEntity> GetAll()
        {
            return _context.Users.ToList();
        }

        // Read One
        public UsersEntity GetById(Expression<Func<UsersEntity, bool>> predicate)
        {
            var entity = _context.Users.FirstOrDefault(predicate);

            if(entity != null)
            {
                return entity;
            }
            return null!;
        }

        // Update
        public UsersEntity Update(UsersEntity user)
        {
            var userToUpdate = _context.Users.FirstOrDefault(x => x.Id == user.Id);
            if (userToUpdate != null)
            {
                // Explicitly update the properties you want to change
                userToUpdate.LastModified = DateTime.Now;

                _context.Users.Update(userToUpdate);
                _context.SaveChanges();
                return userToUpdate;
            }

            return null!;
        }

        // Delete
        public bool Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }
    }

}
