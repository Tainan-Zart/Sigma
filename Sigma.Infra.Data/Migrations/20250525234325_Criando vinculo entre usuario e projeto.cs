using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sigma.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Criandovinculoentreusuarioeprojeto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "projetos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "classificacaorisco",
                table: "projetos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "datainicio",
                table: "projetos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dataprevisaotermino",
                table: "projetos",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "datatermino",
                table: "projetos",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "descricao",
                table: "projetos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "orcamento",
                table: "projetos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "usuarioid",
                table: "projetos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    login = table.Column<string>(type: "text", nullable: false),
                    senha = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usuarios", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_projetos_usuarioid",
                table: "projetos",
                column: "usuarioid");

            migrationBuilder.AddForeignKey(
                name: "fk_projetos_usuarios_usuarioid",
                table: "projetos",
                column: "usuarioid",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_projetos_usuarios_usuarioid",
                table: "projetos");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropIndex(
                name: "ix_projetos_usuarioid",
                table: "projetos");

            migrationBuilder.DropColumn(
                name: "classificacaorisco",
                table: "projetos");

            migrationBuilder.DropColumn(
                name: "datainicio",
                table: "projetos");

            migrationBuilder.DropColumn(
                name: "dataprevisaotermino",
                table: "projetos");

            migrationBuilder.DropColumn(
                name: "datatermino",
                table: "projetos");

            migrationBuilder.DropColumn(
                name: "descricao",
                table: "projetos");

            migrationBuilder.DropColumn(
                name: "orcamento",
                table: "projetos");

            migrationBuilder.DropColumn(
                name: "usuarioid",
                table: "projetos");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "projetos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
