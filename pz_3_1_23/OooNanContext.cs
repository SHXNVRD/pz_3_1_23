using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace pz_3_1_23;

public partial class OooNanContext : DbContext
{
    public OooNanContext()
    {
    }

    public OooNanContext(DbContextOptions<OooNanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Consignment> Consignments { get; set; }

    public virtual DbSet<DeliveryMethod> DeliveryMethods { get; set; }

    public virtual DbSet<Employe> Employes { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //var builder = new ConfigurationBuilder()
        //    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //    .AddJsonFile("appsettings.json");
        //var configuration = builder.Build();
        //var connectionString = configuration.GetConnectionString("DefaultConnection");

        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false).Build();

        optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Client__3214EC27BA966471");

            entity.ToTable("Client", tb => tb.HasTrigger("InsteadOfInsertClient"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Addres).HasMaxLength(150);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Consignment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Consignm__3214EC27FB31D1F4");

            entity.ToTable("Consignment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.PoductId).HasColumnName("Poduct_ID");

            entity.HasOne(d => d.Poduct).WithMany(p => p.Consignments)
                .HasForeignKey(d => d.PoductId)
                .HasConstraintName("FK__Consignme__Poduc__7C4F7684");
        });

        modelBuilder.Entity<DeliveryMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Delivery__3214EC27BDE76FBC");

            entity.ToTable("Delivery_method");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Method).HasMaxLength(50);
        });

        modelBuilder.Entity<Employe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employe__3214EC274B84EC00");

            entity.ToTable("Employe");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.JobId).HasColumnName("Job_ID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("money");

            entity.HasOne(d => d.Job).WithMany(p => p.Employes)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK__Employe__Job_ID__75A278F5");
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
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Title).HasMaxLength(100);
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

        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
