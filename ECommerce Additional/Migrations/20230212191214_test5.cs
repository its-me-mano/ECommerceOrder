using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_Additional.Migrations
{
    public partial class test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.AddColumn<bool>(
                name: "IsOrder",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("917c0fc2-7994-4fa4-a96b-d9a12a3fc907"),
                column: "PaymentTime",
                value: new DateTime(2023, 2, 13, 0, 42, 13, 717, DateTimeKind.Local).AddTicks(6787));

            migrationBuilder.UpdateData(
                table: "WishLists",
                keyColumn: "Id",
                keyValue: new Guid("698f8b7b-65d2-4425-b724-46c076943f17"),
                column: "Name",
                value: "mobiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOrder",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "ProductId", "UserId", "quantity" },
                values: new object[] { new Guid("0483cc0e-85b5-487d-a540-8096ea2a1891"), new Guid("2b6aa7d6-1974-430f-a760-3ced549d0471"), new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"), 2 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("917c0fc2-7994-4fa4-a96b-d9a12a3fc907"),
                column: "PaymentTime",
                value: new DateTime(2023, 2, 10, 14, 38, 58, 679, DateTimeKind.Local).AddTicks(8392));

            migrationBuilder.UpdateData(
                table: "WishLists",
                keyColumn: "Id",
                keyValue: new Guid("698f8b7b-65d2-4425-b724-46c076943f17"),
                column: "Name",
                value: "MyMobileCollection");
        }
    }
}
