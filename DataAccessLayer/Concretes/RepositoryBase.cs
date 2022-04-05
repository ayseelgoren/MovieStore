using DataAccessLayer.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concretes
{
    public class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        TContext context = new TContext();

        public void Add(TEntity entity)
        {
            try
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotImplementedException("Ekleme işlemi başarısız.");
            }
        }

        public void Delete(TEntity entity)
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public virtual List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public void Update(TEntity entity)
        {
            //context.Entry(entity).State = EntityState.Detached;
            context.Update(entity);
            context.SaveChanges();
        }

        public virtual void UpdateMatchEntity(TEntity updateEntity, TEntity setEntity)
        {
            if (setEntity == null)
                throw new ArgumentNullException(nameof(setEntity));

            if (updateEntity == null)
                throw new ArgumentNullException(nameof(updateEntity));

            context.Entry(updateEntity).CurrentValues.SetValues(setEntity);//Tüm kayıtlar, kolon eşitlemesine gitmeden bir entity'den diğerine atanır.

            //Olmayan yani null gelen kolonlar, var olan tablonun üstüne ezilmesin diye ==> "IsModified = false" olarak atanır ve var olan kayıtların null olarak güncellenmesi engellenir.
            foreach (var property in context.Entry(setEntity).Properties)
            {
                if (property.CurrentValue == null) { context.Entry(updateEntity).Property(property.Metadata.Name).IsModified = false; }
            }

            context.SaveChanges();
        }
    }
}
