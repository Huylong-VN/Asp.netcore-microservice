using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Product.API.Repositories.Interfaces;
using Shared.DTOs.Customer;
using Shared.DTOs.Product;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        #region CRUD
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _repository.GetProducts();
            var result = _mapper.Map<IEnumerable<CustomerDto>>(products);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProducts(long Id)
        {
            var products = await _repository.GetByIdAsync(Id);
            var result = _mapper.Map<IEnumerable<CustomerDto>>(products);
            return Ok(result);
        }

        #endregion
    }
}