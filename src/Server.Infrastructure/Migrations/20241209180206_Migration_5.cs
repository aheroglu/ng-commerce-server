using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Expiration",
                table: "CreditCards",
                newName: "ExpirationYear");

            migrationBuilder.AddColumn<string>(
                name: "ExpirationMonth",
                table: "CreditCards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpirationMonth",
                table: "CreditCards");

            migrationBuilder.RenameColumn(
                name: "ExpirationYear",
                table: "CreditCards",
                newName: "Expiration");
        }
    }
}
