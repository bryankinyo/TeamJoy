using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_InventorySystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovementTypes",
                columns: table => new
                {
                    MovementTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MovementTypeName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementTypes", x => x.MovementTypeID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.StatusID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SupplierName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactPerson = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SalesOrders",
                columns: table => new
                {
                    SalesOrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrders", x => x.SalesOrderID);
                    table.ForeignKey(
                        name: "FK_SalesOrders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrders_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrders_OrderStatuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "OrderStatuses",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    PurchaseOrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.PurchaseOrderID);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_OrderStatuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "OrderStatuses",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SalesOrderID = table.Column<int>(type: "int", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payments_OrderStatuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "OrderStatuses",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_SalesOrders_SalesOrderID",
                        column: x => x.SalesOrderID,
                        principalTable: "SalesOrders",
                        principalColumn: "SalesOrderID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SalesOrderDetails",
                columns: table => new
                {
                    SalesOrderDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SalesOrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderDetails", x => x.SalesOrderDetailID);
                    table.ForeignKey(
                        name: "FK_SalesOrderDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderDetails_SalesOrders_SalesOrderID",
                        column: x => x.SalesOrderID,
                        principalTable: "SalesOrders",
                        principalColumn: "SalesOrderID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PurchaseOrderDetails",
                columns: table => new
                {
                    PurchaseOrderDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PurchaseOrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderDetails", x => x.PurchaseOrderDetailID);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetails_PurchaseOrders_PurchaseOrderID",
                        column: x => x.PurchaseOrderID,
                        principalTable: "PurchaseOrders",
                        principalColumn: "PurchaseOrderID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InventoryMovements",
                columns: table => new
                {
                    InventoryMovementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    QuantityChanged = table.Column<int>(type: "int", nullable: false),
                    MovementTypeID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MovementReason = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SalesOrderDetailID = table.Column<int>(type: "int", nullable: true),
                    PurchaseOrderDetailID = table.Column<int>(type: "int", nullable: true),
                    MovementDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryMovements", x => x.InventoryMovementID);
                    table.ForeignKey(
                        name: "FK_InventoryMovements_MovementTypes_MovementTypeID",
                        column: x => x.MovementTypeID,
                        principalTable: "MovementTypes",
                        principalColumn: "MovementTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryMovements_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryMovements_PurchaseOrderDetails_PurchaseOrderDetailID",
                        column: x => x.PurchaseOrderDetailID,
                        principalTable: "PurchaseOrderDetails",
                        principalColumn: "PurchaseOrderDetailID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_InventoryMovements_SalesOrderDetails_SalesOrderDetailID",
                        column: x => x.SalesOrderDetailID,
                        principalTable: "SalesOrderDetails",
                        principalColumn: "SalesOrderDetailID",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_MovementTypeID",
                table: "InventoryMovements",
                column: "MovementTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_ProductID",
                table: "InventoryMovements",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_PurchaseOrderDetailID",
                table: "InventoryMovements",
                column: "PurchaseOrderDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_SalesOrderDetailID",
                table: "InventoryMovements",
                column: "SalesOrderDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_SalesOrderID",
                table: "Payments",
                column: "SalesOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_StatusID",
                table: "Payments",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderDetails_ProductID",
                table: "PurchaseOrderDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderDetails_PurchaseOrderID",
                table: "PurchaseOrderDetails",
                column: "PurchaseOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_EmployeeID",
                table: "PurchaseOrders",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_StatusID",
                table: "PurchaseOrders",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_SupplierID",
                table: "PurchaseOrders",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderDetails_ProductID",
                table: "SalesOrderDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderDetails_SalesOrderID",
                table: "SalesOrderDetails",
                column: "SalesOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_CustomerID",
                table: "SalesOrders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_EmployeeID",
                table: "SalesOrders",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_StatusID",
                table: "SalesOrders",
                column: "StatusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryMovements");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "MovementTypes");

            migrationBuilder.DropTable(
                name: "PurchaseOrderDetails");

            migrationBuilder.DropTable(
                name: "SalesOrderDetails");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SalesOrders");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "OrderStatuses");
        }
    }
}
