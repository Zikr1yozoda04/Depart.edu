using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mavzuho.Migrations
{
    /// <inheritdoc />
    public partial class AddKatMavzsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KatMavzs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KatMavzs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mavods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Suroga = table.Column<string>(type: "text", nullable: false),
                    Sohib = table.Column<int>(type: "integer", nullable: false),
                    IdFan = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mavods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mavzus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    KatMavzu = table.Column<string>(type: "text", nullable: false),
                    Sohib = table.Column<string>(type: "text", nullable: false),
                    Rohbar = table.Column<int>(type: "integer", nullable: false),
                    Datu = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mavzus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tips", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KatMavzs");

            migrationBuilder.DropTable(
                name: "Mavods");

            migrationBuilder.DropTable(
                name: "Mavzus");

            migrationBuilder.DropTable(
                name: "Tips"); 
        }
    }
}
