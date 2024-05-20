using Shofy.Basket.Dtos;
using Shofy.Basket.Settings;
using System.Text.Json;

namespace Shofy.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string userId)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDto> GetBasket(string userId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);
            return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
        }

        public async Task SaveBasket(BasketTotalDto totalBasket)
        {
            await _redisService.GetDb().StringSetAsync(totalBasket.UserId, JsonSerializer.Serialize(totalBasket));
        }
    }
}
