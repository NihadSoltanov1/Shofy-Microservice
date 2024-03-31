using Shofy.Discount.Dtos.CouponDtos;

namespace Shofy.Discount.Services
{
    public interface ICouponService
    {
        Task<List<ResultCouponDto>> GetAllCouponsAsync();
        Task AddCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(int id);
        Task<GetByIdCouponDto> GetByIdCouponAsync(int id);
    }
}
