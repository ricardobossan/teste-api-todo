using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kobold.TodoApp.Api.Migrations
{
    public partial class SeedNegativeValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "DataCriacao", "Description", "Done" },
                values: new object[,]
                {
                    { -1, new DateTime(2023, 8, 23, 11, 8, 44, 961, DateTimeKind.Local).AddTicks(2269), "Procurar receita", true },
                    { -2, new DateTime(2023, 8, 23, 11, 8, 44, 961, DateTimeKind.Local).AddTicks(4599), "Comprar ingredientes", true },
                    { -3, new DateTime(2023, 8, 23, 11, 8, 44, 961, DateTimeKind.Local).AddTicks(4685), "Cozinhar receita", false },
                    { -4, new DateTime(2023, 8, 23, 11, 8, 44, 961, DateTimeKind.Local).AddTicks(4735), "Servir mesa", false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "DataCriacao", "Description", "Done" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 23, 0, 46, 3, 993, DateTimeKind.Local).AddTicks(5678), "Procurar receita", true },
                    { 2, new DateTime(2023, 8, 23, 0, 46, 3, 993, DateTimeKind.Local).AddTicks(7977), "Comprar ingredientes", true },
                    { 3, new DateTime(2023, 8, 23, 0, 46, 3, 993, DateTimeKind.Local).AddTicks(8078), "Cozinhar receita", false },
                    { 4, new DateTime(2023, 8, 23, 0, 46, 3, 993, DateTimeKind.Local).AddTicks(8128), "Servir mesa", false }
                });
        }
    }
}
