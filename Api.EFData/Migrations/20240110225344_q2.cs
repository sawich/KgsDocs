using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.EFData.Migrations
{
    /// <inheritdoc />
    public partial class q2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentModelId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    State = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Familiarizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    State = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familiarizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discussions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<string>(type: "text", nullable: true),
                    PostedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DocumentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discussions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discussions_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Discussions_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DocumentModelId",
                table: "AspNetUsers",
                column: "DocumentModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Discussions_AuthorId",
                table: "Discussions",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Discussions_DocumentId",
                table: "Discussions",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Documents_DocumentModelId",
                table: "AspNetUsers",
                column: "DocumentModelId",
                principalTable: "Documents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Documents_DocumentModelId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Discussions");

            migrationBuilder.DropTable(
                name: "Familiarizations");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DocumentModelId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DocumentModelId",
                table: "AspNetUsers");
        }
    }
}
