using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Repositories
{
    public interface IUserRepository : IRepository<User, long>
    {
        ValueTask<bool> CreateAsync(User user, string password);
    }
}
