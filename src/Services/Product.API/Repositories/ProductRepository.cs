using Contracts.Common.Interfaces;
using Contracts.Infrastructure.Common;
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

        public Task CreateProduct(CatalogProduct product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CatalogProduct>> GetProducts() => await FindAll().ToListAsync();

        public Task<CatalogProduct?> GetProduct(long Id) => GetByIdAsync(Id);

        public Task<CatalogProduct> GetProductByNo(string productNo)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(CatalogProduct product)
        {
            throw new NotImplementedException();
        }

    }
}
