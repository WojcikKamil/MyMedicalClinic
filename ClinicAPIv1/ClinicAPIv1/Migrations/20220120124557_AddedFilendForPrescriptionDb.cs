﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicAPIv1.Migrations
{
    public partial class AddedFilendForPrescriptionDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PrescriptionAccepted",
                table: "Prescriptions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrescriptionAccepted",
                table: "Prescriptions");
        }
    }
}
