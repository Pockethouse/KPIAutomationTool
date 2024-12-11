using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXCELGRAPHING.Migrations
{
    /// <inheritdoc />
    public partial class AddPayableAndReceivablePayments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PayablePayment",
                columns: table => new
                {
                    PayablePaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProviderID = table.Column<int>(type: "int", nullable: false),
                    PaymentID = table.Column<int>(type: "int", nullable: false),
                    PayableAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PayableDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayablePayment", x => x.PayablePaymentID);
                    table.ForeignKey(
                        name: "FK_PayablePayment_Payments_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payments",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayablePayment_Providers_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "Providers",
                        principalColumn: "ProviderID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReceivablePayment",
                columns: table => new
                {
                    ReceivablePaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BankID = table.Column<int>(type: "int", nullable: false),
                    PaymentID = table.Column<int>(type: "int", nullable: false),
                    ReceivableAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ReceivableDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivablePayment", x => x.ReceivablePaymentID);
                    table.ForeignKey(
                        name: "FK_ReceivablePayment_Banks_BankID",
                        column: x => x.BankID,
                        principalTable: "Banks",
                        principalColumn: "BankID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceivablePayment_Payments_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payments",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PayablePayment_PaymentID",
                table: "PayablePayment",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_PayablePayment_ProviderID",
                table: "PayablePayment",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivablePayment_BankID",
                table: "ReceivablePayment",
                column: "BankID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivablePayment_PaymentID",
                table: "ReceivablePayment",
                column: "PaymentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayablePayment");

            migrationBuilder.DropTable(
                name: "ReceivablePayment");
        }
    }
}
