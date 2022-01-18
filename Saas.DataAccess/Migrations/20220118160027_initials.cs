using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saas.DataAccess.Migrations
{
    public partial class initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyOperationClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyOperationClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyOperationUserClaim",
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
                        principalTable: "CompanyOperationClaim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyOperationUserClaim_CompanyUser_CompanyUserId",
                        column: x => x.CompanyUserId,
                        principalTable: "CompanyUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyOperationUserClaim_CompanyOperationClaimId",
                table: "CompanyOperationUserClaim",
                column: "CompanyOperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyOperationUserClaim_CompanyUserId",
                table: "CompanyOperationUserClaim",
                column: "CompanyUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyOperationUserClaim");

            migrationBuilder.DropTable(
                name: "CompanyOperationClaim");
        }
    }
}
