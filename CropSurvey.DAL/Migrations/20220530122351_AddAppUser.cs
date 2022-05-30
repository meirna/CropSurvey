using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CropSurvey.Data.Migrations
{
    public partial class AddAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KnowledgeLevelID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WantResults",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KnowledgeLevels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeLevels", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Muški" },
                    { 2, "Ženski" },
                    { 3, "Nije navedeno" }
                });

            migrationBuilder.InsertData(
                table: "KnowledgeLevels",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Nikakvo do osnovno" },
                    { 2, "Osnovno do srednje" },
                    { 3, "Srednje do napredno" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GenderID",
                table: "AspNetUsers",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_KnowledgeLevelID",
                table: "AspNetUsers",
                column: "KnowledgeLevelID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Genders_GenderID",
                table: "AspNetUsers",
                column: "GenderID",
                principalTable: "Genders",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_KnowledgeLevels_KnowledgeLevelID",
                table: "AspNetUsers",
                column: "KnowledgeLevelID",
                principalTable: "KnowledgeLevels",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Genders_GenderID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_KnowledgeLevels_KnowledgeLevelID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "KnowledgeLevels");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GenderID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_KnowledgeLevelID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GenderID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KnowledgeLevelID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WantResults",
                table: "AspNetUsers");
        }
    }
}
