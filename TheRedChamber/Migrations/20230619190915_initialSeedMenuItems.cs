using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheRedChamber.Migrations
{
    /// <inheritdoc />
    public partial class initialSeedMenuItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Category", "Description", "Image", "Name", "Price", "SpecialTag" },
                values: new object[,]
                {
                    { 1, "Main Course", "Famous dish from Beijing, considered as one of China national dishes", "https://images.chinahighlights.com/allpicture/2021/12/d247e7d25b164b77841f6022_cut_750x400_39.webp", "Peking Roasted Duck", 29.98, "Exclusive" },
                    { 2, "Main Course", " (宫保鸡丁 gōngbào jīdīng) is a famous Sichuan-style specialty, popular with both Chinese and foreigners", "https://images.chinahighlights.com/allpicture/2019/11/31acb7b302ec4b48b17443ed_cut_750x400_39.webp", "Kung Pao Chicken", 26.35, "Top Rated" },
                    { 3, "Appetizer", "Famous cantonese appetizer", "https://thewoksoflife.com/wp-content/uploads/2015/09/spring-rolls-8.jpg", "Cantonese Spring Rolls", 9.87, " " },
                    { 4, "Appetizer", "Most popular Chinese food appetizer", "https://dinnerthendessert.com/wp-content/uploads/2018/04/Crab-Rangoon-1-1536x1024.jpg", "Crab Rangoon", 2.25, "Top Rated" },
                    { 5, "Drink", "Herbal drink", "https://insanelygoodrecipes.com/wp-content/uploads/2023/02/Chrysanthemum-Tea-in-a-Cup-768x1152.webp", "Chrysanthemum Tea", 4.62, " " },
                    { 6, "Drink", "Herbal drink", "https://insanelygoodrecipes.com/wp-content/uploads/2023/02/Sinkiang-Black-Beer-1-768x1152.webp", "Osmanthus Wine", 5.72, " " },
                    { 7, "Snack", "Peanut and chewable tasty seeds", "https://www.travelchinaguide.com/images/photogallery/2019/1126150703.jpg", "Nuts and Seeds", 12.30, " " },
                    { 8, "Snack", "This Chinese snack recipe is stringing fruits, including Chinese hawthorn berries etc...", "https://www.travelchinaguide.com/images/photogallery/2019/1126150603.jpg", "Candied Fruit on a Stick – Bingtang Hulu", 1.50, " " }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
