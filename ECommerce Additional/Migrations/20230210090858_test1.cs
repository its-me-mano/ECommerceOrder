using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_Additional.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true),
                    PaymentTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "ProductId", "UserId", "quantity" },
                values: new object[] { new Guid("0483cc0e-85b5-487d-a540-8096ea2a1891"), new Guid("2b6aa7d6-1974-430f-a760-3ced549d0471"), new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"), 2 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "PaymentMethod", "PaymentTime", "Price", "ProductId", "Quantity", "UserId" },
                values: new object[] { new Guid("917c0fc2-7994-4fa4-a96b-d9a12a3fc907"), "UPI", new DateTime(2023, 2, 10, 14, 38, 58, 679, DateTimeKind.Local).AddTicks(8392), 5000f, new Guid("2b6aa7d6-1974-430f-a760-3ced549d0471"), 1, new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be") });

            migrationBuilder.InsertData(
                table: "WishLists",
                columns: new[] { "Id", "Name", "ProductId", "UserId" },
                values: new object[] { new Guid("698f8b7b-65d2-4425-b724-46c076943f17"), "MyMobileCollection", new Guid("2b6aa7d6-1974-430f-a760-3ced549d0471"), new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "WishLists");
        }
    }
}
