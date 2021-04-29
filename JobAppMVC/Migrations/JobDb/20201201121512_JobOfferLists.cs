using Microsoft.EntityFrameworkCore.Migrations;

namespace JobApp.Migrations.JobDb
{
    public partial class JobOfferLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SalaryOffered",
                schema: "dbo",
                table: "JobOffer",
                type: "decimal(9,3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MinSalary",
                schema: "dbo",
                table: "JobData",
                type: "decimal(9,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxSalary",
                schema: "dbo",
                table: "JobData",
                type: "decimal(9,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SalaryOffered",
                schema: "dbo",
                table: "JobOffer",
                type: "decimal(5,3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MinSalary",
                schema: "dbo",
                table: "JobData",
                type: "decimal(5,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxSalary",
                schema: "dbo",
                table: "JobData",
                type: "decimal(5,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,3)");
        }
    }
}
