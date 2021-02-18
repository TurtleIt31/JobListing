using Microsoft.EntityFrameworkCore.Migrations;

namespace JobListing.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USER_TYPE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_TYPE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    User_TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_USER_USER_TYPE_User_TypeId",
                        column: x => x.User_TypeId,
                        principalTable: "USER_TYPE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COMPANY",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANY", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_COMPANY_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JOB_LISTING",
                columns: table => new
                {
                    Job_ListingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JOB_LISTING", x => x.Job_ListingId);
                    table.ForeignKey(
                        name: "FK_JOB_LISTING_COMPANY_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "COMPANY",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JOB_APPLICANT",
                columns: table => new
                {
                    Job_ApplicantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicantSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expertise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEmployed = table.Column<bool>(type: "bit", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Job_ListingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JOB_APPLICANT", x => x.Job_ApplicantId);
                    table.ForeignKey(
                        name: "FK_JOB_APPLICANT_JOB_LISTING_Job_ListingId",
                        column: x => x.Job_ListingId,
                        principalTable: "JOB_LISTING",
                        principalColumn: "Job_ListingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JOB_APPLICANT_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COMPANY_UserId",
                table: "COMPANY",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JOB_APPLICANT_Job_ListingId",
                table: "JOB_APPLICANT",
                column: "Job_ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_JOB_APPLICANT_UserId",
                table: "JOB_APPLICANT",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JOB_LISTING_CompanyId",
                table: "JOB_LISTING",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_User_TypeId",
                table: "USER",
                column: "User_TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JOB_APPLICANT");

            migrationBuilder.DropTable(
                name: "JOB_LISTING");

            migrationBuilder.DropTable(
                name: "COMPANY");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "USER_TYPE");
        }
    }
}
