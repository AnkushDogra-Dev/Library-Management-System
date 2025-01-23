using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.BorrowersRecord.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "br");

            migrationBuilder.CreateTable(
                name: "Borrowers",
                schema: "br",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MembershipType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LibraryCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuedBooksCount = table.Column<int>(type: "int", nullable: false),
                    OverdueFineBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowers", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Borrowers",
                schema: "br");
        }
    }
}
