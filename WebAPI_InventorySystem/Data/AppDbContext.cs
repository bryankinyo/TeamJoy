using Microsoft.EntityFrameworkCore;
using WebAPI_InventorySystem.Models;

namespace WebAPI_InventorySystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<MovementType> MovementTypes { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<InventoryMovement> InventoryMovements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // OrderStatus Configuration
            modelBuilder.Entity<OrderStatus>()
                .HasKey(os => os.StatusID);

            // Product - Category Relationship
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryID)
                .OnDelete(DeleteBehavior.SetNull);

            // SalesOrder Relationships
            modelBuilder.Entity<SalesOrder>()
                .HasOne(so => so.Customer)
                .WithMany()
                .HasForeignKey(so => so.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SalesOrder>()
                .HasOne(so => so.Employee)
                .WithMany()
                .HasForeignKey(so => so.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SalesOrder>()
                .HasOne(so => so.Status)
                .WithMany()
                .HasForeignKey(so => so.StatusID)
                .OnDelete(DeleteBehavior.Restrict);

            // PurchaseOrder Relationships
            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(po => po.Supplier)
                .WithMany()
                .HasForeignKey(po => po.SupplierID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(po => po.Employee)
                .WithMany()
                .HasForeignKey(po => po.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(po => po.Status)
                .WithMany()
                .HasForeignKey(po => po.StatusID)
                .OnDelete(DeleteBehavior.Restrict);

            // SalesOrderDetail Relationships
            modelBuilder.Entity<SalesOrderDetail>()
                .HasOne(sod => sod.SalesOrder)
                .WithMany()
                .HasForeignKey(sod => sod.SalesOrderID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SalesOrderDetail>()
                .HasOne(sod => sod.Product)
                .WithMany()
                .HasForeignKey(sod => sod.ProductID)
                .OnDelete(DeleteBehavior.Restrict);

            // PurchaseOrderDetail Relationships
            modelBuilder.Entity<PurchaseOrderDetail>()
                .HasOne(pod => pod.PurchaseOrder)
                .WithMany()
                .HasForeignKey(pod => pod.PurchaseOrderID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .HasOne(pod => pod.Product)
                .WithMany()
                .HasForeignKey(pod => pod.ProductID)
                .OnDelete(DeleteBehavior.Restrict);

            // Payment Relationships
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.SalesOrder)
                .WithMany()
                .HasForeignKey(p => p.SalesOrderID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Status)
                .WithMany()
                .HasForeignKey(p => p.StatusID)
                .OnDelete(DeleteBehavior.Restrict);

            // InventoryMovement Relationships
            modelBuilder.Entity<InventoryMovement>()
                .HasOne(im => im.Product)
                .WithMany()
                .HasForeignKey(im => im.ProductID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InventoryMovement>()
                .HasOne(im => im.MovementType)
                .WithMany()
                .HasForeignKey(im => im.MovementTypeID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InventoryMovement>()
                .HasOne(im => im.SalesOrderDetail)
                .WithMany()
                .HasForeignKey(im => im.SalesOrderDetailID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<InventoryMovement>()
                .HasOne(im => im.PurchaseOrderDetail)
                .WithMany()
                .HasForeignKey(im => im.PurchaseOrderDetailID)
                .OnDelete(DeleteBehavior.SetNull);

            // Configure decimal properties for money
            modelBuilder.Entity<Product>()
                .Property(p => p.UnitPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<SalesOrder>()
                .Property(so => so.TotalAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PurchaseOrder>()
                .Property(po => po.TotalAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(sod => sod.UnitPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(sod => sod.SubTotal)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(sod => sod.TotalPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PurchaseOrderDetail>()
                .Property(pod => pod.UnitPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PurchaseOrderDetail>()
                .Property(pod => pod.SubTotal)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PurchaseOrderDetail>()
                .Property(pod => pod.TotalPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Payment>()
                .Property(p => p.AmountPaid)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }
    }
}