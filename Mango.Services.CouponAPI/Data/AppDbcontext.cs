using Mango.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {
                
        }
        public DbSet<Coupons> Coupons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Coupons>().HasData(new Coupons
            {
                CouponId = 1,
                CouponCode = "FIRST",
                DiscountAmount = 10,
                MinAmount = 23,
            });


            modelBuilder.Entity<Coupons>().HasData(new Coupons
            {
                CouponId = 2,
                CouponCode = "FIRST",
                DiscountAmount = 20,
                MinAmount = 40,
            });
        }
    }
}
