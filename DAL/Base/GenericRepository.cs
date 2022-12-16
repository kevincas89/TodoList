using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Base
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly TodoListContext todoListContext;

        public GenericRepository(TodoListContext todoListContext)
        {
            this.todoListContext = todoListContext;
        }


        public async Task Delete(int ID)
        {
            var entity = await GetById(ID);

            if (entity == null)

                throw new Exception("The entity is null");
            todoListContext.Set<TEntity>().Remove(entity);
            await todoListContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await todoListContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await todoListContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            todoListContext.Set<TEntity>().Add(entity);
            return entity;

        }

        public async Task<TEntity> Update(TEntity entity)
        {
            todoListContext.Entry(entity).State = EntityState.Modified;
            return entity;

        }


    }
}
