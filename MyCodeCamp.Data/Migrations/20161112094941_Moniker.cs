﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPITest.Data.Migrations
{
    public partial class Moniker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Moniker",
                table: "Camps",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Moniker",
                table: "Camps");
        }
    }
}
