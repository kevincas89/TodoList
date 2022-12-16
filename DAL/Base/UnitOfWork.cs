using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        public TodoListContext context;

        public UnitOfWork(TodoListContext context) => context = context;

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    
    
    
    }
}
