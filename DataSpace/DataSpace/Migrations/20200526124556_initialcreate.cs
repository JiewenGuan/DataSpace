using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataSpace.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpRoles",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    RoleDescription = table.Column<string>(nullable: false),
                    DateOfSubmission = table.Column<DateTime>(nullable: false),
                    EvaluationStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpRoles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    ABN = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    DateOfSubmission = table.Column<DateTime>(nullable: false),
                    EvaluationStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.ABN);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    PlatformID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Discription = table.Column<string>(nullable: true),
                    DateOfSubmission = table.Column<DateTime>(nullable: false),
                    EvaluationStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.PlatformID);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    FamilyName = table.Column<string>(nullable: false),
                    Affiliation = table.Column<string>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    InstitutionID = table.Column<string>(nullable: true),
                    DateOfSubmission = table.Column<DateTime>(nullable: false),
                    EvaluationStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_People_Institutions_InstitutionID",
                        column: x => x.InstitutionID,
                        principalTable: "Institutions",
                        principalColumn: "ABN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    MissionID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Commancement = table.Column<DateTime>(nullable: false),
                    Conclusion = table.Column<DateTime>(nullable: false),
                    PlatformID = table.Column<int>(nullable: false),
                    DateOfSubmission = table.Column<DateTime>(nullable: false),
                    EvaluationStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.MissionID);
                    table.ForeignKey(
                        name: "FK_Missions_Platforms_PlatformID",
                        column: x => x.PlatformID,
                        principalTable: "Platforms",
                        principalColumn: "PlatformID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    LoginID = table.Column<string>(maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 64, nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    PersonID = table.Column<int>(nullable: false),
                    BadAttempt = table.Column<int>(nullable: false),
                    LastBadLogin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.LoginID);
                    table.ForeignKey(
                        name: "FK_Logins_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experiments",
                columns: table => new
                {
                    ExperimentID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfSubmission = table.Column<DateTime>(nullable: false),
                    EvaluationStatus = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    TOA = table.Column<int>(nullable: false),
                    Aim = table.Column<string>(nullable: false),
                    Objective = table.Column<string>(nullable: false),
                    Summary = table.Column<string>(nullable: false),
                    ModuleDrawing = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ExperimentDate = table.Column<DateTime>(nullable: false),
                    FeildOfResearch = table.Column<string>(nullable: false),
                    SocialEconomicObjective = table.Column<string>(nullable: false),
                    LeadInstitutionID = table.Column<string>(nullable: false),
                    MissionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiments", x => x.ExperimentID);
                    table.ForeignKey(
                        name: "FK_Experiments_People_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "People",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Experiments_Institutions_LeadInstitutionID",
                        column: x => x.LeadInstitutionID,
                        principalTable: "Institutions",
                        principalColumn: "ABN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Experiments_Missions_MissionID",
                        column: x => x.MissionID,
                        principalTable: "Missions",
                        principalColumn: "MissionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participations",
                columns: table => new
                {
                    ParticipateID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonID = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false),
                    ExperimentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participations", x => x.ParticipateID);
                    table.ForeignKey(
                        name: "FK_Participations_Experiments_ExperimentID",
                        column: x => x.ExperimentID,
                        principalTable: "Experiments",
                        principalColumn: "ExperimentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participations_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participations_ExpRoles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "ExpRoles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResultDatasets",
                columns: table => new
                {
                    DatasetID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    RepoUrl = table.Column<string>(nullable: false),
                    ExperimentID = table.Column<int>(nullable: false),
                    DateOfSubmission = table.Column<DateTime>(nullable: false),
                    EvaluationStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultDatasets", x => x.DatasetID);
                    table.ForeignKey(
                        name: "FK_ResultDatasets_Experiments_ExperimentID",
                        column: x => x.ExperimentID,
                        principalTable: "Experiments",
                        principalColumn: "ExperimentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Experiments_AuthorId",
                table: "Experiments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiments_LeadInstitutionID",
                table: "Experiments",
                column: "LeadInstitutionID");

            migrationBuilder.CreateIndex(
                name: "IX_Experiments_MissionID",
                table: "Experiments",
                column: "MissionID");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_PersonID",
                table: "Logins",
                column: "PersonID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Missions_PlatformID",
                table: "Missions",
                column: "PlatformID");

            migrationBuilder.CreateIndex(
                name: "IX_Participations_ExperimentID",
                table: "Participations",
                column: "ExperimentID");

            migrationBuilder.CreateIndex(
                name: "IX_Participations_PersonID",
                table: "Participations",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Participations_RoleID",
                table: "Participations",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_People_InstitutionID",
                table: "People",
                column: "InstitutionID");

            migrationBuilder.CreateIndex(
                name: "IX_ResultDatasets_ExperimentID",
                table: "ResultDatasets",
                column: "ExperimentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Participations");

            migrationBuilder.DropTable(
                name: "ResultDatasets");

            migrationBuilder.DropTable(
                name: "ExpRoles");

            migrationBuilder.DropTable(
                name: "Experiments");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "Institutions");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}
