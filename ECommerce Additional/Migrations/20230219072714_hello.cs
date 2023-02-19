using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_Additional.Migrations
{
    public partial class hello : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("917c0fc2-7994-4fa4-a96b-d9a12a3fc907"),
                columns: new[] { "PaymentTime", "ProductId" },
                values: new object[] { new DateTime(2023, 2, 19, 12, 57, 13, 773, DateTimeKind.Local).AddTicks(2020), new Guid("e0df594f-1a9b-4fa8-9ac0-6b24db187318") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("917c0fc2-7994-4fa4-a96b-d9a12a3fc907"),
                columns: new[] { "PaymentTime", "ProductId" },
                values: new object[] { new DateTime(2023, 2, 13, 0, 42, 13, 717, DateTimeKind.Local).AddTicks(6787), new Guid("2b6aa7d6-1974-430f-a760-3ced549d0471") });
        }
    }
}
