using Microsoft.EntityFrameworkCore.Migrations;

namespace asp_net_shop.Migrations
{
    public partial class CategoriesPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Photo",
                value: "iphones.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Photo",
                value: "imac.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Photo" },
                values: new object[] { "Apple iWatch", "iwatch.jpg" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Photo" },
                values: new object[] { 4, "Apple iPad", "ipads.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Name", "Photo", "Price" },
                values: new object[] { 1, "iPhone 11 128gb Purple", "iphone11_128gb_purple.jpeg", 900 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "Name", "Photo", "Price" },
                values: new object[] { 2, "Экран 27\" IPS Retina (5120x2880) 5K LED / Intel Core i7 (3.8 - 5.0 ГГц) / RAM 8 ГБ / SSD 512 ГБ / AMD Radeon Pro 5500 XT, 8 ГБ / без ОД / LAN / Wi-Fi / Bluetooth / кардридер / веб-камера / macOS Catalina / 8.92 кг / серебристый / клавиатура + мышь", "iMac 27\" i7 512Gb 2020", "imac.jpg", 2999 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CartId", "CategoryId", "Description", "Name", "Photo", "Price" },
                values: new object[,]
                {
                    { 6, null, 2, "Экран 23.5\" (4480x2520) 4.5K / Apple M1 / RAM 8 ГБ / SSD 256 ГБ / Apple M1 Graphics (7 ядер) / без ОД / Wi-Fi / Bluetooth / веб-камера / macOS Big Sur / 4.46 кг / синий / клавиатура + мышь", "iMac 24\" М1 4.5К 7‑ядер GPU 256GB Blue", "imac24.jpg", 1999 },
                    { 7, null, 3, null, "iWatch Series 6 GPS 44mm Blue Aluminium Case with Deep Navy Sport Band", "iwatchblue6.jpg", 499 },
                    { 8, null, 3, null, "iWatch SE GPS 40mm Silver Aluminium Case with White Sport Band", "iwatchwhite6.jpg", 399 },
                    { 9, null, 3, null, "iWatch SE GPS 40mm Silver Aluminium Case with White Sport Band", "iwatchblack6.jpg", 449 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CartId", "CategoryId", "Description", "Name", "Photo", "Price" },
                values: new object[,]
                {
                    { 10, null, 4, null, "iPad 10.2\" Wi-Fi 32GB Space Gray 2020", "ipad10_2_gray.jpg", 449 },
                    { 11, null, 4, null, "iPad Air 10.9\" Wi-Fi 64GB Space Gray", "ipad_air_gray_10_9.jpg", 799 },
                    { 12, null, 4, null, "iPad Pro 11\" M1 Wi-Fi + Cellular 128GB Space Gray", "ipad_pro_11_gray.jpg", 1499 },
                    { 13, null, 4, null, "iPad Air 10.9\" Wi-Fi + Cellular 64GB Sky Blue", "ipad_air_10_9_blue.jpg", 1199 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Apple Watch");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Name", "Photo", "Price" },
                values: new object[] { 2, "iMax 27\"", null, 1899 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "Name", "Photo", "Price" },
                values: new object[] { 3, null, "Apple Watch 5", null, 499 });
        }
    }
}
