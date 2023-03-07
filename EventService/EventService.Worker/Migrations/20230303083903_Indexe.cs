using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventService.Worker.Migrations
{
    /// <inheritdoc />
    public partial class Indexe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Event_Key",
                table: "Event",
                column: "Key")
                .Annotation("Npgsql:IndexInclude", new[] { "AppName" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Event_Key",
                table: "Event");
        }
    }
}
