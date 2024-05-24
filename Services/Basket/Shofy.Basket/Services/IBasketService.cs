using Shofy.Basket.Dtos;

namespace Shofy.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket(string userId);
        Task SaveBasket(BasketTotalDto totalBasket);
        Task DeleteBasket(string userId);
    }
}
