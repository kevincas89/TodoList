using Abp.Domain.Uow;
using BLL.Interface;
using BLL.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Base
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {

        private IUnitOfWork _unitOfWork;
        private GenericRepository<TEntity> _repository;

        public GenericService(TodoListContext todoListContext, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = new GenericRepository<TEntity>(todoListContext);
        }

        public async Task<GenericResponse<TEntity>> Delete(int id)
        {
            try
            {
                var entity = await _repository.GetById(id);
                if (entity != null)
                {
                    await _repository.Delete(id);
                    _unitOfWork.Commit();
                    return new GenericResponse<TEntity>(entity);
                }
                return new GenericResponse<TEntity>($"No se encontro el registro");
            }
            catch (Exception e)
            {
                _unitOfWork.Dispose();
                return new GenericResponse<TEntity>($"Error de consulta: error {e.Message}");

            }
        }

        public async Task<GenericResponse<TEntity>> GetAll()
        {

            try
            {
                IEnumerable<TEntity> entities = await _repository.GetAll();
                if (entities != null)
                {
                    return new GenericResponse<TEntity>(entities);
                }
                return new GenericResponse<TEntity>($"No se encotraron registros");
            }
            catch (Exception e) { _unitOfWork.Dispose(); return new GenericResponse<TEntity>($"Error de consulta: error {e.Message}"); }

        }

        public async Task<GenericResponse<TEntity>> GetById(int i)
        {
            try
            {
                var Entity = await _repository.GetById(i);
                if (Entity != null)
                {
                    return new GenericResponse<TEntity>(Entity);
                }
                return new GenericResponse<TEntity>($"No se encontro registro");
            }
            catch (Exception e) { _unitOfWork.Dispose(); return new GenericResponse<TEntity>($"Error de consulta: error {e.Message}"); }
        }

        public async Task<GenericResponse<TEntity>> Insert(TEntity entity, int id)
        {
            try
            {
                var entityFind = await _repository.GetById(id);
                if (entityFind == null)
                {
                    await _repository.Insert(entity);
                    _unitOfWork.Commit();
                    return new GenericResponse<TEntity>(entity);
                }
                return new GenericResponse<TEntity>($"Este registro ya existe");
            }
            catch (Exception e) { _unitOfWork.Dispose(); return new GenericResponse<TEntity>($"Error de registro: error {e.Message}"); }
        }

        public async Task<GenericResponse<TEntity>> Update(TEntity entity, int id)
        {
            try
            {
                var entityFind = await _repository.GetById(id);
                if (entityFind != null)
                {
                    await _repository.Update(entity);
                    _unitOfWork.Commit();
                    return new GenericResponse<TEntity>(entity);
                }
                return new GenericResponse<TEntity>($"Registro no encontrado");
            }
            catch (Exception e) { _unitOfWork.Dispose(); return new GenericResponse<TEntity>($"Error de registro: error {e.Message}"); }
        }

    }
}
