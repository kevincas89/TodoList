using Abp.Domain.Uow;
using BLL.Interface;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Base
{
    public class UserService : GenericService<User>, IUserService
    {
        public UserService(TodoListContext todoListContext, IUnitOfWork unitOfWork) : base(todoListContext, unitOfWork)
        {

        }
    }
}
