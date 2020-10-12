using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Education.Presentations.WebAPP.Migrations
{
    public partial class AddEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ClassID",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Schools",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClassCode",
                table: "Classes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Classes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolID",
                table: "Classes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassID",
                table: "Students",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_SchoolID",
                table: "Classes",
                column: "SchoolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Schools_SchoolID",
                table: "Classes",
                column: "SchoolID",
                principalTable: "Schools",
                principalColumn: "SchoolID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassID",
                table: "Students",
                column: "ClassID",
                principalTable: "Classes",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Schools_SchoolID",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Classes_SchoolID",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ClassID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "ClassCode",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "SchoolID",
                table: "Classes");
        }
    }
}
