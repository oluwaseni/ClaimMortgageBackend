using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ForUserRegistration.Migrations
{
    public partial class mortgaged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertyMortgage",
                columns: table => new
                {
                    PropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LandOwnerName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PropertyType = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PercentageMortgaged = table.Column<int>(nullable: false),
                    BankMortgaging = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NatureOfDeeds = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Registered = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Volume = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Page = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    PlanNumber = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ReceiptNumber = table.Column<string>(type: "varchar(16)", nullable: false),
                    FileReference = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    SerialNumber = table.Column<string>(type: "varchar(16)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyMortgage", x => x.PropertyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyMortgage");
        }
    }
}
