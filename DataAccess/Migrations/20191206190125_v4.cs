using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Shelves_ShelfID",
                table: "Books");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Shelves",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Isles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "ShelfID",
                table: "Books",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Books",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerNumber = table.Column<int>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerBirthday = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Shelves_ShelfID",
                table: "Books",
                column: "ShelfID",
                principalTable: "Shelves",
                principalColumn: "ShelfID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Shelves_ShelfID",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Shelves");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Isles");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "ShelfID",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Shelves_ShelfID",
                table: "Books",
                column: "ShelfID",
                principalTable: "Shelves",
                principalColumn: "ShelfID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
