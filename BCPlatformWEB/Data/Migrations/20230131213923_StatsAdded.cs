using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BCPlatformWEB.Data.Migrations
{
    /// <inheritdoc />
    public partial class StatsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Pts = table.Column<int>(type: "int", nullable: true),
                    Reb = table.Column<int>(type: "int", nullable: true),
                    Ast = table.Column<int>(type: "int", nullable: true),
                    Blk = table.Column<int>(type: "int", nullable: true),
                    Stl = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stats");
        }
    }
}
