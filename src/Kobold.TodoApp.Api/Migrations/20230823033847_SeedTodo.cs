using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kobold.TodoApp.Api.Migrations
{
    public partial class SeedTodo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "DataCriacao", "Description", "Done" },
                values: new object[,]
                {
                    { -1, new DateTime(2023, 8, 23, 0, 38, 47, 130, DateTimeKind.Local).AddTicks(7688), "Procurar receita", true },
                    { -2, new DateTime(2023, 8, 23, 0, 38, 47, 130, DateTimeKind.Local).AddTicks(9912), "Comprar ingredientes", true },
                    { -3, new DateTime(2023, 8, 23, 0, 38, 47, 131, DateTimeKind.Local).AddTicks(11), "Cozinhar receita", false },
                    { -4, new DateTime(2023, 8, 23, 0, 38, 47, 131, DateTimeKind.Local).AddTicks(63), "Servir mesa", false }
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
        }
    }
}
