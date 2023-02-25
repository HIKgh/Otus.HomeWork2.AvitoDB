using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AvitoDbContext : DbContext
{
    private const string ConnectionString =
        "Host=localhost;Port=5432;Database=avito;Username=postgres;Password=12345678";
    
    public DbSet<Annoucement> Annoucements { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<ProductType> ProductTypes { get; set; }

    public DbSet<Seller> Sellers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Annoucement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("annoucement_pk");

            entity.ToTable("annoucement", tb => tb.HasComment("Объявление"));

            entity.Property(e => e.Id)
                .HasComment("Идентификатор")
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasComment("Описание")
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Headline)
                .HasComment("Заголовок")
                .HasColumnType("character varying")
                .HasColumnName("headline");
            entity.Property(e => e.IdProduct)
                .HasComment("Идентификатор товара")
                .HasColumnName("id_product");
            entity.Property(e => e.IdSeller)
                .HasComment("Идентификатор продавца")
                .HasColumnName("id_seller");
            entity.Property(e => e.IsClose)
                .HasComment("Закрыто")
                .HasColumnName("is_close");
            entity.Property(e => e.Price)
                .HasComment("Цена")
                .HasColumnName("price");
            entity.Property(e => e.PublishDatetime)
                .HasDefaultValueSql("now()")
                .HasComment("Дата и время")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("publish_datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.Annoucements)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("annoucement_product_fk");

            entity.HasOne(d => d.Seller).WithMany(p => p.Annoucements)
                .HasForeignKey(d => d.IdSeller)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("annoucement_seller_fk");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_pk");

            entity.ToTable("product", tb => tb.HasComment("Товар"));

            entity.HasIndex(e => e.Name, "product_name_idx");

            entity.Property(e => e.Id)
                .HasComment("Идентификатор")
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.IdProductType)
                .HasComment("Идентификатор типа товара")
                .HasColumnName("id_product_type");
            entity.Property(e => e.Name)
                .HasComment("Наименование")
                .HasColumnType("character varying")
                .HasColumnName("name");

            entity.HasOne(d => d.ProductType).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdProductType)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("product_product_type_fk");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_type_pk");

            entity.ToTable("product_type", tb => tb.HasComment("Тип товара"));

            entity.HasIndex(e => e.Name, "product_type_name_idx");

            entity.Property(e => e.Id)
                .HasComment("Идентификатор")
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasComment("Наименование")
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("seller_pk");

            entity.ToTable("seller", tb => tb.HasComment("Продавец"));

            entity.HasIndex(e => e.Name, "seller_name_idx");

            entity.Property(e => e.Id)
                .HasComment("Идентификатор")
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasComment("Адрес")
                .HasColumnType("character varying")
                .HasColumnName("address");
            entity.Property(e => e.Name)
                .HasComment("Наименование")
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasComment("Телефон")
                .HasColumnType("character varying")
                .HasColumnName("phone");
        });
        modelBuilder.HasSequence("annoucement_id_seq").HasMax(2147483647L);
        modelBuilder.HasSequence("product_id_seq").HasMax(2147483647L);
        modelBuilder.HasSequence("product_type_id_seq").HasMax(2147483647L);
        modelBuilder.HasSequence("seller_id_seq").HasMax(2147483647L);
    }
}
