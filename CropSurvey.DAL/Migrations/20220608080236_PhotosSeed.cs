using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CropSurvey.Data.Migrations
{
    public partial class PhotosSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "ID", "CategoryID" },
                values: new object[,]
                {
                    { "10594271873_611e07a39d_c.jpg", 2 },
                    { "13218800635_d1bf8dae11_c.jpg", 2 },
                    { "1636053650_4527b0585d_o.jpg", 1 },
                    { "16493328124_5facf01cba_c.jpg", 3 },
                    { "17107351976_7ca3d58d0c_c.jpg", 1 },
                    { "18030243279_5e1d9c14cc_c.jpg", 3 },
                    { "18421963655_2727ba7430_c.jpg", 1 },
                    { "19538819028_1797fb1da6_c.jpg", 1 },
                    { "2794729330_69101390e5_b.jpg", 2 },
                    { "4192603791_ef6a86762b_b.jpg", 3 },
                    { "521658559_37f2907db4_b.jpg", 2 },
                    { "5244375725_31bd21d487_b.jpg", 1 },
                    { "6060249948_51746b754f_b.jpg", 3 },
                    { "8328219972_f44dd01091_c.jpg", 3 },
                    { "8698896427_3dc7d59b02_c.jpg", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "ID",
                keyValue: "10594271873_611e07a39d_c.jpg");

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "ID",
                keyValue: "13218800635_d1bf8dae11_c.jpg");

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "ID",
                keyValue: "1636053650_4527b0585d_o.jpg");

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "ID",
                keyValue: "16493328124_5facf01cba_c.jpg");

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "ID",
                keyValue: "17107351976_7ca3d58d0c_c.jpg");

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "ID",
                keyValue: "18030243279_5e1d9c14cc_c.jpg");

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "ID",
                keyValue: "18421963655_2727ba7430_c.jpg");

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "ID",
                keyValue: "19538819028_1797fb1da6_c.jpg");

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "ID",
                keyValue: "2794729330_69101390e5_b.jpg");

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "ID",
                keyValue: "4192603791_ef6a86762b_b.jpg");

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "ID",
                keyValue: "521658559_37f2907db4_b.jpg");

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "ID",
                keyValue: "5244375725_31bd21d487_b.jpg");

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "ID",
                keyValue: "6060249948_51746b754f_b.jpg");

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "ID",
                keyValue: "8328219972_f44dd01091_c.jpg");

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "ID",
                keyValue: "8698896427_3dc7d59b02_c.jpg");
        }
    }
}
