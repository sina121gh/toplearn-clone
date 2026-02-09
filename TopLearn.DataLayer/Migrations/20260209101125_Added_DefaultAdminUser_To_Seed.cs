using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TopLearn.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Added_DefaultAdminUser_To_Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ActiveCode", "Avatar", "Email", "IsActive", "IsDeleted", "Password", "RegisterDate", "Salt", "UserName" },
                values: new object[] { 1, "71D1AFCD55F94E30A9292121168A8D64", "DefaultAvatar.png", "admin@gmail.com", true, false, "$2a$11$KazSaGYh6zFmgVO.ZXZ48.Kgf2z8Q18d26stnhHz7hIWLrJO5RndO", new DateTime(2026, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$KazSaGYh6zFmgVO.ZXZ48.", "admin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "UpdateDate", "UserId" },
                values: new object[] { 1, 0, new DateTime(2026, 2, 9, 13, 41, 21, 868, DateTimeKind.Local).AddTicks(7462), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
