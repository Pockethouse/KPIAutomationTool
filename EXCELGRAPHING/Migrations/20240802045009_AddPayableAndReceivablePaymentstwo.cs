using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXCELGRAPHING.Migrations
{
    /// <inheritdoc />
    public partial class AddPayableAndReceivablePaymentstwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayablePayment_Payments_PaymentID",
                table: "PayablePayment");

            migrationBuilder.DropForeignKey(
                name: "FK_PayablePayment_Providers_ProviderID",
                table: "PayablePayment");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivablePayment_Banks_BankID",
                table: "ReceivablePayment");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivablePayment_Payments_PaymentID",
                table: "ReceivablePayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceivablePayment",
                table: "ReceivablePayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PayablePayment",
                table: "PayablePayment");

            migrationBuilder.RenameTable(
                name: "ReceivablePayment",
                newName: "ReceivablePayments");

            migrationBuilder.RenameTable(
                name: "PayablePayment",
                newName: "PayablePayments");

            migrationBuilder.RenameIndex(
                name: "IX_ReceivablePayment_PaymentID",
                table: "ReceivablePayments",
                newName: "IX_ReceivablePayments_PaymentID");

            migrationBuilder.RenameIndex(
                name: "IX_ReceivablePayment_BankID",
                table: "ReceivablePayments",
                newName: "IX_ReceivablePayments_BankID");

            migrationBuilder.RenameIndex(
                name: "IX_PayablePayment_ProviderID",
                table: "PayablePayments",
                newName: "IX_PayablePayments_ProviderID");

            migrationBuilder.RenameIndex(
                name: "IX_PayablePayment_PaymentID",
                table: "PayablePayments",
                newName: "IX_PayablePayments_PaymentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceivablePayments",
                table: "ReceivablePayments",
                column: "ReceivablePaymentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PayablePayments",
                table: "PayablePayments",
                column: "PayablePaymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_PayablePayments_Payments_PaymentID",
                table: "PayablePayments",
                column: "PaymentID",
                principalTable: "Payments",
                principalColumn: "PaymentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PayablePayments_Providers_ProviderID",
                table: "PayablePayments",
                column: "ProviderID",
                principalTable: "Providers",
                principalColumn: "ProviderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivablePayments_Banks_BankID",
                table: "ReceivablePayments",
                column: "BankID",
                principalTable: "Banks",
                principalColumn: "BankID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivablePayments_Payments_PaymentID",
                table: "ReceivablePayments",
                column: "PaymentID",
                principalTable: "Payments",
                principalColumn: "PaymentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayablePayments_Payments_PaymentID",
                table: "PayablePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_PayablePayments_Providers_ProviderID",
                table: "PayablePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivablePayments_Banks_BankID",
                table: "ReceivablePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivablePayments_Payments_PaymentID",
                table: "ReceivablePayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceivablePayments",
                table: "ReceivablePayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PayablePayments",
                table: "PayablePayments");

            migrationBuilder.RenameTable(
                name: "ReceivablePayments",
                newName: "ReceivablePayment");

            migrationBuilder.RenameTable(
                name: "PayablePayments",
                newName: "PayablePayment");

            migrationBuilder.RenameIndex(
                name: "IX_ReceivablePayments_PaymentID",
                table: "ReceivablePayment",
                newName: "IX_ReceivablePayment_PaymentID");

            migrationBuilder.RenameIndex(
                name: "IX_ReceivablePayments_BankID",
                table: "ReceivablePayment",
                newName: "IX_ReceivablePayment_BankID");

            migrationBuilder.RenameIndex(
                name: "IX_PayablePayments_ProviderID",
                table: "PayablePayment",
                newName: "IX_PayablePayment_ProviderID");

            migrationBuilder.RenameIndex(
                name: "IX_PayablePayments_PaymentID",
                table: "PayablePayment",
                newName: "IX_PayablePayment_PaymentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceivablePayment",
                table: "ReceivablePayment",
                column: "ReceivablePaymentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PayablePayment",
                table: "PayablePayment",
                column: "PayablePaymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_PayablePayment_Payments_PaymentID",
                table: "PayablePayment",
                column: "PaymentID",
                principalTable: "Payments",
                principalColumn: "PaymentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PayablePayment_Providers_ProviderID",
                table: "PayablePayment",
                column: "ProviderID",
                principalTable: "Providers",
                principalColumn: "ProviderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivablePayment_Banks_BankID",
                table: "ReceivablePayment",
                column: "BankID",
                principalTable: "Banks",
                principalColumn: "BankID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivablePayment_Payments_PaymentID",
                table: "ReceivablePayment",
                column: "PaymentID",
                principalTable: "Payments",
                principalColumn: "PaymentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
