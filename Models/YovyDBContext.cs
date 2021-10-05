using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace YovyInventario.Models
{
    public partial class YovyDBContext : DbContext
    {
        public YovyDBContext()
        {
        }

        public YovyDBContext(DbContextOptions<YovyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Inventario> Inventarios { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Ventum> Venta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.IdInventario);

                entity.ToTable("Inventario");

                entity.Property(e => e.IdInventario).HasColumnName("idInventario");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Fkproducto).HasColumnName("FKProducto");

                entity.Property(e => e.Fkusuario).HasColumnName("FKUsuario");

                entity.HasOne(d => d.FkproductoNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.Fkproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProdctoI");

                entity.HasOne(d => d.FkusuarioNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.Fkusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VendedorI");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PrecioVenta).HasColumnName("precioVenta");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("apellido");

                entity.Property(e => e.Contrasena).HasColumnName("contrasena");

                entity.Property(e => e.NUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nUsuario");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.HasKey(e => e.IdVenta);

                entity.Property(e => e.IdVenta).HasColumnName("idVenta");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Fkproducto).HasColumnName("FKProducto");

                entity.Property(e => e.Fkvendedor).HasColumnName("FKVendedor");

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasColumnName("nombreCliente");

                entity.Property(e => e.PrecioTotal).HasColumnName("precioTotal");

                entity.HasOne(d => d.FkproductoNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Fkproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProductoV");

                entity.HasOne(d => d.FkvendedorNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Fkvendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vendedor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
