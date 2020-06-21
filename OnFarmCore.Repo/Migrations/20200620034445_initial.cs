using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnFarmCore.Repo.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID_CLIENTE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NM_CLIENTE = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    CEP = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    RUA = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    NUMERO = table.Column<int>(nullable: true),
                    BAIRRO = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    CIDADE = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    COMPLEMENTO = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    TELEFONE = table.Column<string>(unicode: false, maxLength: 18, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ID_CLIENTE);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    ID_PEDIDO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_CLIENTE = table.Column<int>(nullable: true),
                    COD_RASTREIO = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    DT_CRIACAO = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.ID_PEDIDO);
                    table.ForeignKey(
                        name: "FK__Pedidos__ID_CLIE__2A4B4B5E",
                        column: x => x.ID_CLIENTE,
                        principalTable: "Clientes",
                        principalColumn: "ID_CLIENTE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ID_CLIENTE",
                table: "Pedidos",
                column: "ID_CLIENTE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
