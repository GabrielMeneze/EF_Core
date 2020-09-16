using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_Core.Migrations
{
    public partial class EF_Core : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    OverDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Preco = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PedidosItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPedido = table.Column<Guid>(nullable: false),
                    PedidoId = table.Column<Guid>(nullable: true),
                    IdProduto = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosItems_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidosItems_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidosItems_PedidoId",
                table: "PedidosItems",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosItems_ProdutoId",
                table: "PedidosItems",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidosItems");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
