using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaVenta.Entity;

namespace SistemaVenta.DAL.DBContext;

public partial class DbventaContext : DbContext
{
    public DbventaContext()
    {
    }

    public DbventaContext(DbContextOptions<DbventaContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Configuracion> Configuracions { get; set; }

    public virtual DbSet<Detalleventa> Detalleventa { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Negocio> Negocios { get; set; }

    public virtual DbSet<Numerocorrelativo> Numerocorrelativos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Rolmenu> Rolmenus { get; set; }

    public virtual DbSet<Tipodocumentoventa> Tipodocumentoventa { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PRIMARY");

            entity.ToTable("categoria");

            entity.Property(e => e.IdCategoria)
                .HasColumnType("int(11)")
                .HasColumnName("idCategoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("descripcion");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("bit(1)")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
        });

        modelBuilder.Entity<Configuracion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("configuracion");

            entity.Property(e => e.Propiedad)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("propiedad");
            entity.Property(e => e.Recurso)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("recurso");
            entity.Property(e => e.Valor)
                .HasMaxLength(60)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("valor");
        });

        modelBuilder.Entity<Detalleventa>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta).HasName("PRIMARY");

            entity.ToTable("detalleventa");

            entity.HasIndex(e => e.IdVenta, "fk_Venta_DetalleVenta");

            entity.Property(e => e.IdDetalleVenta)
                .HasColumnType("int(11)")
                .HasColumnName("idDetalleVenta");
            entity.Property(e => e.Cantidad)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("cantidad");
            entity.Property(e => e.CategoriaProducto)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("categoriaProducto");
            entity.Property(e => e.DescripcionProducto)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("descripcionProducto");
            entity.Property(e => e.IdProducto)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("idProducto");
            entity.Property(e => e.IdVenta)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("idVenta");
            entity.Property(e => e.MarcaProducto)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("marcaProducto");
            entity.Property(e => e.Precio)
                .HasPrecision(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("precio");
            entity.Property(e => e.Total)
                .HasPrecision(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("total");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.Detalleventa)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_Venta_DetalleVenta");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PRIMARY");

            entity.ToTable("menu");

            entity.HasIndex(e => e.IdMenuPadre, "fk_Menu");

            entity.Property(e => e.IdMenu)
                .HasColumnType("int(11)")
                .HasColumnName("idMenu");
            entity.Property(e => e.Controlador)
                .HasMaxLength(30)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("controlador");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("descripcion");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("bit(1)")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Icono)
                .HasMaxLength(30)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("icono");
            entity.Property(e => e.IdMenuPadre)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("idMenuPadre");
            entity.Property(e => e.PaginaAccion)
                .HasMaxLength(30)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("paginaAccion");

            entity.HasOne(d => d.IdMenuPadreNavigation).WithMany(p => p.InverseIdMenuPadreNavigation)
                .HasForeignKey(d => d.IdMenuPadre)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_Menu");
        });

        modelBuilder.Entity<Negocio>(entity =>
        {
            entity.HasKey(e => e.IdNegocio).HasName("PRIMARY");

            entity.ToTable("negocio");

            entity.Property(e => e.IdNegocio)
                .HasColumnType("int(11)")
                .HasColumnName("idNegocio");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("nombre");
            entity.Property(e => e.NombreLogo)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("nombreLogo");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("numeroDocumento");
            entity.Property(e => e.PorcentajeImpuesto)
                .HasPrecision(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("porcentajeImpuesto");
            entity.Property(e => e.SimboloMoneda)
                .HasMaxLength(5)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("simboloMoneda");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("telefono");
            entity.Property(e => e.UrlLogo)
                .HasMaxLength(500)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("urlLogo");
        });

        modelBuilder.Entity<Numerocorrelativo>(entity =>
        {
            entity.HasKey(e => e.IdNumeroCorrelativo).HasName("PRIMARY");

            entity.ToTable("numerocorrelativo");

            entity.Property(e => e.IdNumeroCorrelativo)
                .HasColumnType("int(11)")
                .HasColumnName("idNumeroCorrelativo");
            entity.Property(e => e.CantidadDigitos)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("cantidadDigitos");
            entity.Property(e => e.FechaActualizacion)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime")
                .HasColumnName("fechaActualizacion");
            entity.Property(e => e.Gestion)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("gestion");
            entity.Property(e => e.UltimoNumero)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("ultimoNumero");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PRIMARY");

            entity.ToTable("producto");

            entity.HasIndex(e => e.IdCategoria, "fk_Producto_Categoria");

            entity.Property(e => e.IdProducto)
                .HasColumnType("int(11)")
                .HasColumnName("idProducto");
            entity.Property(e => e.CodigoBarra)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("codigoBarra");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("descripcion");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("bit(1)")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdCategoria)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("idCategoria");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("marca");
            entity.Property(e => e.NombreImagen)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("nombreImagen");
            entity.Property(e => e.Precio)
                .HasPrecision(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("precio");
            entity.Property(e => e.Stock)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("stock");
            entity.Property(e => e.UrlImagen)
                .HasMaxLength(500)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("urlImagen");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_Producto_Categoria");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity.ToTable("rol");

            entity.Property(e => e.IdRol)
                .HasColumnType("int(11)")
                .HasColumnName("idRol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("descripcion");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("bit(1)")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
        });

        modelBuilder.Entity<Rolmenu>(entity =>
        {
            entity.HasKey(e => e.IdRolMenu).HasName("PRIMARY");

            entity.ToTable("rolmenu");

            entity.HasIndex(e => e.IdMenu, "fk_RolMenu_Menu");

            entity.HasIndex(e => e.IdRol, "fk_RolMenu_Rol");

            entity.Property(e => e.IdRolMenu)
                .HasColumnType("int(11)")
                .HasColumnName("idRolMenu");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("bit(1)")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdMenu)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("idMenu");
            entity.Property(e => e.IdRol)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("idRol");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.Rolmenus)
                .HasForeignKey(d => d.IdMenu)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_RolMenu_Menu");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Rolmenus)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_RolMenu_Rol");
        });

        modelBuilder.Entity<Tipodocumentoventa>(entity =>
        {
            entity.HasKey(e => e.IdTipoDocumentoVenta).HasName("PRIMARY");

            entity.ToTable("tipodocumentoventa");

            entity.Property(e => e.IdTipoDocumentoVenta)
                .HasColumnType("int(11)")
                .HasColumnName("idTipoDocumentoVenta");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("descripcion");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("bit(1)")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.IdRol, "fk_Usuario_Rol");

            entity.Property(e => e.IdUsuario)
                .HasColumnType("int(11)")
                .HasColumnName("idUsuario");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("correo");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("bit(1)")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdRol)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("idRol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("nombre");
            entity.Property(e => e.NombreFoto)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("nombreFoto");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("telefono");
            entity.Property(e => e.UrlFoto)
                .HasMaxLength(500)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("urlFoto");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_Usuario_Rol");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PRIMARY");

            entity.ToTable("venta");

            entity.HasIndex(e => e.IdTipoDocumentoVenta, "fk_Venta_TipoDocumentoVenta");

            entity.HasIndex(e => e.IdUsuario, "fk_Venta_Usuario");

            entity.Property(e => e.IdVenta)
                .HasColumnType("int(11)")
                .HasColumnName("idVenta");
            entity.Property(e => e.DocumentoCliente)
                .HasMaxLength(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("documentoCliente");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdTipoDocumentoVenta)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("idTipoDocumentoVenta");
            entity.Property(e => e.IdUsuario)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("idUsuario");
            entity.Property(e => e.ImpuestoTotal)
                .HasPrecision(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("impuestoTotal");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("nombreCliente");
            entity.Property(e => e.NumeroVenta)
                .HasMaxLength(6)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("numeroVenta");
            entity.Property(e => e.SubTotal)
                .HasPrecision(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("subTotal");
            entity.Property(e => e.Total)
                .HasPrecision(10)
                .HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.IdTipoDocumentoVentaNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdTipoDocumentoVenta)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_Venta_TipoDocumentoVenta");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_Venta_Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
