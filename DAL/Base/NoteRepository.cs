using DAL.Interface;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Base
{
    public class NoteRepository: GenericRepository<Note>, INoteRepository
    {

        public NoteRepository(TodoListContext todoListContext) : base(todoListContext)
        {
        }

    }
}
