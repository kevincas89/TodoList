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
    public class NoteService : GenericService<Note>, INoteService
    {
        public NoteService(TodoListContext todoListContext, IUnitOfWork unitOfWork) : base(todoListContext, unitOfWork)
        {

        }
    }
}
