using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CropSurvey.Data.Migrations
{
    public partial class SurveyDataModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhotoCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Photos_PhotoCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "PhotoCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crops",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhotoID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AspectRatio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Algorithm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timer = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crops", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Crops_Photos_PhotoID",
                        column: x => x.PhotoID,
                        principalTable: "Photos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PhotoCategories",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "one_subject" });

            migrationBuilder.InsertData(
                table: "PhotoCategories",
                columns: new[] { "ID", "Name" },
                values: new object[] { 2, "multiple_subjects" });

            migrationBuilder.InsertData(
                table: "PhotoCategories",
                columns: new[] { "ID", "Name" },
                values: new object[] { 3, "no_subject" });

            migrationBuilder.CreateIndex(
                name: "IX_Crops_PhotoID",
                table: "Crops",
                column: "PhotoID");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_CategoryID",
                table: "Photos",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crops");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "PhotoCategories");
        }
    }
}
