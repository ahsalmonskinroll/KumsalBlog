using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KumsalBlog.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "User");
        }
    }
}
