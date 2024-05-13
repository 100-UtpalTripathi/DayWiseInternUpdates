using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestTrackerModelLibrary.Migrations
{
    public partial class Modifiedfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolutionFeedback_Employees_FeedbackBy",
                table: "SolutionFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionFeedback_RequestSolutions_SolutionId",
                table: "SolutionFeedback");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolutionFeedback",
                table: "SolutionFeedback");

            migrationBuilder.RenameTable(
                name: "SolutionFeedback",
                newName: "SolutionFeedbacks");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionFeedback_SolutionId",
                table: "SolutionFeedbacks",
                newName: "IX_SolutionFeedbacks_SolutionId");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionFeedback_FeedbackBy",
                table: "SolutionFeedbacks",
                newName: "IX_SolutionFeedbacks_FeedbackBy");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SolvedDate",
                table: "RequestSolutions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsSolved",
                table: "RequestSolutions",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "RequestStatus",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestDate",
                table: "Requests",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "RequestClosedBy",
                table: "Requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FeedbackDate",
                table: "SolutionFeedbacks",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolutionFeedbacks",
                table: "SolutionFeedbacks",
                column: "FeedbackId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionFeedbacks_Employees_FeedbackBy",
                table: "SolutionFeedbacks",
                column: "FeedbackBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionFeedbacks_RequestSolutions_SolutionId",
                table: "SolutionFeedbacks",
                column: "SolutionId",
                principalTable: "RequestSolutions",
                principalColumn: "SolutionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolutionFeedbacks_Employees_FeedbackBy",
                table: "SolutionFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionFeedbacks_RequestSolutions_SolutionId",
                table: "SolutionFeedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolutionFeedbacks",
                table: "SolutionFeedbacks");

            migrationBuilder.RenameTable(
                name: "SolutionFeedbacks",
                newName: "SolutionFeedback");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionFeedbacks_SolutionId",
                table: "SolutionFeedback",
                newName: "IX_SolutionFeedback_SolutionId");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionFeedbacks_FeedbackBy",
                table: "SolutionFeedback",
                newName: "IX_SolutionFeedback_FeedbackBy");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SolvedDate",
                table: "RequestSolutions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsSolved",
                table: "RequestSolutions",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RequestStatus",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestDate",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RequestClosedBy",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FeedbackDate",
                table: "SolutionFeedback",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolutionFeedback",
                table: "SolutionFeedback",
                column: "FeedbackId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionFeedback_Employees_FeedbackBy",
                table: "SolutionFeedback",
                column: "FeedbackBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionFeedback_RequestSolutions_SolutionId",
                table: "SolutionFeedback",
                column: "SolutionId",
                principalTable: "RequestSolutions",
                principalColumn: "SolutionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
