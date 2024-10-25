using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class MakeSpecialRequestNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
        name: "SpecialRequest",
        table: "Bookings",
        type: "nvarchar(max)",
        nullable: true, // Nullable olarak güncelliyoruz
        oldClrType: typeof(string),
        oldType: "nvarchar(max)",
        oldNullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
