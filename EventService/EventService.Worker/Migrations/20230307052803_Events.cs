using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventService.Worker.Migrations
{
    /// <inheritdoc />
    public partial class Events : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Events");

            migrationBuilder.RenameIndex(
                name: "IX_Event_Key",
                table: "Events",
                newName: "IX_Events_Key");

            migrationBuilder.RenameIndex(
                name: "IX_Event_Id",
                table: "Events",
                newName: "IX_Events_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Event");

            migrationBuilder.RenameIndex(
                name: "IX_Events_Key",
                table: "Event",
                newName: "IX_Event_Key");

            migrationBuilder.RenameIndex(
                name: "IX_Events_Id",
                table: "Event",
                newName: "IX_Event_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "Id");
        }
    }
}
