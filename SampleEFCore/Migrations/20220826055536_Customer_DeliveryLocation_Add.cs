using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleEFCore.Migrations
{
    public partial class Customer_DeliveryLocation_Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryLocation",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryLocation",
                table: "Customers");
        }
    }
}
