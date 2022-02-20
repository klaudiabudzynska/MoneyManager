using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyManager.Migrations
{
    public partial class identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Income",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Expenses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Income_OwnerId",
                table: "Income",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_OwnerId",
                table: "Expenses",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_AspNetUsers_OwnerId",
                table: "Expenses",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Income_AspNetUsers_OwnerId",
                table: "Income",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_AspNetUsers_OwnerId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_AspNetUsers_OwnerId",
                table: "Income");

            migrationBuilder.DropIndex(
                name: "IX_Income_OwnerId",
                table: "Income");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_OwnerId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Expenses");
        }
    }
}
