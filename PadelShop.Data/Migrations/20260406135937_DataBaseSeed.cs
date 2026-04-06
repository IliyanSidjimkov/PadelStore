using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PadelStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataBaseSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "BrandName" },
                values: new object[,]
                {
                    { new Guid("6c041405-fc59-446d-abf6-9800acccc7fd"), "Bullpadel" },
                    { new Guid("b2c5d88a-b33e-47f6-bbf2-a1605f77857b"), "Nike" },
                    { new Guid("c3ea1eed-d829-4072-b0dd-1eb48694bbee"), "Wilson" },
                    { new Guid("eb8608d9-3afc-4de5-b335-2635a1d3d584"), "Adidas" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("b6546657-e20f-400c-a541-084f9af110a7"), "Rackets" },
                    { new Guid("ba2f5f1c-a270-43a7-8d32-923a98ab7b3d"), "Balls" },
                    { new Guid("c18232f3-981a-4f77-a51e-62d755dcdfb4"), "Accesories" },
                    { new Guid("d8d7a869-833a-42dd-8573-8f2ce007de7c"), "Shoes" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "ImageUrl", "IsDeleted", "Price", "ProductDescription", "ProductName" },
                values: new object[,]
                {
                    { new Guid("056de4b2-c23d-4da8-a1a4-7248e6bb4fe2"), new Guid("eb8608d9-3afc-4de5-b335-2635a1d3d584"), new Guid("b6546657-e20f-400c-a541-084f9af110a7"), "https://www.padelnuestro.com/media/catalog/product/1/1/113673-pala-adidas-adipower-carbon-ctrl-ar1ca3u381500x1500-1.jpg", false, 260m, "Стиковете Adidas Adipower Carbon CTRL 2025 предлагат превъзходен контрол, прецизност и съвременни технологии. Идеални са за напреднали играчи, търсещи пъргавина, мощност и издръжливост при всеки удар.", "Adidas Adipower CTRL" },
                    { new Guid("12c1eb5d-5b6d-47bc-a549-ddd8e97da705"), new Guid("c3ea1eed-d829-4072-b0dd-1eb48694bbee"), new Guid("ba2f5f1c-a270-43a7-8d32-923a98ab7b3d"), "https://padelmarket.com/cdn/shop/files/10301.jpg?v=1725951119", false, 10m, "Топките за падел Wilson Premier Padel Speed ​​предлагат перфектната комбинация от производителност и издръжливост, за да ви помогнат да извлечете максимума от всяка игра.", "Wilson Padel Balls" },
                    { new Guid("131a6c67-aef4-429d-b4a2-c139109a293e"), new Guid("eb8608d9-3afc-4de5-b335-2635a1d3d584"), new Guid("d8d7a869-833a-42dd-8573-8f2ce007de7c"), "https://s.shopsector.com/uploads/productgalleryfile/images/1200x1200/maratonki-adidas-gamecourt-2-ki0781-1.jpg", false, 100m, "Бъдете уверени във всеки мач, сет и среща. Леката мрежеста горна част и подплатената пета правят тези обувки adidas Gamecourt 2.0 перфектния ви партньор за тенис.", "Adidas GameCourt" },
                    { new Guid("6018ef62-c57c-4bfe-b0c8-ff7b276f2e11"), new Guid("c3ea1eed-d829-4072-b0dd-1eb48694bbee"), new Guid("b6546657-e20f-400c-a541-084f9af110a7"), "https://media.strefatenisa.com.pl/public/media/78/78/f0/1742840687/wr166911d_0_blade_pro_v3_padel_green-png-high-res.jpg?ts=1745861582", false, 270m, "Отлично представяне във всяко действие на играта с тази универсална ракета Wilson, изработена от карбон, грапави повърхности и мека гума за взискателни играчи.", "Wilson Blade Pro" },
                    { new Guid("7c42bf44-693f-48ab-8edc-ababf33ae739"), new Guid("eb8608d9-3afc-4de5-b335-2635a1d3d584"), new Guid("c18232f3-981a-4f77-a51e-62d755dcdfb4"), "https://cdncloudcart.com/34739/products/images/5519/padel-gripove-adidas-pack-3-white-6962342b9eb62_600x600.jpeg?1768043579", false, 15m, "Тези микроперфорирани оувъргрипове са създадени за играчи, които търсят максимален комфорт и сигурен захват дори при интензивна игра. Специалната им структура позволява ефективно абсорбиране на пот и влага, като поддържа ръката суха и стабилна през цялото време.", "Grip Pack Adidas" },
                    { new Guid("7f8cfbae-4cc0-495c-b614-dcccff1b2848"), new Guid("c3ea1eed-d829-4072-b0dd-1eb48694bbee"), new Guid("b6546657-e20f-400c-a541-084f9af110a7"), "https://media.strefatenisa.com.pl/public/media/88/40/fd/1721070394/wr112011u_0_pro_staff_v2_tour_bl_ye_rd-png-high-res.jpg?ts=1745861264", false, 280m, "Wilson Pro Staff V2 Tour Padel 2 не е обикновена ракета за гребане. Това е най-съвременна екипировка, специално разработена за напреднали играчи и професионалисти, които търсят максимален контрол на ударите си.", "Wilson Pro Staff" },
                    { new Guid("8f875dee-e80c-4076-bcc1-af7d6b33e5fc"), new Guid("6c041405-fc59-446d-abf6-9800acccc7fd"), new Guid("b6546657-e20f-400c-a541-084f9af110a7"), "https://media.strefatenisa.com.pl/public/media/2b/69/e7/1721085111/vertex-03-23.png?ts=1745861188", false, 299m, "Bullpadel Vertex 03 23: несравнима сила и прецизност за напреднали играчи на падел", "Bullpadel Vertex 03" },
                    { new Guid("bc632621-3a8b-4e23-8c41-3fb22c628c4b"), new Guid("b2c5d88a-b33e-47f6-bbf2-a1605f77857b"), new Guid("c18232f3-981a-4f77-a51e-62d755dcdfb4"), "https://cdn.ozone.bg/media/catalog/product/cache/1/image/400x498/a4e40ebdc3e371adff845072e1c73f37/r/a/75cfb7c6c9cb85a76305e067171037ae/ranitsa-nike---academy-team--22-l--sinya-31.jpg", false, 70m, "Раница Academy Team 22 L има едно основно отделение с двупосочен цип. Голям външен джоб с цип, който може да побере топка. Вътрешен джоб, който може да побере лаптоп с размер на екрана до 15 инча.", "Nike Backpack" },
                    { new Guid("c74b3a3e-3b37-426b-b0e8-1ddf9890ff66"), new Guid("b2c5d88a-b33e-47f6-bbf2-a1605f77857b"), new Guid("c18232f3-981a-4f77-a51e-62d755dcdfb4"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT7q-JkNvxST3R6FGtcUxSMXAgP7TeCr-rPtg&s", false, 80m, "Специално спортен дизайн: Създаден за любители на тениса със специализирани отделения. Здрав материал: Изработен от висококачествен полиестер, издържащ на честа употреба. Оптимален размер: Перфектно балансирани размери за носене на всички необходими вещи без излишно натоварване.", "Padel Bag Nike" },
                    { new Guid("d5eebd00-c92e-491c-9457-967a5edd4c99"), new Guid("eb8608d9-3afc-4de5-b335-2635a1d3d584"), new Guid("ba2f5f1c-a270-43a7-8d32-923a98ab7b3d"), "https://www.zonadepadel.com/14416-large_default/box-of-adidas-speed-rx-balls-24-x-3.jpg", false, 12m, "Вземете най-добрата цена за една от най-добрите топки за падел тенис, с цялото качество на Adidas, за да се насладите на най-доброто представяне.", "Adidas Speed RX Balls" },
                    { new Guid("db59af0e-510b-423a-a7a6-5c4f3476e377"), new Guid("b2c5d88a-b33e-47f6-bbf2-a1605f77857b"), new Guid("d8d7a869-833a-42dd-8573-8f2ce007de7c"), "https://media.strefatenisa.com.pl/public/media/cf/36/77/1721052350/nike-court-air-zoom-zero-white-black-volt-1.jpg?ts=1745860551", false, 120m, "NikeCourt Air Zoom Vapor Pro 2: Мъжки обувки за тенис на клей, проектирани за носене на кортове с клей и падел", "Nike Court Air Zoom" },
                    { new Guid("ffedc79d-35d9-403d-a508-9aeae65222e6"), new Guid("6c041405-fc59-446d-abf6-9800acccc7fd"), new Guid("b6546657-e20f-400c-a541-084f9af110a7"), "https://www.zonadepadel.com/16515-zdp_customer/bullpadel-hack-03-2024.jpg", false, 310m, "Запознайте се с Bullpadel Hack 03 23 - перфектният аксесоар за напреднали или агресивни играчи, които жадуват за превъзходна комбинация от силна сила на удара и оптимален контрол. Със своята уникална диамантена форма и баланс към главата тази ракета гарантира феноменална сила на удара.", "Bullpadel Hack 03" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("056de4b2-c23d-4da8-a1a4-7248e6bb4fe2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("12c1eb5d-5b6d-47bc-a549-ddd8e97da705"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("131a6c67-aef4-429d-b4a2-c139109a293e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6018ef62-c57c-4bfe-b0c8-ff7b276f2e11"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7c42bf44-693f-48ab-8edc-ababf33ae739"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7f8cfbae-4cc0-495c-b614-dcccff1b2848"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8f875dee-e80c-4076-bcc1-af7d6b33e5fc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bc632621-3a8b-4e23-8c41-3fb22c628c4b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c74b3a3e-3b37-426b-b0e8-1ddf9890ff66"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d5eebd00-c92e-491c-9457-967a5edd4c99"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("db59af0e-510b-423a-a7a6-5c4f3476e377"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ffedc79d-35d9-403d-a508-9aeae65222e6"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("6c041405-fc59-446d-abf6-9800acccc7fd"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b2c5d88a-b33e-47f6-bbf2-a1605f77857b"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("c3ea1eed-d829-4072-b0dd-1eb48694bbee"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("eb8608d9-3afc-4de5-b335-2635a1d3d584"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b6546657-e20f-400c-a541-084f9af110a7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ba2f5f1c-a270-43a7-8d32-923a98ab7b3d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c18232f3-981a-4f77-a51e-62d755dcdfb4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d8d7a869-833a-42dd-8573-8f2ce007de7c"));
        }
    }
}
