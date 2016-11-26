using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApp.Migrations
{
    public partial class InitMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamEvents_Events_EventId",
                table: "TeamEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamEvents_Teams_TeamId",
                table: "TeamEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamUsers_Teams_TeamId",
                table: "TeamUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamUsers_Users_UserId",
                table: "TeamUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamEvents_Events_EventId",
                table: "TeamEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamEvents_Teams_TeamId",
                table: "TeamEvents",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUsers_Teams_TeamId",
                table: "TeamUsers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUsers_Users_UserId",
                table: "TeamUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamEvents_Events_EventId",
                table: "TeamEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamEvents_Teams_TeamId",
                table: "TeamEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamUsers_Teams_TeamId",
                table: "TeamUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamUsers_Users_UserId",
                table: "TeamUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamEvents_Events_EventId",
                table: "TeamEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamEvents_Teams_TeamId",
                table: "TeamEvents",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUsers_Teams_TeamId",
                table: "TeamUsers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUsers_Users_UserId",
                table: "TeamUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
