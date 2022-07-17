using Basket.API.Entities;
using Basket.API.Repositories.Interfaces;
using Contracts.Common.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using ILogger = Serilog.ILogger;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCacheService;
        private readonly ISerializerService _serializerService;
        private readonly ILogger _logger;

        public BasketRepository(IDistributedCache redisCacheService, ISerializerService serializerService, ILogger logger)
        {
            _redisCacheService = redisCacheService;
            _serializerService = serializerService;
            _logger = logger;
        }

        public async Task<bool> DeleteBasketFromUserName(string userName)
        {
            try
            {
                await _redisCacheService.RemoveAsync(userName);
                return true;
            }
            catch(Exception e)
            {
                _logger.Error("DeleteBasketFromUserName:" + e.Message);
                throw;
            }
            
        }

        public async Task<Cart?> GetBasketByUserName(string userName)
        {
            var basket = await _redisCacheService.GetStringAsync(userName);
            return string.IsNullOrEmpty(basket) ? null : _serializerService.Deserialize<Cart>(basket);
        }

        public async Task<Cart?> UpdateBasket(Cart cart, DistributedCacheEntryOptions options)
        {
            if(options != null)
                await _redisCacheService.SetStringAsync(cart.UserName, _serializerService.Serialize(cart), options);
            else
                await _redisCacheService.SetStringAsync(cart.UserName, _serializerService.Serialize(cart));
            return await GetBasketByUserName(cart?.UserName!);
        }
    }
}
