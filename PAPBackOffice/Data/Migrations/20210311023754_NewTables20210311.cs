using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PAPBackOffice.Migrations
{
    public partial class NewTables20210311 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_PedidoComentario_PedidoComentarioId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_PedidoComentarioId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "PedidoComentarioId",
                table: "Pedido");

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "PedidoComentario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PedidoOrigemId",
                table: "Pedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Consultoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecoBase = table.Column<double>(type: "float", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaConsultoriaEstado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaConsultoriaEstado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FaturaEstado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaturaEstado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PedidoOrigem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoOrigem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaConsultoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    ConsultoriaId = table.Column<int>(type: "int", nullable: false),
                    EmpresaConsultoriaEstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaConsultoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpresaConsultoria_Consultoria_ConsultoriaId",
                        column: x => x.ConsultoriaId,
                        principalTable: "Consultoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaConsultoria_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaConsultoria_EmpresaConsultoriaEstado_EmpresaConsultoriaEstadoId",
                        column: x => x.EmpresaConsultoriaEstadoId,
                        principalTable: "EmpresaConsultoriaEstado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fatura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Serie = table.Column<int>(type: "int", nullable: false),
                    NumeroDocumento = table.Column<int>(type: "int", nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Desconto = table.Column<float>(type: "real", nullable: false),
                    IVA = table.Column<float>(type: "real", nullable: false),
                    FaturaEstadoId = table.Column<int>(type: "int", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fatura_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fatura_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fatura_FaturaEstado_FaturaEstadoId",
                        column: x => x.FaturaEstadoId,
                        principalTable: "FaturaEstado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FaturaLinha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaturaId = table.Column<int>(type: "int", nullable: false),
                    ConsultoriaId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaturaLinha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaturaLinha_Fatura_FaturaId",
                        column: x => x.FaturaId,
                        principalTable: "Fatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoComentario_PedidoId",
                table: "PedidoComentario",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_PedidoOrigemId",
                table: "Pedido",
                column: "PedidoOrigemId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaConsultoria_ConsultoriaId",
                table: "EmpresaConsultoria",
                column: "ConsultoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaConsultoria_EmpresaConsultoriaEstadoId",
                table: "EmpresaConsultoria",
                column: "EmpresaConsultoriaEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaConsultoria_EmpresaId",
                table: "EmpresaConsultoria",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Fatura_ColaboradorId",
                table: "Fatura",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Fatura_EmpresaId",
                table: "Fatura",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Fatura_FaturaEstadoId",
                table: "Fatura",
                column: "FaturaEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaLinha_FaturaId",
                table: "FaturaLinha",
                column: "FaturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_PedidoOrigem_PedidoOrigemId",
                table: "Pedido",
                column: "PedidoOrigemId",
                principalTable: "PedidoOrigem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoComentario_Pedido_PedidoId",
                table: "PedidoComentario",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_PedidoOrigem_PedidoOrigemId",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoComentario_Pedido_PedidoId",
                table: "PedidoComentario");

            migrationBuilder.DropTable(
                name: "EmpresaConsultoria");

            migrationBuilder.DropTable(
                name: "FaturaLinha");

            migrationBuilder.DropTable(
                name: "PedidoOrigem");

            migrationBuilder.DropTable(
                name: "Consultoria");

            migrationBuilder.DropTable(
                name: "EmpresaConsultoriaEstado");

            migrationBuilder.DropTable(
                name: "Fatura");

            migrationBuilder.DropTable(
                name: "FaturaEstado");

            migrationBuilder.DropIndex(
                name: "IX_PedidoComentario_PedidoId",
                table: "PedidoComentario");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_PedidoOrigemId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "PedidoComentario");

            migrationBuilder.DropColumn(
                name: "PedidoOrigemId",
                table: "Pedido");

            migrationBuilder.AddColumn<int>(
                name: "PedidoComentarioId",
                table: "Pedido",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_PedidoComentarioId",
                table: "Pedido",
                column: "PedidoComentarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_PedidoComentario_PedidoComentarioId",
                table: "Pedido",
                column: "PedidoComentarioId",
                principalTable: "PedidoComentario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
