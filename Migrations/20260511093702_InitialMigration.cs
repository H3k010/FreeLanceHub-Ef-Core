using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfcCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AgencyFreelancers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP"),
                    Agency_Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Agency_Contact_Email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    Address_Street = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Address_City = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Address_Country = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyFreelancers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Address_Street = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Address_City = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Address_Country = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IndpendentFreelancers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP"),
                    HourlyRate = table.Column<int>(type: "int", nullable: false),
                    Availability = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Address_Street = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Address_City = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Address_Country = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndpendentFreelancers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Skill_Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FreelancerSkills",
                columns: table => new
                {
                    FreelancerId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    Proficiency = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelancerSkills", x => new { x.FreelancerId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_FreelancerSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    Rate_Type = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    MoneyAmount_Amount = table.Column<decimal>(type: "decimal(15,3)", precision: 15, scale: 3, nullable: false),
                    MoneyAmount_Currency = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    MoneyAmount_Amount = table.Column<decimal>(type: "decimal(15,3)", precision: 15, scale: 3, nullable: false),
                    MoneyAmount_Currency = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProjectFreelancer",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    FreelancerId = table.Column<int>(type: "int", nullable: false),
                    Hours_Allocated = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFreelancer", x => new { x.ProjectId, x.FreelancerId });
                    table.ForeignKey(
                        name: "FK_ProjectFreelancer_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AgencyFreelancers",
                columns: new[] { "Id", "Agency_Contact_Email", "Agency_Name", "Name", "Address_City", "Address_Country", "Address_Street" },
                values: new object[,]
                {
                    { 2, "Email2", "AgencyName2", "Name2", "City2", "Country2", "Street2" },
                    { 3, "Email3", "AgencyName3", "Name3", "City3", "Country3", "Street3" },
                    { 5, "Email5", "AgencyName5", "Name5", "City5", "Country5", "Street5" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "Name", "Address_City", "Address_Country", "Address_Street" },
                values: new object[,]
                {
                    { 1, "Email1", "Name1", "City1", "Country1", "Street1" },
                    { 2, "Email2", "Name2", "City2", "Country2", "Street2" },
                    { 3, "Email3", "Name3", "City3", "Country3", "Street3" },
                    { 4, "Email4", "Name4", "City4", "Country4", "Street4" },
                    { 5, "Email5", "Name5", "City5", "Country5", "Street5" }
                });

            migrationBuilder.InsertData(
                table: "IndpendentFreelancers",
                columns: new[] { "Id", "Availability", "HourlyRate", "Name", "Address_City", "Address_Country", "Address_Street" },
                values: new object[,]
                {
                    { 1, "Full_Time", 50, "Name1", "City1", "Country1", "Street1" },
                    { 4, "Part_Time", 60, "Name4", "City4", "Country4", "Street4" },
                    { 6, "Full_Time", 70, "Name6", "City6", "Country6", "Street6" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Skill_Name" },
                values: new object[,]
                {
                    { 1, "C# Development" },
                    { 2, "ASP.NET Core" },
                    { 3, "React.js" },
                    { 4, "SQL Server" },
                    { 5, "UI/UX Design" },
                    { 6, "DevOps" },
                    { 7, "Project Management" },
                    { 8, "Mobile App Development" }
                });

            migrationBuilder.InsertData(
                table: "FreelancerSkills",
                columns: new[] { "FreelancerId", "SkillId", "Proficiency" },
                values: new object[,]
                {
                    { 1, 1, "Expert" },
                    { 1, 2, "Advanced" },
                    { 2, 3, "Intermediate" },
                    { 3, 4, "Expert" },
                    { 4, 5, "Beginner" },
                    { 5, 6, "Advanced" },
                    { 6, 7, "Intermediate" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ClientId", "DeleteDate", "IsDeleted", "Status", "Title" },
                values: new object[,]
                {
                    { 1, 3, null, false, "Draft", "Title1" },
                    { 2, 5, null, false, "Overdue", "Title2" },
                    { 3, 4, null, false, "Sent", "Title3" },
                    { 4, 1, null, false, "Overdue", "Title4" },
                    { 5, 2, null, false, "Paid", "Title5" }
                });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "Id", "ProjectId", "Rate_Type", "MoneyAmount_Amount", "MoneyAmount_Currency" },
                values: new object[,]
                {
                    { 1, 4, "Hourly", 50.00m, "USD" },
                    { 2, 1, "Fixed", 5000.00m, "EUR" },
                    { 3, 3, "Fixed", 75.00m, "GBP" },
                    { 4, 2, "Hourly", 1200.00m, "USD" },
                    { 5, 5, "Hourly", 45.00m, "CAD" }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "DeleteDate", "IsDeleted", "ProjectId", "Status", "MoneyAmount_Amount", "MoneyAmount_Currency" },
                values: new object[,]
                {
                    { 1, null, false, 3, "Draft", 1500.00m, "USD" },
                    { 2, null, false, 1, "Paid", 250.50m, "EUR" },
                    { 3, null, false, 5, "Overdue", 3000.00m, "GBP" },
                    { 4, null, false, 4, "Sent", 450.00m, "USD" },
                    { 5, null, false, 2, "Paid", 1200.00m, "CAD" },
                    { 6, null, false, 1, "Draft", 85.00m, "USD" }
                });

            migrationBuilder.InsertData(
                table: "ProjectFreelancer",
                columns: new[] { "FreelancerId", "ProjectId", "Hours_Allocated", "Role" },
                values: new object[,]
                {
                    { 1, 1, 40, "Developer" },
                    { 2, 1, 20, "Project_Management" },
                    { 3, 2, 35, "Designer" },
                    { 1, 3, 10, "Markting" },
                    { 4, 3, 15, "Developer" },
                    { 5, 4, 50, "Project_Management" },
                    { 2, 5, 30, "Markting" },
                    { 6, 5, 25, "Developer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ProjectId",
                table: "Contracts",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FreelancerSkills_SkillId",
                table: "FreelancerSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_IsDeleted",
                table: "Invoices",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ProjectId",
                table: "Invoices",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFreelancer_FreelancerId",
                table: "ProjectFreelancer",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId",
                table: "Projects",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_IsDeleted",
                table: "Projects",
                column: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgencyFreelancers");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "FreelancerSkills");

            migrationBuilder.DropTable(
                name: "IndpendentFreelancers");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "ProjectFreelancer");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
