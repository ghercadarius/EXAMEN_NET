using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXAMEN.Migrations
{
    /// <inheritdoc />
    public partial class evenimentparticipant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evenimente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locatie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evenimente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participanti",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participanti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EvenimentParticipant",
                columns: table => new
                {
                    EvenimenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipantiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvenimentParticipant", x => new { x.EvenimenteId, x.ParticipantiId });
                    table.ForeignKey(
                        name: "FK_EvenimentParticipant_Evenimente_EvenimenteId",
                        column: x => x.EvenimenteId,
                        principalTable: "Evenimente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvenimentParticipant_Participanti_ParticipantiId",
                        column: x => x.ParticipantiId,
                        principalTable: "Participanti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvenimentParticipant_ParticipantiId",
                table: "EvenimentParticipant",
                column: "ParticipantiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvenimentParticipant");

            migrationBuilder.DropTable(
                name: "Evenimente");

            migrationBuilder.DropTable(
                name: "Participanti");
        }
    }
}
