using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OnFarmCore.Domain;

namespace OnFarmCore.Repo
{
    public partial class OnFarmContext : DbContext
    {

        public OnFarmContext(DbContextOptions<OnFarmContext> options): base(options){}

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

                entity.Property(e => e.Bairro)
                    .HasColumnName("BAIRRO")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .HasColumnName("CIDADE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasColumnName("COMPLEMENTO")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NmCliente)
                    .IsRequired()
                    .HasColumnName("NM_CLIENTE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Numero).HasColumnName("NUMERO");

                entity.Property(e => e.Rua)
                    .HasColumnName("RUA")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasColumnName("TELEFONE")
                    .HasMaxLength(18)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pedidos>(entity =>
            {
                entity.HasKey(e => e.IdPedido);

                entity.Property(e => e.IdPedido).HasColumnName("ID_PEDIDO");

                entity.Property(e => e.CodRastreio)
                    .IsRequired()
                    .HasColumnName("COD_RASTREIO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DtCriacao)
                    .HasColumnName("DT_CRIACAO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Pedidos__ID_CLIE__2A4B4B5E");
            });
        }
    }
}
