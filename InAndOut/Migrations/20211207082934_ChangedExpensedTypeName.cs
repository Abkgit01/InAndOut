using Microsoft.EntityFrameworkCore.Migrations;

namespace InAndOut.Migrations
{
    public partial class ChangedExpensedTypeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpensesType_ExpensesTypeId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpensesType",
                table: "ExpensesType");

            migrationBuilder.RenameTable(
                name: "ExpensesType",
                newName: "ExpensesTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpensesTypes",
                table: "ExpensesTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpensesTypes_ExpensesTypeId",
                table: "Expenses",
                column: "ExpensesTypeId",
                principalTable: "ExpensesTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpensesTypes_ExpensesTypeId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpensesTypes",
                table: "ExpensesTypes");

            migrationBuilder.RenameTable(
                name: "ExpensesTypes",
                newName: "ExpensesType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpensesType",
                table: "ExpensesType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpensesType_ExpensesTypeId",
                table: "Expenses",
                column: "ExpensesTypeId",
                principalTable: "ExpensesType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
