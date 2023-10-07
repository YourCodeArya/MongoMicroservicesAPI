using System.ComponentModel.DataAnnotations;

namespace Mango.Services.CouponAPI.Models
{
    public class Coupons
    {
        [Key]
        public int CouponId { get; set; }
        [Required]
        public string CouponCode { get; set; }
        [Required]

        public double DiscountAmount { get; set; }
        [Required]

        public int MinAmount { get; set; }
        
    }
}
