using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MicroService.Template.Application.Interface.Persistence;
using MicroService.Template.Domain.Entities;
using MicroService.Template.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MicroService.Template.Persistence.Repositories
{
    internal class DiscountRepository : IDiscountRepository
    { 
        protected readonly ApplicationDbContext _applicationContext; 

        public DiscountRepository(ApplicationDbContext context)
        {
            _applicationContext = context;
        }

        public async Task<bool> AddAsync(Discount entity)
        {
            _applicationContext.Add(entity);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(Discount entity)
        {
            Discount discount = await _applicationContext.Set<Discount>().AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(entity.Id));
            
            if(discount == null) return false;

            discount.Name = entity.Name;
            discount.Percent = entity.Percent;
            discount.Status = entity.Status;

            _applicationContext.Update(discount);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(string Id)
        {
            Discount discount = await _applicationContext.Set<Discount>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id.Equals(int.Parse(Id)));

            if(discount == null) return false;

            _applicationContext.Remove(discount);

            return await Task.FromResult(true);
        }

        public async Task<List<Discount>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _applicationContext.Set<Discount>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Discount> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await _applicationContext.Set<Discount>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x=> x.Id.Equals(id),cancellationToken);
        }

        public bool Add(Discount entity)
        {
            throw new System.NotImplementedException();
        }        

        public int Count()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(string Id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Discount> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Discount>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Discount> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Discount>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Discount GetCustomer(string Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Discount> GetCustomerAsync(string Id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Discount entity)
        {
            throw new System.NotImplementedException();
        }
    }
}