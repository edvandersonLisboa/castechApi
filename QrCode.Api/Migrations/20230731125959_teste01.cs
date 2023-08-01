using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QrCode.Api.Migrations
{
    public partial class teste01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: true),
                    Peso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodProduto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataExtracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Qrcode = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlQrCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certificados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodCertificado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlCertificado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Validade = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProdutoEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificados_Produtos_ProdutoEntityId",
                        column: x => x.ProdutoEntityId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificados_ProdutoEntityId",
                table: "Certificados",
                column: "ProdutoEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificados");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
