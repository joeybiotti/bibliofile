using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bibliofile.Data.Migrations
{
    public partial class CollectedBooks_mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollectedBooks",
                columns: table => new
                {
                    CollectedBookId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Author = table.Column<string>(nullable: true),
                    BookId = table.Column<int>(nullable: false),
                    BooksCollectedBookId = table.Column<int>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectedBooks", x => x.CollectedBookId);
                    table.ForeignKey(
                        name: "FK_CollectedBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectedBooks_CollectedBooks_BooksCollectedBookId",
                        column: x => x.BooksCollectedBookId,
                        principalTable: "CollectedBooks",
                        principalColumn: "CollectedBookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CollectedBooks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectedBooks_BookId",
                table: "CollectedBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectedBooks_BooksCollectedBookId",
                table: "CollectedBooks",
                column: "BooksCollectedBookId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectedBooks_UserId",
                table: "CollectedBooks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectedBooks");
        }
    }
}
