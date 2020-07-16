using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackathon.Migrations
{
    public partial class Completed_Quiz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed_Quizzes_JSON",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Completed_Quiz",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuiztakerName = table.Column<string>(nullable: false),
                    CorrespondingQuizName = table.Column<string>(nullable: false),
                    maxPoints = table.Column<int>(nullable: false),
                    pointsEarned = table.Column<int>(nullable: false),
                    QuizType = table.Column<int>(nullable: false),
                    Answers_JSON = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Completed_Quiz", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Completed_Quiz");

            migrationBuilder.AddColumn<string>(
                name: "Completed_Quizzes_JSON",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
