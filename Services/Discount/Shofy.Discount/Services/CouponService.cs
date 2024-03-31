using Dapper;
using Shofy.Discount.Context;
using Shofy.Discount.Dtos.CouponDtos;

namespace Shofy.Discount.Services
{
    public class CouponService : ICouponService
    {
        readonly DapperContext _context;

        public CouponService(DapperContext context)
        {
            _context = context;
        }

        public async Task AddCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code, Rate, IsValid, ValidDate) values (@code, @rate, @isValid, @validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("code", createCouponDto.Code);
            parameters.Add("rate", createCouponDto.Rate);
            parameters.Add("isValid", createCouponDto.IsValid);
            parameters.Add("validDate", createCouponDto.ValidDate);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "Delete from Coupons where Id=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCouponDto>> GetAllCouponsAsync()
        {
            var query = "Select * from Coupons";
            using (var connection = _context.CreateConnection())
            {
               var values = await connection.QueryAsync<ResultCouponDto>(query);
               return values.ToList();
            }
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            var query = "Select * from Coupons where Id=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query, parameters);
                return value;
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "Update Coupons set Code=@code, Rate=@rate, IsValid=@isValid, ValidDate=@validDate where Id=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("code", updateCouponDto.Code);
            parameters.Add("rate", updateCouponDto.Rate);
            parameters.Add("isValid", updateCouponDto.IsValid);
            parameters.Add("validDate", updateCouponDto.ValidDate);
            parameters.Add("couponId", updateCouponDto.Id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
