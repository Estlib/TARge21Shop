﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TARge21Shop.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spaceships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrewCount = table.Column<int>(type: "int", nullable: false),
                    PassangerCount = table.Column<int>(type: "int", nullable: false),
                    Cargo = table.Column<int>(type: "int", nullable: false),
                    FullTripCount = table.Column<int>(type: "int", nullable: false),
                    MaintenanceCount = table.Column<int>(type: "int", nullable: false),
                    LastMaintenance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BuildDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnginePower = table.Column<int>(type: "int", nullable: false),
                    MaidenLaunch = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaceships", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spaceships");
        }
    }
}
