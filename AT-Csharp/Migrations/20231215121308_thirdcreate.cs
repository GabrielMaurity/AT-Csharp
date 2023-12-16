using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AT_Csharp.Migrations
{
    public partial class thirdcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cores",
                table: "Pintura",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cores",
                table: "Pintura");
        }
    }
}
