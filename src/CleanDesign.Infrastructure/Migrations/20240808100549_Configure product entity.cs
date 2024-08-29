using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanDesign.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Configureproductentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImage_Products_ProductId",
                table: "ProductImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImage",
                table: "ProductImage");

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

            migrationBuilder.RenameTable(
                name: "ProductImage",
                newName: "ProductImages");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImages",
                newName: "IX_ProductImages_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "Deleted", "Name", "NormalizedName", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("e19e81fc-0bed-4387-94af-0918b469c398"), null, new Guid("f530fbd9-5f9d-4cd2-9695-6bdd0ba23307"), new DateTime(2024, 8, 8, 15, 35, 49, 400, DateTimeKind.Local).AddTicks(4406), false, "SuperAdmin", "SUPERADMIN", new Guid("f530fbd9-5f9d-4cd2-9695-6bdd0ba23307"), new DateTime(2024, 8, 8, 15, 35, 49, 400, DateTimeKind.Local).AddTicks(4422) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "Deleted", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedBy", "UpdatedOn", "UserName" },
                values: new object[] { new Guid("f530fbd9-5f9d-4cd2-9695-6bdd0ba23307"), 0, "83f440f3-fa4f-4555-9d21-cef50422bd99", new Guid("f530fbd9-5f9d-4cd2-9695-6bdd0ba23307"), new DateTime(2024, 8, 8, 15, 35, 49, 350, DateTimeKind.Local).AddTicks(4145), false, "clean.admin@yopmail.com", true, false, null, "Admin User", "CLEAN.ADMIN@YOPMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAENOdwmsDWOU8TdUM+IRRBJBkZqLHHxdiwlzuNHz0oJolTvVea1CKjMuR3kr1ie62zg==", "1234567890", true, "647acef6-a544-461e-abf2-8a66b151d57e", false, new Guid("f530fbd9-5f9d-4cd2-9695-6bdd0ba23307"), new DateTime(2024, 8, 8, 15, 35, 49, 350, DateTimeKind.Local).AddTicks(4163), "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("e19e81fc-0bed-4387-94af-0918b469c398"), new Guid("f530fbd9-5f9d-4cd2-9695-6bdd0ba23307") });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e19e81fc-0bed-4387-94af-0918b469c398"), new Guid("f530fbd9-5f9d-4cd2-9695-6bdd0ba23307") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e19e81fc-0bed-4387-94af-0918b469c398"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f530fbd9-5f9d-4cd2-9695-6bdd0ba23307"));

            migrationBuilder.RenameTable(
                name: "ProductImages",
                newName: "ProductImage");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImage",
                newName: "IX_ProductImage_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImage",
                table: "ProductImage",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImage_Products_ProductId",
                table: "ProductImage",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
