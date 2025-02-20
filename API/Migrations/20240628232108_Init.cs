using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BalanceCorrections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CorrectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CorrectionAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalanceCorrections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BalanceCorrections_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FromAccountId = table.Column<int>(type: "int", nullable: true),
                    ToAccountId = table.Column<int>(type: "int", nullable: true),
                    TransactionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_FromAccountId",
                        column: x => x.FromAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_ToAccountId",
                        column: x => x.ToAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransactionRecurringInstances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecurringFrequency = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndAfterCount = table.Column<int>(type: "int", nullable: true),
                    TransactionAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionRecurringInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionRecurringInstances_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionSingleInstances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionSingleInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionSingleInstances_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BalanceCorrections_AccountId",
                table: "BalanceCorrections",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionRecurringInstances_TransactionId",
                table: "TransactionRecurringInstances",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FromAccountId",
                table: "Transactions",
                column: "FromAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ToAccountId",
                table: "Transactions",
                column: "ToAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionSingleInstances_TransactionId",
                table: "TransactionSingleInstances",
                column: "TransactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BalanceCorrections");

            migrationBuilder.DropTable(
                name: "TransactionRecurringInstances");

            migrationBuilder.DropTable(
                name: "TransactionSingleInstances");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
