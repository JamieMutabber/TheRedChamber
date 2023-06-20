using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheRedChamber.Model;

namespace TheRedChamber.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //Constructor
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        //Database Tables
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        //Seeding database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MenuItem>().HasData(new MenuItem
            { 
                Id = 1,
                Name = "Peking Roasted Duck",
                Description = "Famous dish from Beijing, " +
                "considered as one of China national dishes",
                SpecialTag = "Exclusive",
                Category = "Main Course",
                Price = 29.98,
                Image = "https://images.chinahighlights.com/allpicture/2021/12/d247e7d25b164b77841f6022_cut_750x400_39.webp"

            },
            new MenuItem
            {
                Id = 2,
                Name = "Kung Pao Chicken",
                Description = " (宫保鸡丁 gōngbào jīdīng) is a famous Sichuan-style specialty, popular with both Chinese and foreigners",
                SpecialTag = "Top Rated",
                Category = "Main Course",
                Price = 26.35,
                Image = "https://images.chinahighlights.com/allpicture/2019/11/31acb7b302ec4b48b17443ed_cut_750x400_39.webp"

            },new MenuItem
            {
                Id = 3,
                Name = "Cantonese Spring Rolls",
                Description = "Famous cantonese appetizer",
                SpecialTag = " ",
                Category = "Appetizer",
                Price = 9.80,
                Image = "https://thewoksoflife.com/wp-content/uploads/2015/09/spring-rolls-8.jpg"

            },new MenuItem
            {
                Id = 4,
                Name = "Crab Rangoon",
                Description = "Most popular Chinese food appetizer",
                SpecialTag = "Top Rated",
                Category = "Appetizer",
                Price = 2.25,
                Image = "https://dinnerthendessert.com/wp-content/uploads/2018/04/Crab-Rangoon-1-1536x1024.jpg"

            },new MenuItem
            {
                Id = 5,
                Name = "Chrysanthemum Tea",
                Description = "Herbal drink",
                SpecialTag = " ",
                Category = "Drink",
                Price = 4.62,
                Image = "https://insanelygoodrecipes.com/wp-content/uploads/2023/02/Chrysanthemum-Tea-in-a-Cup-768x1152.webp"

            },new MenuItem
            {
                Id = 6,
                Name = "Osmanthus Wine",
                Description = "Herbal drink",
                SpecialTag = " ",
                Category = "Drink",
                Price = 5.70,
                Image = "https://insanelygoodrecipes.com/wp-content/uploads/2023/02/Sinkiang-Black-Beer-1-768x1152.webp"

            },new MenuItem
            {
                Id = 7,
                Name = "Nuts and Seeds",
                Description = "Peanut and chewable tasty seeds",
                SpecialTag = " ",
                Category = "Snack",
                Price = 12.30,
                Image = "https://www.travelchinaguide.com/images/photogallery/2019/1126150703.jpg"

            },new MenuItem
            {
                Id = 8,
                Name = "Candied Fruit on a Stick – Bingtang Hulu",
                Description = "This Chinese snack recipe is stringing fruits, including Chinese hawthorn berries etc...",
                SpecialTag = " ",
                Category = "Snack",
                Price = 1.50,
                Image = "https://www.travelchinaguide.com/images/photogallery/2019/1126150603.jpg"

            }
            );
        }

    }
}
