using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OmuzgorServise.Migrations
{
    /// <inheritdoc />
    public partial class AddOmuzgorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Daraja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nomgu = table.Column<string>(type: "text", nullable: false),
                    Sharh = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daraja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unvon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nomgu = table.Column<string>(type: "text", nullable: false),
                    Sharh = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unvon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Omuzgoron",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    IdDaraja = table.Column<int>(type: "integer", nullable: false),
                    IdUnvon = table.Column<int>(type: "integer", nullable: false),
                    Rasm = table.Column<string>(type: "text", nullable: false),
                    Telephon = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    JoiTav = table.Column<string>(type: "text", nullable: false),
                    JoiZist = table.Column<string>(type: "text", nullable: false),
                    Pol = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Omuzgoron", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Omuzgoron_Daraja_IdDaraja",
                        column: x => x.IdDaraja,
                        principalTable: "Daraja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Omuzgoron_Unvon_IdUnvon",
                        column: x => x.IdUnvon,
                        principalTable: "Unvon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Omuzgoron_IdDaraja",
                table: "Omuzgoron",
                column: "IdDaraja");

            migrationBuilder.CreateIndex(
                name: "IX_Omuzgoron_IdUnvon",
                table: "Omuzgoron",
                column: "IdUnvon");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Omuzgoron");

            migrationBuilder.DropTable(
                name: "Daraja");

            migrationBuilder.DropTable(
                name: "Unvon");
        }
    }
}
