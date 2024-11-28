using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace demo.back.Migrations
{
    /// <inheritdoc />
    public partial class User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USR_USUARIOS",
                columns: table => new
                {
                    USR_CODIGO = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    USR_NUMERO_DOCUMENTO = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    USR_NOMBRE = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    USR_CORREO = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    USR_CLAVE_ACCESO = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USR_USUARIOS", x => x.USR_CODIGO);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USR_USUARIOS");
        }
    }
}
