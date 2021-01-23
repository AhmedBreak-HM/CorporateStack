using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "POCOs",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<byte[]>(nullable: true),
                    Photo = table.Column<byte[]>(nullable: true),
                    CV = table.Column<string>(nullable: true),
                    DateofBirth = table.Column<DateTime>(nullable: false),
                    Married = table.Column<bool>(nullable: false),
                    SupervisorID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POCOs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_POCOs_POCOs_SupervisorID",
                        column: x => x.SupervisorID,
                        principalTable: "POCOs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "POCOLanguages",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    POCOIdFK = table.Column<Guid>(nullable: false),
                    LanguageIdFK = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POCOLanguages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_POCOLanguages_Languages_LanguageIdFK",
                        column: x => x.LanguageIdFK,
                        principalTable: "Languages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_POCOLanguages_POCOs_POCOIdFK",
                        column: x => x.POCOIdFK,
                        principalTable: "POCOs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "ID", "Name" },
                values: new object[] { new Guid("a4a20724-0c0f-4893-a2ff-5cb065db7fdd"), "Arabic" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "ID", "Name" },
                values: new object[] { new Guid("aa10ce14-601b-4ac3-8854-30aa99172fe6"), "English" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "ID", "Name" },
                values: new object[] { new Guid("e67a69e5-d5fd-4261-915e-3b1d65974f45"), "French" });

            migrationBuilder.CreateIndex(
                name: "IX_POCOLanguages_LanguageIdFK",
                table: "POCOLanguages",
                column: "LanguageIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_POCOLanguages_POCOIdFK",
                table: "POCOLanguages",
                column: "POCOIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_POCOs_SupervisorID",
                table: "POCOs",
                column: "SupervisorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "POCOLanguages");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "POCOs");
        }
    }
}
