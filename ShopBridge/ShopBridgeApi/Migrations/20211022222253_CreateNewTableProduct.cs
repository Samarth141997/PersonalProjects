using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopBridgeApi.Migrations
{
    public partial class CreateNewTableProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Company = table.Column<string>(nullable: true),
                    DateSold = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Company", "DateSold", "Description", "Name", "Price" },
                values: new object[] { 1, "Sunfeast", new DateTime(2021, 10, 14, 10, 14, 30, 0, DateTimeKind.Unspecified), "Chocolate filled Cookies", "Dark fantasy", 30m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Company", "DateSold", "Description", "Name", "Price" },
                values: new object[] { 2, "Lays", new DateTime(2021, 10, 15, 10, 14, 30, 0, DateTimeKind.Unspecified), "Fried Chips flavoured with indian spices", "Lays Indian Masala", 10m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Company", "DateSold", "Description", "Name", "Price" },
                values: new object[] { 3, "Sunfeast", new DateTime(2021, 10, 14, 10, 14, 30, 0, DateTimeKind.Unspecified), "Chocolate filled Cookies", "Hair Dryer", 30m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
