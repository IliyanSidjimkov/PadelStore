using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PadelStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedOneMoreProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "ImageUrl", "IsDeleted", "Price", "ProductDescription", "ProductName" },
                values: new object[] { new Guid("481d1039-e133-4c2f-9c65-832ffff1866a"), new Guid("eb8608d9-3afc-4de5-b335-2635a1d3d584"), new Guid("c18232f3-981a-4f77-a51e-62d755dcdfb4"), "https://cdn.sportdepot.bg/files/catalog/detail/IC3568_01.jpg", false, 10m, "Бъдете фокусирани върху играта си, точка след точка. Тези големи тенис накитници от adidas ви помагат да отвеждате влагата и да поддържате концентрацията си. Меки, еластични и абсорбиращи, те ще гарантират, че ще държите окото си върху топката до гейма, сета и мача.", "Adidas Wristband" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("481d1039-e133-4c2f-9c65-832ffff1866a"));
        }
    }
}
