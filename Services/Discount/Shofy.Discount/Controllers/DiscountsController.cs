using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shofy.Discount.Dtos.CouponDtos;
using Shofy.Discount.Services;

namespace Shofy.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        readonly ICouponService _couponService;

        public DiscountsController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoupons()
        {
            var values = await _couponService.GetAllCouponsAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCoupon(int id)
        {
            var value = await _couponService.GetByIdCouponAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> AddCoupon(CreateCouponDto createCouponDto)
        {
            await _couponService.AddCouponAsync(createCouponDto);
            return Ok("Coupon added successfuly");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await _couponService.DeleteCouponAsync(id);
            return Ok("Coupon removed successfuly");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            await _couponService.UpdateCouponAsync(updateCouponDto);
            return Ok("Coupon updated successfuly");
        }

    }
}
