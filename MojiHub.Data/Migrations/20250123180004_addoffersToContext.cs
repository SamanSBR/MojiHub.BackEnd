using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojiHub.Data.Migrations
{
    public partial class addoffersToContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Users_UserId",
                table: "Offer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offer",
                table: "Offer");

            migrationBuilder.RenameTable(
                name: "Offer",
                newName: "Offers");

            migrationBuilder.RenameIndex(
                name: "IX_Offer_UserId",
                table: "Offers",
                newName: "IX_Offers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offers",
                table: "Offers",
                column: "OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_UserId",
                table: "Offers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Users_UserId",
                table: "Offers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offers",
                table: "Offers");

            migrationBuilder.RenameTable(
                name: "Offers",
                newName: "Offer");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_UserId",
                table: "Offer",
                newName: "IX_Offer_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offer",
                table: "Offer",
                column: "OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Users_UserId",
                table: "Offer",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
