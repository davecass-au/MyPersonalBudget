using API.Data;
using API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Models.DTOs.Interfaces;
using Shared.Models.Entities.Interfaces;

namespace API.Services.Base
{
    public class BaseService<T, EntityT>(MyBudgetDbContext db, DbSet<EntityT> dbSet) : IBaseService<T> 
        where T : IBaseDto, IDto<EntityT>
        where EntityT : class, IBaseDto, IEntity<T>
    {
        public int Add(T toAdd)
        {
            EntityT entity = toAdd.ConvertToNewEntity();
            dbSet.Add(entity);

            db.SaveChanges();

            if (entity != null)
            {
                db.Entry(entity).Reload();
                return entity.Id;
            }

            return 0;
        }

        public void Delete(T toDelete)
        {
            EntityT? toRemove = GetEntityById(toDelete.Id);

            if (toRemove != null)
            {
                dbSet.Remove(toRemove);
                db.SaveChanges();
            }
        }

        public T? Get(int id)
        {
            return GetById(id);
        }

        public IEnumerable<T> Get()
        {
            return GetAll();
        }

        public void Update(int id, T updatedRecord)
        {
            EntityT? entityToUpdate = GetEntityById(id);

            if (entityToUpdate != null)
            { 
                entityToUpdate.Update(updatedRecord);
                db.SaveChanges();
            }
        }

        public EntityT? GetEntityById(int id)
        {
            return dbSet.FirstOrDefault(x => x.Id == id);
        }

        public T? GetById(int id)
        {
            EntityT? entity = GetEntityById(id);

            return entity != null ? entity.ConvertToDto() : default;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.Select(x => x.ConvertToDto());
        }
    }
}
