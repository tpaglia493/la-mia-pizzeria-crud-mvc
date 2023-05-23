using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaMiaPizzeria.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "AspNetUserRoles",
               columns: table => new
               {
                   UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                   RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                   table.ForeignKey(
                       name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                       column: x => x.RoleId,
                       principalTable: "AspNetRoles",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                       name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                       column: x => x.UserId,
                       principalTable: "AspNetUsers",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
               });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
              name: "AspNetUserRoles");
        }
    }
}
