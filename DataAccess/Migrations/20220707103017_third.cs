using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DifficultyLevel",
                table: "TaskModels");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TaskModels",
                newName: "DifficultyId");

            migrationBuilder.AddColumn<int>(
                name: "DeveloperId",
                table: "TaskModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    DeveloperId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeveloperName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.DeveloperId);
                });

            migrationBuilder.CreateTable(
                name: "DifficultyLevels",
                columns: table => new
                {
                    DifficultyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DifficultyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifficultyLevels", x => x.DifficultyId);
                });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "DeveloperId", "DeveloperName" },
                values: new object[,]
                {
                    { 1, "Burak" },
                    { 2, "Merve" },
                    { 3, "Furkan" },
                    { 4, "Enes" },
                    { 5, "Miray" },
                    { 6, "Dilara" },
                    { 7, "Buse" },
                    { 8, "Alper" }
                });

            migrationBuilder.InsertData(
                table: "DifficultyLevels",
                columns: new[] { "DifficultyId", "DifficultyName" },
                values: new object[,]
                {
                    { 1, "Çok Çok Kolay" },
                    { 2, "Çok Kolay" },
                    { 3, "Kolay" },
                    { 4, "Normal Düzey" },
                    { 5, "Zaman Alıcı" },
                    { 6, "Zor" },
                    { 7, "Çok Zor" },
                    { 8, "Çok Çok Zor" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "RoleName",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "RoleName",
                value: "Analyst");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { 3, "Personnel" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Email",
                value: "admin@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Email",
                value: "analyst@gmail.com");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password", "RoleId" },
                values: new object[] { 3, "personnel@gmail.com", "1234", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "DifficultyLevels");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "DeveloperId",
                table: "TaskModels");

            migrationBuilder.RenameColumn(
                name: "DifficultyId",
                table: "TaskModels",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "DifficultyLevel",
                table: "TaskModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "RoleName",
                value: "Analyst");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "RoleName",
                value: "Personnel");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Email",
                value: "analyst@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Email",
                value: "personnel@gmail.com");
        }
    }
}
