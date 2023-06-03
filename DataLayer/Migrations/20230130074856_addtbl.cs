using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class addtbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advertises",
                columns: table => new
                {
                    AdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gifPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    flag = table.Column<byte>(type: "tinyint", nullable: false),
                    Advlocation = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertises", x => x.AdId);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId_Fk = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date_Register = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BirthDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    UserAvatar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId_Fk",
                        column: x => x.RoleId_Fk,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    NewsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceNewsID = table.Column<byte>(type: "tinyint", nullable: false),
                    NewsType = table.Column<byte>(type: "tinyint", nullable: false),
                    Abstract = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    VisitCount = table.Column<int>(type: "int", nullable: false),
                    NewsDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndexImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID_fk = table.Column<int>(type: "int", nullable: false),
                    CategoryID_fk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.NewsId);
                    table.ForeignKey(
                        name: "FK_News_categories_CategoryID_fk",
                        column: x => x.CategoryID_fk,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_News_Users_UserID_fk",
                        column: x => x.UserID_fk,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    commentDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    commentTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    DisLikeCount = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    ReplyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "NewsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_NewsId",
                table: "Comments",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_News_CategoryID_fk",
                table: "News",
                column: "CategoryID_fk");

            migrationBuilder.CreateIndex(
                name: "IX_News_UserID_fk",
                table: "News",
                column: "UserID_fk");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId_Fk",
                table: "Users",
                column: "RoleId_Fk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertises");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
