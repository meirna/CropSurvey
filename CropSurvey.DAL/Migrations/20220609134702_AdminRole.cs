using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CropSurvey.Data.Migrations
{
    public partial class AdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7ef13e65-79a6-438f-9890-43c001425268", "9304dc50-da8c-4d1c-897d-b5b6047c04d3", "Admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ef13e65-79a6-438f-9890-43c001425268");
        }
    }
}
