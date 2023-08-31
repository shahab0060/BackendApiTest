using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendApiTest.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Family = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LatestEditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditCounts = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LatestEditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditCounts = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "CreateDate", "DeletedOn", "EditCounts", "Family", "IsDelete", "LatestEditDate", "Name" },
                values: new object[] { 1L, new DateTime(2023, 8, 31, 13, 17, 3, 992, DateTimeKind.Local).AddTicks(4448), null, 0, "Bakhtiari", false, new DateTime(2023, 8, 31, 13, 17, 3, 992, DateTimeKind.Local).AddTicks(4458), "shahab" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "CreateDate", "DeletedOn", "EditCounts", "IsDelete", "LatestEditDate", "PersonId", "Price" },
                values: new object[] { 1L, new DateTime(2023, 8, 31, 13, 17, 3, 992, DateTimeKind.Local).AddTicks(4589), null, 1, false, new DateTime(2023, 8, 31, 13, 17, 3, 992, DateTimeKind.Local).AddTicks(4590), 1L, 1000 });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PersonId",
                table: "Transactions",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
