using MicroService.Template.Domain.Entities;
using MicroService.Template.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MicroService.Template.Persistence.Context
{
    public class ApplicationDbContext: DbContext
    {
        public readonly AuditableEntitySaveInterceptor _interceptor;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,AuditableEntitySaveInterceptor interceptor):base(options)
        {
            _interceptor=interceptor;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Discount>().ToTable("Discounts");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//Descubre todas las configuraciones que se hayan definido al interior del proyecto
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//Este método se utiliza para agregar interceptores
        {
            optionsBuilder.AddInterceptors(_interceptor);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Discount> Discounts{get;set;}


    }
}