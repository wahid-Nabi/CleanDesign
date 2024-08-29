using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanDesign.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedproductimageandmodifiedproducttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0fd80579-7cd4-4e61-b611-cd09ea970096"), new Guid("0d2a1339-fbb9-40c1-a0e3-83d7b4349fdc") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0fd80579-7cd4-4e61-b611-cd09ea970096"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0d2a1339-fbb9-40c1-a0e3-83d7b4349fdc"));

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "Deleted", "Name", "NormalizedName", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("78f45705-003f-4b50-b807-b2967d3b815b"), null, new Guid("54f54ce5-0ddc-4f04-9381-b418676cacad"), new DateTime(2024, 8, 8, 14, 56, 54, 521, DateTimeKind.Local).AddTicks(6380), false, "SuperAdmin", "SUPERADMIN", new Guid("54f54ce5-0ddc-4f04-9381-b418676cacad"), new DateTime(2024, 8, 8, 14, 56, 54, 521, DateTimeKind.Local).AddTicks(6397) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "Deleted", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedBy", "UpdatedOn", "UserName" },
                values: new object[] { new Guid("54f54ce5-0ddc-4f04-9381-b418676cacad"), 0, "363235f3-7859-4be5-a3a8-252069bbfe05", new Guid("54f54ce5-0ddc-4f04-9381-b418676cacad"), new DateTime(2024, 8, 8, 14, 56, 54, 470, DateTimeKind.Local).AddTicks(8820), false, "clean.admin@yopmail.com", true, false, null, "Admin User", "CLEAN.ADMIN@YOPMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEAJmh2/ycNjpwRGAy1q5JrVrNM+RJjk3KjLKiF6nRZBBhMq8+FOEDIZWHtgIDZSNiQ==", "1234567890", true, "6e46bdcc-af58-4c8e-966c-9ad8dfbb6c71", false, new Guid("54f54ce5-0ddc-4f04-9381-b418676cacad"), new DateTime(2024, 8, 8, 14, 56, 54, 470, DateTimeKind.Local).AddTicks(8835), "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("78f45705-003f-4b50-b807-b2967d3b815b"), new Guid("54f54ce5-0ddc-4f04-9381-b418676cacad") });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("78f45705-003f-4b50-b807-b2967d3b815b"), new Guid("54f54ce5-0ddc-4f04-9381-b418676cacad") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("78f45705-003f-4b50-b807-b2967d3b815b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("54f54ce5-0ddc-4f04-9381-b418676cacad"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "Deleted", "Name", "NormalizedName", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("0fd80579-7cd4-4e61-b611-cd09ea970096"), null, new Guid("0d2a1339-fbb9-40c1-a0e3-83d7b4349fdc"), new DateTime(2024, 8, 7, 17, 10, 8, 931, DateTimeKind.Local).AddTicks(8966), false, "SuperAdmin", "SUPERADMIN", new Guid("0d2a1339-fbb9-40c1-a0e3-83d7b4349fdc"), new DateTime(2024, 8, 7, 17, 10, 8, 931, DateTimeKind.Local).AddTicks(8991) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "Deleted", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedBy", "UpdatedOn", "UserName" },
                values: new object[] { new Guid("0d2a1339-fbb9-40c1-a0e3-83d7b4349fdc"), 0, "921f32f1-e683-40b0-99c6-71cbd13527ed", new Guid("0d2a1339-fbb9-40c1-a0e3-83d7b4349fdc"), new DateTime(2024, 8, 7, 17, 10, 8, 849, DateTimeKind.Local).AddTicks(9512), false, "clean.admin@yopmail.com", true, false, null, "Admin User", "CLEAN.ADMIN@YOPMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEAYCcYuDSIyG7KNsjyiq8yH48UYPQjgDzhcCTxKT1QCxGTxu5cfdbptpbGPwzbr/Tg==", "1234567890", true, "3c9c6589-be28-40ad-9f68-8c81760f47fd", false, new Guid("0d2a1339-fbb9-40c1-a0e3-83d7b4349fdc"), new DateTime(2024, 8, 7, 17, 10, 8, 849, DateTimeKind.Local).AddTicks(9528), "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("0fd80579-7cd4-4e61-b611-cd09ea970096"), new Guid("0d2a1339-fbb9-40c1-a0e3-83d7b4349fdc") });
        }
    }
}
