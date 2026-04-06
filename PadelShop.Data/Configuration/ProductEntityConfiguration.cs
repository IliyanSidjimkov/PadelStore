using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PadelStore.Data.Models;


namespace PadelStore.Data.Configuration
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        private readonly Product[] products = new Product[]
            { 
                new Product{
                Id = Guid.Parse("8f875dee-e80c-4076-bcc1-af7d6b33e5fc"),
                ProductName = "Bullpadel Vertex 03",
                ProductDescription = "Bullpadel Vertex 03 23: несравнима сила и прецизност за напреднали играчи на падел",
                Price = 299,
                ImageUrl = "https://media.strefatenisa.com.pl/public/media/2b/69/e7/1721085111/vertex-03-23.png?ts=1745861188",
                CategoryId = Guid.Parse("b6546657-e20f-400c-a541-084f9af110a7"),
                BrandId = Guid.Parse("6c041405-fc59-446d-abf6-9800acccc7fd"),
                IsDeleted = false
                },
                  new Product{
                Id = Guid.Parse("6018ef62-c57c-4bfe-b0c8-ff7b276f2e11"),
                ProductName = "Wilson Blade Pro",
                ProductDescription = "Отлично представяне във всяко действие на играта с тази универсална ракета Wilson, изработена от карбон, грапави повърхности и мека гума за взискателни играчи.",
                Price = 270,
                ImageUrl = "https://media.strefatenisa.com.pl/public/media/78/78/f0/1742840687/wr166911d_0_blade_pro_v3_padel_green-png-high-res.jpg?ts=1745861582",
                CategoryId = Guid.Parse("b6546657-e20f-400c-a541-084f9af110a7"),
                BrandId = Guid.Parse("c3ea1eed-d829-4072-b0dd-1eb48694bbee"),
                IsDeleted = false
                },
                 new Product{
                Id = Guid.Parse("056de4b2-c23d-4da8-a1a4-7248e6bb4fe2"),
                ProductName = "Adidas Adipower CTRL",
                ProductDescription = "Стиковете Adidas Adipower Carbon CTRL 2025 предлагат превъзходен контрол, прецизност и съвременни технологии. Идеални са за напреднали играчи, търсещи пъргавина, мощност и издръжливост при всеки удар.",
                Price = 260,
                ImageUrl = "https://www.padelnuestro.com/media/catalog/product/1/1/113673-pala-adidas-adipower-carbon-ctrl-ar1ca3u381500x1500-1.jpg",
                CategoryId = Guid.Parse("b6546657-e20f-400c-a541-084f9af110a7"),
                BrandId = Guid.Parse("eb8608d9-3afc-4de5-b335-2635a1d3d584"),
                IsDeleted = false
                },
                new Product{
                Id = Guid.Parse("12c1eb5d-5b6d-47bc-a549-ddd8e97da705"),
                ProductName = "Wilson Padel Balls",
                ProductDescription = "Топките за падел Wilson Premier Padel Speed ​​предлагат перфектната комбинация от производителност и издръжливост, за да ви помогнат да извлечете максимума от всяка игра.",
                Price = 10,
                ImageUrl = "https://padelmarket.com/cdn/shop/files/10301.jpg?v=1725951119",
                CategoryId = Guid.Parse("ba2f5f1c-a270-43a7-8d32-923a98ab7b3d"),
                BrandId = Guid.Parse("c3ea1eed-d829-4072-b0dd-1eb48694bbee"),
                IsDeleted = false
                },
                 new Product{
                Id = Guid.Parse("d5eebd00-c92e-491c-9457-967a5edd4c99"),
                ProductName = "Adidas Speed RX Balls",
                ProductDescription = "Вземете най-добрата цена за една от най-добрите топки за падел тенис, с цялото качество на Adidas, за да се насладите на най-доброто представяне.",
                Price = 12,
                ImageUrl = "https://www.zonadepadel.com/14416-large_default/box-of-adidas-speed-rx-balls-24-x-3.jpg",
                CategoryId = Guid.Parse("ba2f5f1c-a270-43a7-8d32-923a98ab7b3d"),
                BrandId = Guid.Parse("eb8608d9-3afc-4de5-b335-2635a1d3d584"),
                IsDeleted = false
                },
                 new Product{
                Id = Guid.Parse("db59af0e-510b-423a-a7a6-5c4f3476e377"),
                ProductName = "Nike Court Air Zoom",
                ProductDescription = "NikeCourt Air Zoom Vapor Pro 2: Мъжки обувки за тенис на клей, проектирани за носене на кортове с клей и падел",
                Price = 120,
                ImageUrl = "https://media.strefatenisa.com.pl/public/media/cf/36/77/1721052350/nike-court-air-zoom-zero-white-black-volt-1.jpg?ts=1745860551",
                CategoryId = Guid.Parse("d8d7a869-833a-42dd-8573-8f2ce007de7c"),
                BrandId = Guid.Parse("b2c5d88a-b33e-47f6-bbf2-a1605f77857b"),
                IsDeleted = false
                },
                 new Product{
                Id = Guid.Parse("131a6c67-aef4-429d-b4a2-c139109a293e"),
                ProductName = "Adidas GameCourt",
                ProductDescription = "Бъдете уверени във всеки мач, сет и среща. Леката мрежеста горна част и подплатената пета правят тези обувки adidas Gamecourt 2.0 перфектния ви партньор за тенис.",
                Price = 100,
                ImageUrl = "https://s.shopsector.com/uploads/productgalleryfile/images/1200x1200/maratonki-adidas-gamecourt-2-ki0781-1.jpg",
                CategoryId = Guid.Parse("d8d7a869-833a-42dd-8573-8f2ce007de7c"),
                BrandId = Guid.Parse("eb8608d9-3afc-4de5-b335-2635a1d3d584"),
                IsDeleted = false
                },
                 new Product{
                Id = Guid.Parse("c74b3a3e-3b37-426b-b0e8-1ddf9890ff66"),
                ProductName = "Padel Bag Nike",
                ProductDescription = "Специално спортен дизайн: Създаден за любители на тениса със специализирани отделения. Здрав материал: Изработен от висококачествен полиестер, издържащ на честа употреба. Оптимален размер: Перфектно балансирани размери за носене на всички необходими вещи без излишно натоварване.",
                Price = 80,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT7q-JkNvxST3R6FGtcUxSMXAgP7TeCr-rPtg&s",
                CategoryId = Guid.Parse("c18232f3-981a-4f77-a51e-62d755dcdfb4"),
                BrandId = Guid.Parse("b2c5d88a-b33e-47f6-bbf2-a1605f77857b"),
                IsDeleted = false
                },
                  new Product{
                Id = Guid.Parse("7c42bf44-693f-48ab-8edc-ababf33ae739"),
                ProductName = "Grip Pack Adidas",
                ProductDescription = "Тези микроперфорирани оувъргрипове са създадени за играчи, които търсят максимален комфорт и сигурен захват дори при интензивна игра. Специалната им структура позволява ефективно абсорбиране на пот и влага, като поддържа ръката суха и стабилна през цялото време.",
                Price = 15,
                ImageUrl = "https://cdncloudcart.com/34739/products/images/5519/padel-gripove-adidas-pack-3-white-6962342b9eb62_600x600.jpeg?1768043579",
                CategoryId = Guid.Parse("c18232f3-981a-4f77-a51e-62d755dcdfb4"),
                BrandId = Guid.Parse("eb8608d9-3afc-4de5-b335-2635a1d3d584"),
                IsDeleted = false
                },
                   new Product{
                Id = Guid.Parse("ffedc79d-35d9-403d-a508-9aeae65222e6"),
                ProductName = "Bullpadel Hack 03",
                ProductDescription = "Запознайте се с Bullpadel Hack 03 23 - перфектният аксесоар за напреднали или агресивни играчи, които жадуват за превъзходна комбинация от силна сила на удара и оптимален контрол. Със своята уникална диамантена форма и баланс към главата тази ракета гарантира феноменална сила на удара.",
                Price = 310,
                ImageUrl = "https://www.zonadepadel.com/16515-zdp_customer/bullpadel-hack-03-2024.jpg",
                CategoryId = Guid.Parse("b6546657-e20f-400c-a541-084f9af110a7"),
                BrandId = Guid.Parse("6c041405-fc59-446d-abf6-9800acccc7fd"),
                IsDeleted = false
                },
                   new Product{
                Id = Guid.Parse("7f8cfbae-4cc0-495c-b614-dcccff1b2848"),
                ProductName = "Wilson Pro Staff",
                ProductDescription = "Wilson Pro Staff V2 Tour Padel 2 не е обикновена ракета за гребане. Това е най-съвременна екипировка, специално разработена за напреднали играчи и професионалисти, които търсят максимален контрол на ударите си.",
                Price = 280,
                ImageUrl = "https://media.strefatenisa.com.pl/public/media/88/40/fd/1721070394/wr112011u_0_pro_staff_v2_tour_bl_ye_rd-png-high-res.jpg?ts=1745861264",
                CategoryId = Guid.Parse("b6546657-e20f-400c-a541-084f9af110a7"),
                BrandId = Guid.Parse("c3ea1eed-d829-4072-b0dd-1eb48694bbee"),
                IsDeleted = false
                },
                    new Product{
                Id = Guid.Parse("bc632621-3a8b-4e23-8c41-3fb22c628c4b"),
                ProductName = "Nike Backpack",
                ProductDescription = "Раница Academy Team 22 L има едно основно отделение с двупосочен цип. Голям външен джоб с цип, който може да побере топка. Вътрешен джоб, който може да побере лаптоп с размер на екрана до 15 инча.",
                Price = 70,
                ImageUrl = "https://cdn.ozone.bg/media/catalog/product/cache/1/image/400x498/a4e40ebdc3e371adff845072e1c73f37/r/a/75cfb7c6c9cb85a76305e067171037ae/ranitsa-nike---academy-team--22-l--sinya-31.jpg",
                CategoryId = Guid.Parse("c18232f3-981a-4f77-a51e-62d755dcdfb4"),
                BrandId = Guid.Parse("b2c5d88a-b33e-47f6-bbf2-a1605f77857b"),
                IsDeleted = false
                },
                    new Product{
                Id = Guid.Parse("481d1039-e133-4c2f-9c65-832ffff1866a"),
                ProductName = "Adidas Wristband",
                ProductDescription = "Бъдете фокусирани върху играта си, точка след точка. Тези големи тенис накитници от adidas ви помагат да отвеждате влагата и да поддържате концентрацията си. Меки, еластични и абсорбиращи, те ще гарантират, че ще държите окото си върху топката до гейма, сета и мача.",
                Price = 10,
                ImageUrl = "https://cdn.sportdepot.bg/files/catalog/detail/IC3568_01.jpg",
                CategoryId = Guid.Parse("c18232f3-981a-4f77-a51e-62d755dcdfb4"),
                BrandId = Guid.Parse("eb8608d9-3afc-4de5-b335-2635a1d3d584"),
                IsDeleted = false
                }





            };
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasData(products);

            entity.
                Property(p => p.Price)
                .HasPrecision(18, 2);
        }
    }
}
