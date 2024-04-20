using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Podomoro.Migrations
{
    /// <inheritdoc />
    public partial class ABC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Labels_LabelId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_LabelId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Labels",
                table: "Labels");

            migrationBuilder.DropColumn(
                name: "LabelId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Labels");

            migrationBuilder.RenameColumn(
                name: "isRepeat",
                table: "Tasks",
                newName: "IsRepeat");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Labels",
                newName: "Name");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EndAt",
                table: "Tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "StartAt",
                table: "Tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaskItemId",
                table: "Labels",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Labels",
                table: "Labels",
                column: "Name");

            migrationBuilder.CreateTable(
                name: "WorkQueues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    EndAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Buffer = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkQueues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkPeriod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    EndAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Buffer = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkTemplateId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPeriod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkPeriod_WorkTemplates_WorkTemplateId",
                        column: x => x.WorkTemplateId,
                        principalTable: "WorkTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Labels_TaskItemId",
                table: "Labels",
                column: "TaskItemId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPeriod_WorkTemplateId",
                table: "WorkPeriod",
                column: "WorkTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Labels_Tasks_TaskItemId",
                table: "Labels",
                column: "TaskItemId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labels_Tasks_TaskItemId",
                table: "Labels");

            migrationBuilder.DropTable(
                name: "WorkPeriod");

            migrationBuilder.DropTable(
                name: "WorkQueues");

            migrationBuilder.DropTable(
                name: "WorkTemplates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Labels",
                table: "Labels");

            migrationBuilder.DropIndex(
                name: "IX_Labels_TaskItemId",
                table: "Labels");

            migrationBuilder.DropColumn(
                name: "EndAt",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "StartAt",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskItemId",
                table: "Labels");

            migrationBuilder.RenameColumn(
                name: "IsRepeat",
                table: "Tasks",
                newName: "isRepeat");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Labels",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "LabelId",
                table: "Tasks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Labels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Labels",
                table: "Labels",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_LabelId",
                table: "Tasks",
                column: "LabelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Labels_LabelId",
                table: "Tasks",
                column: "LabelId",
                principalTable: "Labels",
                principalColumn: "Id");
        }
    }
}
