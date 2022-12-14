// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimulaCredito.Models.Context;

#nullable disable

namespace SimulaCredito.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20220905153025_ColunaAtivoTabelaCliente")]
    partial class ColunaAtivoTabelaCliente
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SimulaCredito.Models.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("Ativo");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CPF");

                    b.Property<double>("Celular")
                        .HasColumnType("float")
                        .HasColumnName("Celular");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UF");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("SimulaCredito.Models.Financiamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<long>("TipoFinanciamentoId")
                        .HasColumnType("bigint");

                    b.Property<double>("TotalJuros")
                        .HasColumnType("float")
                        .HasColumnName("TotalJuros");

                    b.Property<DateTime>("UltimoVencimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("UltimoVencimento");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("float")
                        .HasColumnName("ValorTotal");

                    b.Property<double>("ValorTotalJuros")
                        .HasColumnType("float")
                        .HasColumnName("ValorTotalJuros");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TipoFinanciamentoId");

                    b.ToTable("Financiamento");
                });

            modelBuilder.Entity("SimulaCredito.Models.Parcela", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataPagamento");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataVencimento");

                    b.Property<long>("FinanciamentoId")
                        .HasColumnType("bigint");

                    b.Property<int>("NumeroParcela")
                        .HasColumnType("int")
                        .HasColumnName("NumeroParcela");

                    b.Property<double>("Valor")
                        .HasColumnType("float")
                        .HasColumnName("Valor");

                    b.HasKey("Id");

                    b.HasIndex("FinanciamentoId");

                    b.ToTable("Parcela");
                });

            modelBuilder.Entity("SimulaCredito.Models.TipoFinanciamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.Property<int>("QtdMaxParcelas")
                        .HasColumnType("int")
                        .HasColumnName("QtdMaxParcelas");

                    b.Property<int>("QtdMinParcelas")
                        .HasColumnType("int")
                        .HasColumnName("QtdMinParcelas");

                    b.Property<double>("Taxa")
                        .HasColumnType("float")
                        .HasColumnName("Taxa");

                    b.Property<double>("ValorMax")
                        .HasColumnType("float")
                        .HasColumnName("ValorMax");

                    b.Property<double>("ValorMin")
                        .HasColumnType("float")
                        .HasColumnName("ValorMin");

                    b.HasKey("Id");

                    b.ToTable("TipoFinanciamento");
                });

            modelBuilder.Entity("SimulaCredito.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("full_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(130)
                        .HasColumnType("nvarchar(130)")
                        .HasColumnName("password");

                    b.Property<string>("RefreshToken")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("refresh_token");

                    b.Property<DateTime?>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("refresh_token_expiry_time");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("user_name");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SimulaCredito.Models.Financiamento", b =>
                {
                    b.HasOne("SimulaCredito.Models.Cliente", "Cliente")
                        .WithMany("Financiamentos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimulaCredito.Models.TipoFinanciamento", "TipoFinanciamento")
                        .WithMany("Financiamentos")
                        .HasForeignKey("TipoFinanciamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("TipoFinanciamento");
                });

            modelBuilder.Entity("SimulaCredito.Models.Parcela", b =>
                {
                    b.HasOne("SimulaCredito.Models.Financiamento", "financiamento")
                        .WithMany("parcelas")
                        .HasForeignKey("FinanciamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("financiamento");
                });

            modelBuilder.Entity("SimulaCredito.Models.Cliente", b =>
                {
                    b.Navigation("Financiamentos");
                });

            modelBuilder.Entity("SimulaCredito.Models.Financiamento", b =>
                {
                    b.Navigation("parcelas");
                });

            modelBuilder.Entity("SimulaCredito.Models.TipoFinanciamento", b =>
                {
                    b.Navigation("Financiamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
