using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OOO_NAN.Database;

public partial class OooNanContext : DbContext
{
    public OooNanContext()
    {
    }

    public OooNanContext(DbContextOptions<OooNanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<DeliveryMethod> DeliveryMethods { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeesAudit> EmployeesAudits { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderAnalytic> OrderAnalytics { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductDeliveryReport> ProductDeliveryReports { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Categories_ID");

            entity.HasIndex(e => e.Title, "UQ_Categories_Title").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Client__3214EC27BA966471");

            entity.ToTable("Client", tb => tb.HasTrigger("InsteadOfInsertClient"));

            entity.HasIndex(e => e.Email, "UQ_Client_Email").IsUnique();

            entity.HasIndex(e => e.Password, "UQ_Client_Password").IsUnique();

            entity.HasIndex(e => e.Phone, "UQ_Client_Phone").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Addres).HasMaxLength(150);
            entity.Property(e => e.DayOfBirth)
                .HasColumnType("date")
                .HasColumnName("Day_of_birth");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("TR_Update_Product_Count_On_Delivery"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.ManufacturersId).HasColumnName("Manufacturers_Id");
            entity.Property(e => e.ProductCount).HasColumnName("Product_count");
            entity.Property(e => e.ProductId).HasColumnName("Product_Id");

            entity.HasOne(d => d.Manufacturers).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.ManufacturersId)
                .HasConstraintName("FK_Deliveries_To_Manufacturers");

            entity.HasOne(d => d.Product).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Deliveries_To_Product");
        });

        modelBuilder.Entity<DeliveryMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Delivery__3214EC27BDE76FBC");

            entity.ToTable("Delivery_method");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Method).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employe__3214EC274B84EC00");

            entity.ToTable("Employee", tb => tb.HasTrigger("TR_Audit_Employees"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.JobId).HasColumnName("Job_ID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("money");

            entity.HasOne(d => d.Job).WithMany(p => p.Employees)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK__Employe__Job_ID__75A278F5");
        });

        modelBuilder.Entity<EmployeesAudit>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__Employee__EDBEC77961F4D35A");

            entity.ToTable("EmployeesAudit");

            entity.Property(e => e.AuditId).HasColumnName("Audit_Id");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");
            entity.Property(e => e.EmployeeJob).HasColumnName("Employee_job");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(50)
                .HasColumnName("Employee_name");
            entity.Property(e => e.EmployeePhone)
                .HasMaxLength(20)
                .HasColumnName("Employee_phone");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("Modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("Modified_date");
            entity.Property(e => e.MonthSalary)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("Month_salary");
            entity.Property(e => e.Operation)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__History__3214EC07BB312EAD");

            entity.ToTable("History", tb => tb.HasTrigger("HistoryDelete"));

            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Operation).HasMaxLength(200);
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Job__3214EC2735DEFD9D");

            entity.ToTable("Job");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC27CFC1D356");

            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClientId).HasColumnName("Client_ID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.DeliveryMethodId).HasColumnName("Delivery_method_ID");
            entity.Property(e => e.EmployeId).HasColumnName("Employe_ID");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.StatusId).HasColumnName("Status_ID");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Order__Client_ID__01142BA1");

            entity.HasOne(d => d.DeliveryMethod).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DeliveryMethodId)
                .HasConstraintName("FK__Order__Delivery___7F2BE32F");

            entity.HasOne(d => d.Employe).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeId)
                .HasConstraintName("FK__Order__Employe_I__00200768");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Order__Product_I__02084FDA");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__Status_ID__02FC7413");
        });

        modelBuilder.Entity<OrderAnalytic>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Order_Analytics");

            entity.Property(e => e.ClientName)
                .HasMaxLength(100)
                .HasColumnName("client_name");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(100)
                .HasColumnName("employee_name");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("order_date");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderPrice)
                .HasColumnType("money")
                .HasColumnName("order_price");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(50)
                .HasColumnName("order_status");
            entity.Property(e => e.ProductTitle)
                .HasMaxLength(100)
                .HasColumnName("product_title");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC2714214D59");

            entity.ToTable("Product", tb =>
                {
                    tb.HasTrigger("ProductDelete");
                    tb.HasTrigger("ProductInsert");
                    tb.HasTrigger("ProductUpdate");
                });

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoriesId).HasColumnName("Categories_Id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.ManufacturersId).HasColumnName("Manufacturers_Id");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Categories).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoriesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_To_Categories");

            entity.HasOne(d => d.Manufacturers).WithMany(p => p.Products)
                .HasForeignKey(d => d.ManufacturersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_To_Manufacturers");
        });

        modelBuilder.Entity<ProductDeliveryReport>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Product_Delivery_Report");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .HasColumnName("category_name");
            entity.Property(e => e.DeliveryDate)
                .HasColumnType("date")
                .HasColumnName("delivery_date");
            entity.Property(e => e.ManufacturerName)
                .HasMaxLength(100)
                .HasColumnName("manufacturer_name");
            entity.Property(e => e.ProductCount).HasColumnName("product_count");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .HasColumnName("product_name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Status__3214EC2742ECFD87");

            entity.ToTable("Status");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Status1)
                .HasMaxLength(50)
                .HasColumnName("Status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
