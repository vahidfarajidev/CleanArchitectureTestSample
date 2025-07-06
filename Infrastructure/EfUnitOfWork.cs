using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;

namespace Infrastructure
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void Commit() => _context.SaveChanges();
    }
}
