﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210123144229_CreateDb")]
    partial class CreateDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Language", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            ID = new Guid("a4a20724-0c0f-4893-a2ff-5cb065db7fdd"),
                            Name = "Arabic"
                        },
                        new
                        {
                            ID = new Guid("aa10ce14-601b-4ac3-8854-30aa99172fe6"),
                            Name = "English"
                        },
                        new
                        {
                            ID = new Guid("e67a69e5-d5fd-4261-915e-3b1d65974f45"),
                            Name = "French"
                        });
                });

            modelBuilder.Entity("Domain.POCO", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("CV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateofBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Married")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Password")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid?>("SupervisorID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("SupervisorID");

                    b.ToTable("POCOs");
                });

            modelBuilder.Entity("Domain.POCOLanguage", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LanguageIdFK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("POCOIdFK")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("LanguageIdFK");

                    b.HasIndex("POCOIdFK");

                    b.ToTable("POCOLanguages");
                });

            modelBuilder.Entity("Domain.POCO", b =>
                {
                    b.HasOne("Domain.POCO", "Supervisor")
                        .WithMany()
                        .HasForeignKey("SupervisorID");
                });

            modelBuilder.Entity("Domain.POCOLanguage", b =>
                {
                    b.HasOne("Domain.Language", "Language")
                        .WithMany("POCOLanguages")
                        .HasForeignKey("LanguageIdFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.POCO", "POCO")
                        .WithMany("POCOLanguages")
                        .HasForeignKey("POCOIdFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
