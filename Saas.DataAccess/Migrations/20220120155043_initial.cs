using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saas.DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Company");

            migrationBuilder.EnsureSchema(
                name: "Roles");

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    TaxOffice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionThree = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                },
                comment: "FirmaBilgileri");

            migrationBuilder.CreateTable(
                name: "CompanyOperationClaim",
                schema: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyOperationClaim", x => x.Id);
                },
                comment: "Yetkiler");

            migrationBuilder.CreateTable(
                name: "CompanyBranch",
                schema: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionThree = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyBranch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyBranch_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Company",
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Firma şubeleri");

            migrationBuilder.CreateTable(
                name: "CompanyUser",
                schema: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassWordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PassWordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    SysAdmin = table.Column<bool>(type: "bit", nullable: false, comment: "Company Admin"),
                    BranchAdmin = table.Column<bool>(type: "bit", nullable: false, comment: "Branch Admin"),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyUser_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Company",
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Firma Kullanicilari");

            migrationBuilder.CreateTable(
                name: "CompanyUserBranches",
                schema: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUserBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyUserBranches_CompanyBranch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Company",
                        principalTable: "CompanyBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Kullanicinin Bağli oldugu Şubeler");

            migrationBuilder.CreateTable(
                name: "CompanyOperationUserClaim",
                schema: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyUserId = table.Column<int>(type: "int", nullable: false),
                    CompanyOperationClaimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyOperationUserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyOperationUserClaim_CompanyOperationClaim_CompanyOperationClaimId",
                        column: x => x.CompanyOperationClaimId,
                        principalSchema: "Roles",
                        principalTable: "CompanyOperationClaim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyOperationUserClaim_CompanyUser_CompanyUserId",
                        column: x => x.CompanyUserId,
                        principalSchema: "Company",
                        principalTable: "CompanyUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Kullanici Yetkileri");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBranch_CompanyId",
                schema: "Company",
                table: "CompanyBranch",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyOperationUserClaim_CompanyOperationClaimId",
                schema: "Roles",
                table: "CompanyOperationUserClaim",
                column: "CompanyOperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyOperationUserClaim_CompanyUserId",
                schema: "Roles",
                table: "CompanyOperationUserClaim",
                column: "CompanyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUser_CompanyId",
                schema: "Company",
                table: "CompanyUser",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUserBranches_BranchId",
                schema: "Company",
                table: "CompanyUserBranches",
                column: "BranchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyOperationUserClaim",
                schema: "Roles");

            migrationBuilder.DropTable(
                name: "CompanyUserBranches",
                schema: "Company");

            migrationBuilder.DropTable(
                name: "CompanyOperationClaim",
                schema: "Roles");

            migrationBuilder.DropTable(
                name: "CompanyUser",
                schema: "Company");

            migrationBuilder.DropTable(
                name: "CompanyBranch",
                schema: "Company");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "Company");
        }
    }
}
