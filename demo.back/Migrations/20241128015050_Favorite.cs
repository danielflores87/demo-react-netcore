using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace demo.back.Migrations
{
    /// <inheritdoc />
    public partial class Favorite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FAU_FAVORITOS_USUARIO",
                columns: table => new
                {
                    FAU_CODIGO = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FAU_CODUSR_USUARIO = table.Column<int>(type: "integer", nullable: false),
                    FAU_TITULO = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    FAU_CODE_COMIC = table.Column<int>(type: "integer", nullable: false),
                    FAU_FECHA = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAU_FAVORITOS_USUARIO", x => x.FAU_CODIGO);
                    table.ForeignKey(
                        name: "FK_FAU_FAVORITOS_USUARIO_USR_USUARIOS_FAU_CODUSR_USUARIO",
                        column: x => x.FAU_CODUSR_USUARIO,
                        principalTable: "USR_USUARIOS",
                        principalColumn: "USR_CODIGO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FAU_FAVORITOS_USUARIO_FAU_CODUSR_USUARIO",
                table: "FAU_FAVORITOS_USUARIO",
                column: "FAU_CODUSR_USUARIO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FAU_FAVORITOS_USUARIO");
        }
    }
}
