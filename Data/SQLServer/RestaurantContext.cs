using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data.SQLServer;

public partial class RestaurantContext : DbContext
{
    public RestaurantContext()
    {
    }

    public RestaurantContext(DbContextOptions<RestaurantContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppInfo> AppInfos { get; set; }

    public virtual DbSet<DictioaryEntry> DictioaryEntries { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<LanguageCode> LanguageCodes { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuDetail> MenuDetails { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Seating> Seatings { get; set; }

    public virtual DbSet<ServiceStatus> ServiceStatuses { get; set; }

    public virtual DbSet<State> States { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=YUMITIN;Initial Catalog=Restaurant;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AppInfo");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastUpdate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Version)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DictioaryEntry>(entity =>
        {
            entity.HasKey(e => new { e.UniqueCode, e.LanguageCode }).HasName("PK_Dictionnary");

            entity.ToTable("DictioaryEntry");

            entity.Property(e => e.UniqueCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LanguageCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Value).HasMaxLength(1000);

            entity.HasOne(d => d.LanguageCodeNavigation).WithMany(p => p.DictioaryEntries)
                .HasForeignKey(d => d.LanguageCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LanguageCode_Dictionnary");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("Item");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasComputedColumnSql("([Code]+'D')", false);
            entity.Property(e => e.Name)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasComputedColumnSql("([Code]+'N')", false);
            entity.Property(e => e.State).HasDefaultValue((byte)1, "DF_Item_ItemStatus");

            entity.HasOne(d => d.StateNavigation).WithMany(p => p.Items)
                .HasForeignKey(d => d.State)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Item_State");
        });

        modelBuilder.Entity<LanguageCode>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK_LanguageCode_1");

            entity.ToTable("LanguageCode");

            entity.Property(e => e.Code)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.ToTable("Menu");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasComputedColumnSql("([Code]+'D')", false);
            entity.Property(e => e.Name)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasComputedColumnSql("([Code]+'N')", false);
            entity.Property(e => e.State).HasDefaultValue((byte)1, "DF_Menu_State");

            entity.HasOne(d => d.StateNavigation).WithMany(p => p.Menus)
                .HasForeignKey(d => d.State)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Menu_State");
        });

        modelBuilder.Entity<MenuDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MenuItem");

            entity.ToTable("MenuDetail");

            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.Item).WithMany(p => p.MenuDetails)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MenuDetail_Item");

            entity.HasOne(d => d.Menu).WithMany(p => p.MenuDetails)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MenuDetail_Menu");

            entity.HasOne(d => d.StateNavigation).WithMany(p => p.MenuDetails)
                .HasForeignKey(d => d.State)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MenuDetail_State");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Date).HasDefaultValueSql("(current_date)", "DF_Order_Date");

            entity.HasOne(d => d.Seating).WithMany(p => p.Orders)
                .HasForeignKey(d => d.SeatingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Seating");

            entity.HasOne(d => d.ServiceStatusNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ServiceStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_ServiceStatus");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.ToTable("OrderDetail");

            entity.Property(e => e.SpecialInstruction).HasMaxLength(255);

            entity.HasOne(d => d.MenuDetail).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.MenuDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetail_MenuDetail");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetail_Order");

            entity.HasOne(d => d.ServiceStatusNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ServiceStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetail_ServiceStatus");
        });

        modelBuilder.Entity<Seating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Table");

            entity.ToTable("Seating");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaxSeat).HasDefaultValue((byte)1, "DF_Table_NumberOfSeat");
            entity.Property(e => e.Name)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasComputedColumnSql("([Code]+'N')", false);

            entity.HasOne(d => d.ServiceStatusNavigation).WithMany(p => p.Seatings)
                .HasForeignKey(d => d.ServiceStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seating_ServiceStatus");
        });

        modelBuilder.Entity<ServiceStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ServiceStatus_1");

            entity.ToTable("ServiceStatus");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ItemStatus");

            entity.ToTable("State");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
