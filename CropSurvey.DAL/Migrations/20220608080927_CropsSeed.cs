using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CropSurvey.Data.Migrations
{
    public partial class CropsSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Crops",
                columns: new[] { "ID", "Algorithm", "AspectRatio", "PhotoID", "Timer" },
                values: new object[,]
                {
                    { "1x1_10594271873_611e07a39d_c_GAIC.jpg", "GAIC", "1x1", "10594271873_611e07a39d_c.jpg", 0.17000399999999999 },
                    { "1x1_10594271873_611e07a39d_c_SCJS.jpg", "SCJS", "1x1", "10594271873_611e07a39d_c.jpg", 0.051065308999999996 },
                    { "1x1_13218800635_d1bf8dae11_c_GAIC.jpg", "GAIC", "1x1", "13218800635_d1bf8dae11_c.jpg", 0.161137 },
                    { "1x1_13218800635_d1bf8dae11_c_SCJS.jpg", "SCJS", "1x1", "13218800635_d1bf8dae11_c.jpg", 0.033453663999999994 },
                    { "1x1_1636053650_4527b0585d_o_GAIC.jpg", "GAIC", "1x1", "1636053650_4527b0585d_o.jpg", 0.16977200000000001 },
                    { "1x1_1636053650_4527b0585d_o_SCJS.jpg", "SCJS", "1x1", "1636053650_4527b0585d_o.jpg", 0.032287413000000001 },
                    { "1x1_16493328124_5facf01cba_c_GAIC.jpg", "GAIC", "1x1", "16493328124_5facf01cba_c.jpg", 0.160915 },
                    { "1x1_16493328124_5facf01cba_c_SCJS.jpg", "SCJS", "1x1", "16493328124_5facf01cba_c.jpg", 0.023649838999999999 },
                    { "1x1_17107351976_7ca3d58d0c_c_GAIC.jpg", "GAIC", "1x1", "17107351976_7ca3d58d0c_c.jpg", 0.206625 },
                    { "1x1_17107351976_7ca3d58d0c_c_SCJS.jpg", "SCJS", "1x1", "17107351976_7ca3d58d0c_c.jpg", 0.022672009999999999 },
                    { "1x1_18030243279_5e1d9c14cc_c_GAIC.jpg", "GAIC", "1x1", "18030243279_5e1d9c14cc_c.jpg", 0.185504 },
                    { "1x1_18030243279_5e1d9c14cc_c_SCJS.jpg", "SCJS", "1x1", "18030243279_5e1d9c14cc_c.jpg", 0.031416159999999999 },
                    { "1x1_18421963655_2727ba7430_c_GAIC.jpg", "GAIC", "1x1", "18421963655_2727ba7430_c.jpg", 0.163498 },
                    { "1x1_18421963655_2727ba7430_c_SCJS.jpg", "SCJS", "1x1", "18421963655_2727ba7430_c.jpg", 0.018862185 },
                    { "1x1_19538819028_1797fb1da6_c_GAIC.jpg", "GAIC", "1x1", "19538819028_1797fb1da6_c.jpg", 0.16305700000000001 },
                    { "1x1_19538819028_1797fb1da6_c_SCJS.jpg", "SCJS", "1x1", "19538819028_1797fb1da6_c.jpg", 0.020661061999999997 },
                    { "1x1_2794729330_69101390e5_b_GAIC.jpg", "GAIC", "1x1", "2794729330_69101390e5_b.jpg", 0.18201999999999999 },
                    { "1x1_2794729330_69101390e5_b_SCJS.jpg", "SCJS", "1x1", "2794729330_69101390e5_b.jpg", 0.045084736 },
                    { "1x1_4192603791_ef6a86762b_b_GAIC.jpg", "GAIC", "1x1", "4192603791_ef6a86762b_b.jpg", 0.17005600000000001 },
                    { "1x1_4192603791_ef6a86762b_b_SCJS.jpg", "SCJS", "1x1", "4192603791_ef6a86762b_b.jpg", 0.049678398999999998 },
                    { "1x1_521658559_37f2907db4_b_GAIC.jpg", "GAIC", "1x1", "521658559_37f2907db4_b.jpg", 0.166793 },
                    { "1x1_521658559_37f2907db4_b_SCJS.jpg", "SCJS", "1x1", "521658559_37f2907db4_b.jpg", 0.041453280999999995 },
                    { "1x1_5244375725_31bd21d487_b_GAIC.jpg", "GAIC", "1x1", "5244375725_31bd21d487_b.jpg", 0.16248599999999999 },
                    { "1x1_5244375725_31bd21d487_b_SCJS.jpg", "SCJS", "1x1", "5244375725_31bd21d487_b.jpg", 0.047631633999999999 },
                    { "1x1_6060249948_51746b754f_b_GAIC.jpg", "GAIC", "1x1", "6060249948_51746b754f_b.jpg", 0.174479 },
                    { "1x1_6060249948_51746b754f_b_SCJS.jpg", "SCJS", "1x1", "6060249948_51746b754f_b.jpg", 0.049271327999999996 },
                    { "1x1_8328219972_f44dd01091_c_GAIC.jpg", "GAIC", "1x1", "8328219972_f44dd01091_c.jpg", 0.239204 },
                    { "1x1_8328219972_f44dd01091_c_SCJS.jpg", "SCJS", "1x1", "8328219972_f44dd01091_c.jpg", 0.023276989999999997 },
                    { "1x1_8698896427_3dc7d59b02_c_GAIC.jpg", "GAIC", "1x1", "8698896427_3dc7d59b02_c.jpg", 0.168237 },
                    { "1x1_8698896427_3dc7d59b02_c_SCJS.jpg", "SCJS", "1x1", "8698896427_3dc7d59b02_c.jpg", 0.019415742999999999 },
                    { "9x16_10594271873_611e07a39d_c_GAIC.jpg", "GAIC", "9x16", "10594271873_611e07a39d_c.jpg", 0.17738499999999999 },
                    { "9x16_10594271873_611e07a39d_c_SCJS.jpg", "SCJS", "9x16", "10594271873_611e07a39d_c.jpg", 0.073245668999999985 },
                    { "9x16_13218800635_d1bf8dae11_c_GAIC.jpg", "GAIC", "9x16", "13218800635_d1bf8dae11_c.jpg", 0.170317 },
                    { "9x16_13218800635_d1bf8dae11_c_SCJS.jpg", "SCJS", "9x16", "13218800635_d1bf8dae11_c.jpg", 0.056396752999999994 },
                    { "9x16_1636053650_4527b0585d_o_GAIC.jpg", "GAIC", "9x16", "1636053650_4527b0585d_o.jpg", 0.17463400000000001 },
                    { "9x16_1636053650_4527b0585d_o_SCJS.jpg", "SCJS", "9x16", "1636053650_4527b0585d_o.jpg", 0.063656571999999995 },
                    { "9x16_16493328124_5facf01cba_c_GAIC.jpg", "GAIC", "9x16", "16493328124_5facf01cba_c.jpg", 0.16088 },
                    { "9x16_16493328124_5facf01cba_c_SCJS.jpg", "SCJS", "9x16", "16493328124_5facf01cba_c.jpg", 0.047859749 },
                    { "9x16_17107351976_7ca3d58d0c_c_GAIC.jpg", "GAIC", "9x16", "17107351976_7ca3d58d0c_c.jpg", 0.19542599999999999 },
                    { "9x16_17107351976_7ca3d58d0c_c_SCJS.jpg", "SCJS", "9x16", "17107351976_7ca3d58d0c_c.jpg", 0.046578771999999997 },
                    { "9x16_18030243279_5e1d9c14cc_c_GAIC.jpg", "GAIC", "9x16", "18030243279_5e1d9c14cc_c.jpg", 0.19206799999999999 },
                    { "9x16_18030243279_5e1d9c14cc_c_SCJS.jpg", "SCJS", "9x16", "18030243279_5e1d9c14cc_c.jpg", 0.059915217 }
                });

            migrationBuilder.InsertData(
                table: "Crops",
                columns: new[] { "ID", "Algorithm", "AspectRatio", "PhotoID", "Timer" },
                values: new object[,]
                {
                    { "9x16_18421963655_2727ba7430_c_GAIC.jpg", "GAIC", "9x16", "18421963655_2727ba7430_c.jpg", 0.173683 },
                    { "9x16_18421963655_2727ba7430_c_SCJS.jpg", "SCJS", "9x16", "18421963655_2727ba7430_c.jpg", 0.049609460000000001 },
                    { "9x16_19538819028_1797fb1da6_c_GAIC.jpg", "GAIC", "9x16", "19538819028_1797fb1da6_c.jpg", 0.16321099999999999 },
                    { "9x16_19538819028_1797fb1da6_c_SCJS.jpg", "SCJS", "9x16", "19538819028_1797fb1da6_c.jpg", 0.032801254000000002 },
                    { "9x16_2794729330_69101390e5_b_GAIC.jpg", "GAIC", "9x16", "2794729330_69101390e5_b.jpg", 0.18517800000000001 },
                    { "9x16_2794729330_69101390e5_b_SCJS.jpg", "SCJS", "9x16", "2794729330_69101390e5_b.jpg", 0.078541163999999997 },
                    { "9x16_4192603791_ef6a86762b_b_GAIC.jpg", "GAIC", "9x16", "4192603791_ef6a86762b_b.jpg", 0.173125 },
                    { "9x16_4192603791_ef6a86762b_b_SCJS.jpg", "SCJS", "9x16", "4192603791_ef6a86762b_b.jpg", 0.068450488999999989 },
                    { "9x16_521658559_37f2907db4_b_GAIC.jpg", "GAIC", "9x16", "521658559_37f2907db4_b.jpg", 0.17425199999999999 },
                    { "9x16_521658559_37f2907db4_b_SCJS.jpg", "SCJS", "9x16", "521658559_37f2907db4_b.jpg", 0.064971199999999993 },
                    { "9x16_5244375725_31bd21d487_b_GAIC.jpg", "GAIC", "9x16", "5244375725_31bd21d487_b.jpg", 0.17402100000000001 },
                    { "9x16_5244375725_31bd21d487_b_SCJS.jpg", "SCJS", "9x16", "5244375725_31bd21d487_b.jpg", 0.066298547999999999 },
                    { "9x16_6060249948_51746b754f_b_GAIC.jpg", "GAIC", "9x16", "6060249948_51746b754f_b.jpg", 0.168851 },
                    { "9x16_6060249948_51746b754f_b_SCJS.jpg", "SCJS", "9x16", "6060249948_51746b754f_b.jpg", 0.067716222000000006 },
                    { "9x16_8328219972_f44dd01091_c_GAIC.jpg", "GAIC", "9x16", "8328219972_f44dd01091_c.jpg", 0.205904 },
                    { "9x16_8328219972_f44dd01091_c_SCJS.jpg", "SCJS", "9x16", "8328219972_f44dd01091_c.jpg", 0.050234492999999998 },
                    { "9x16_8698896427_3dc7d59b02_c_GAIC.jpg", "GAIC", "9x16", "8698896427_3dc7d59b02_c.jpg", 0.17077899999999999 },
                    { "9x16_8698896427_3dc7d59b02_c_SCJS.jpg", "SCJS", "9x16", "8698896427_3dc7d59b02_c.jpg", 0.050233554999999992 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_10594271873_611e07a39d_c_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_10594271873_611e07a39d_c_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_13218800635_d1bf8dae11_c_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_13218800635_d1bf8dae11_c_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_1636053650_4527b0585d_o_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_1636053650_4527b0585d_o_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_16493328124_5facf01cba_c_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_16493328124_5facf01cba_c_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_17107351976_7ca3d58d0c_c_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_17107351976_7ca3d58d0c_c_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_18030243279_5e1d9c14cc_c_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_18030243279_5e1d9c14cc_c_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_18421963655_2727ba7430_c_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_18421963655_2727ba7430_c_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_19538819028_1797fb1da6_c_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_19538819028_1797fb1da6_c_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_2794729330_69101390e5_b_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_2794729330_69101390e5_b_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_4192603791_ef6a86762b_b_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_4192603791_ef6a86762b_b_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_521658559_37f2907db4_b_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_521658559_37f2907db4_b_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_5244375725_31bd21d487_b_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_5244375725_31bd21d487_b_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_6060249948_51746b754f_b_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_6060249948_51746b754f_b_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_8328219972_f44dd01091_c_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_8328219972_f44dd01091_c_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_8698896427_3dc7d59b02_c_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "1x1_8698896427_3dc7d59b02_c_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_10594271873_611e07a39d_c_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_10594271873_611e07a39d_c_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_13218800635_d1bf8dae11_c_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_13218800635_d1bf8dae11_c_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_1636053650_4527b0585d_o_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_1636053650_4527b0585d_o_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_16493328124_5facf01cba_c_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_16493328124_5facf01cba_c_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_17107351976_7ca3d58d0c_c_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_17107351976_7ca3d58d0c_c_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_18030243279_5e1d9c14cc_c_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_18030243279_5e1d9c14cc_c_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_18421963655_2727ba7430_c_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_18421963655_2727ba7430_c_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_19538819028_1797fb1da6_c_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_19538819028_1797fb1da6_c_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_2794729330_69101390e5_b_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_2794729330_69101390e5_b_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_4192603791_ef6a86762b_b_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_4192603791_ef6a86762b_b_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_521658559_37f2907db4_b_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_521658559_37f2907db4_b_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_5244375725_31bd21d487_b_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_5244375725_31bd21d487_b_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_6060249948_51746b754f_b_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_6060249948_51746b754f_b_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_8328219972_f44dd01091_c_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_8328219972_f44dd01091_c_SCJS.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_8698896427_3dc7d59b02_c_GAIC.jpg");

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "ID",
                keyValue: "9x16_8698896427_3dc7d59b02_c_SCJS.jpg");
        }
    }
}
