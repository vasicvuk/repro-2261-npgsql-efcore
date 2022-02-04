using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PostgreEFCorePerfTest.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema("sampleSchema");

            migrationBuilder.CreateTable(
                name: "Samples",
                schema: "sampleSchema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Data1 = table.Column<string>(type: "text", nullable: true),
                    Data2 = table.Column<string>(type: "text", nullable: true),
                    Data3 = table.Column<string>(type: "text", nullable: true),
                    Data4 = table.Column<string>(type: "text", nullable: true),
                    Data5 = table.Column<string>(type: "text", nullable: true),
                    Data6 = table.Column<string>(type: "text", nullable: true),
                    Data7 = table.Column<string>(type: "text", nullable: true),
                    Data8 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samples", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Samples");
        }
    }
}
