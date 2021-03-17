using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project1.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    ApptID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroupName = table.Column<string>(type: "TEXT", nullable: false),
                    GroupSize = table.Column<int>(type: "INTEGER", nullable: false),
                    ApptTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GroupEmail = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNum = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.ApptID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");
        }
    }
}
