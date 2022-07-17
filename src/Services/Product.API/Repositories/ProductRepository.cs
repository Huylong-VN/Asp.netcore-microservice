using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using Product.API.Entities;
using Product.API.Persistence;
using Product.API.Repositories.Interfaces;

namespace Product.API.Repositories
{
    public class ProductRepository : RepositoryBase<CatalogProduct, long, ProductContext>, IProductRepository
    {
        public ProductRepository(IUnitOfWork<ProductContext> unitOfWork, ProductContext dbContext) : base(unitOfWork, dbContext)
        {
        }

        public Task CreateProduct(CatalogProduct product) =>
            CreateAsync(product);

        public async Task DeleteProduct(long id)
        {
            var product = await GetProduct(id);
            if(product != null) await DeleteAsync(product);
        }

        public async Task<IEnumerable<CatalogProduct>> GetProducts() => await FindAll().ToListAsync();

        public Task<CatalogProduct?> GetProduct(long Id) => GetByIdAsync(Id);

        public async Task<CatalogProduct?> GetProductByNo(string productNo) =>
            await FindByCondition(x => x!.No!.Equals(productNo!)).SingleOrDefaultAsync()!;

        public Task UpdateProduct(CatalogProduct product) => 
            UpdateAsync(product);

    }
}
