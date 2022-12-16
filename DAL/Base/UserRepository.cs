using DAL.Interface;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Base
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(TodoListContext todoListContext) : base(todoListContext)
        {
        }
    }
}
