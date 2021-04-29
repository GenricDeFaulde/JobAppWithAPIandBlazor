using Microsoft.EntityFrameworkCore.Migrations;

namespace JobApp.Migrations.JobDb
{
    public partial class ClearDBdeleteRestriction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobData_Job_JobId",
                schema: "dbo",
                table: "JobData");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSkill_Job_JobId",
                schema: "dbo",
                table: "JobSkill");

            migrationBuilder.AddForeignKey(
                name: "FK_JobData_Job_JobId",
                schema: "dbo",
                table: "JobData",
                column: "JobId",
                principalSchema: "dbo",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkill_Job_JobId",
                schema: "dbo",
                table: "JobSkill",
                column: "JobId",
                principalSchema: "dbo",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobData_Job_JobId",
                schema: "dbo",
                table: "JobData");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSkill_Job_JobId",
                schema: "dbo",
                table: "JobSkill");

            migrationBuilder.AddForeignKey(
                name: "FK_JobData_Job_JobId",
                schema: "dbo",
                table: "JobData",
                column: "JobId",
                principalSchema: "dbo",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkill_Job_JobId",
                schema: "dbo",
                table: "JobSkill",
                column: "JobId",
                principalSchema: "dbo",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
