using BLL.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task<GenericResponse<TEntity>> GetAll();
        Task<GenericResponse<TEntity>> GetById(int id);
        Task<GenericResponse<TEntity>> Insert(TEntity entity, int id);
        Task<GenericResponse<TEntity>> Update(TEntity entity, int id);
        Task<GenericResponse<TEntity>> Delete(int id);
    }
}
