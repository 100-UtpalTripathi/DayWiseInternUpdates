using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatesDoctorseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 101,
                column: "Specialization",
                value: "Neurologist");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 102,
                column: "Specialization",
                value: "Cardiologist");

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "ContactNumber", "Email", "ExperienceInYears", "Name", "Specialization" },
                values: new object[] { 103, "0000000000", "akatsuki@gmail.com", 15, "Akatsuki Rising", "Neurologist" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 101,
                column: "Specialization",
                value: "");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 102,
                column: "Specialization",
                value: "");
        }
    }
}
