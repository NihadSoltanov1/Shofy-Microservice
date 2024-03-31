namespace Shofy.Discount.Entities
{
    public class Coupon
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsValid { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
