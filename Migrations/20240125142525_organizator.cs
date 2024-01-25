using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXAMEN.Migrations
{
    /// <inheritdoc />
    public partial class organizator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Organizator",
                table: "Participanti",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Organizator",
                table: "Participanti");
        }
    }
}
