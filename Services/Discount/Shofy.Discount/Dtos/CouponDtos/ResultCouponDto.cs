﻿namespace Shofy.Discount.Dtos.CouponDtos
{
    public class ResultCouponDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsValid { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
