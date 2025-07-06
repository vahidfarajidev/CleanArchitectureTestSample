using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetById(Guid id);
        void Update(User user);
    }
}
