using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MicroService.Template.Domain.Commons;
using MicroService.Template.Persistence.Constants;
using System.Threading.Tasks;
using System.Threading;

namespace MicroService.Template.Persistence.Interceptors
{
    /// <summary>
    /// Define un interceptor para capturar las entidades que tuvieron
    /// algún cambio antes de guardar los cambios en la base de datos
    ///</summary>
    public class AuditableEntitySaveInterceptor:SaveChangesInterceptor
    {
        public void UpdateEntities(DbContext context)
        {
            if(context == null) return;

            foreach(var entity in context.ChangeTracker.Entries<BaseAuditableEntity>())
            {
                switch(entity.State){
                    case EntityState.Added:
                        entity.Entity.CreatedBy = EntitiesConstants.SYSTEM;
                        entity.Entity.Created = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entity.Entity.LastModifiedBy = EntitiesConstants.SYSTEM;
                        entity.Entity.LastModified = DateTime.Now;
                        break;
                }
            }
        }
    
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData,InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData,result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,InterceptionResult<int> result,CancellationToken cancellationToken)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChangesAsync(eventData,result, cancellationToken);
        }
    }
}