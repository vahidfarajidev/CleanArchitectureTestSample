using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class EfUserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public EfUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(User user) => _context.Users.Add(user);

        public User GetById(Guid id) => _context.Users.FirstOrDefault(u => u.Id == id);

        public void Update(User user) => _context.Users.Update(user);
    }
}
