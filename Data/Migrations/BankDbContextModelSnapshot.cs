﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(BankDbContext))]
    partial class BankDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Models.BankAccount", b =>
                {
                    b.Property<Guid>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<double>("Overdraft")
                        .HasColumnType("float");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Number");

                    b.HasIndex("Alias")
                        .IsUnique();

                    b.ToTable("BankAccount");

                    b.HasData(
                        new
                        {
                            Number = new Guid("78bc3ff5-2b92-4d6e-8367-bc10b6e16d66"),
                            Alias = "CA.SEED.ALPHA",
                            DateCreated = new DateTime(2020, 5, 26, 14, 40, 22, 232, DateTimeKind.Local).AddTicks(4960),
                            Overdraft = 0.0,
                            Type = 0
                        },
                        new
                        {
                            Number = new Guid("b3098986-7560-495c-893c-120a7a4108d9"),
                            Alias = "CA.SEED.BETA",
                            DateCreated = new DateTime(2020, 5, 26, 14, 40, 22, 243, DateTimeKind.Local).AddTicks(9390),
                            Overdraft = 0.0,
                            Type = 0
                        },
                        new
                        {
                            Number = new Guid("991415f2-cb31-4d9d-a6a4-1058ae0b960b"),
                            Alias = "CA.SEED.GAMMA",
                            DateCreated = new DateTime(2020, 5, 26, 14, 40, 22, 243, DateTimeKind.Local).AddTicks(9430),
                            Overdraft = 0.0,
                            Type = 0
                        },
                        new
                        {
                            Number = new Guid("ef308606-ed29-4ea3-8478-9015d97fce55"),
                            Alias = "CC.SEED.RHO",
                            DateCreated = new DateTime(2020, 5, 26, 14, 40, 22, 243, DateTimeKind.Local).AddTicks(9440),
                            Overdraft = 2000.0,
                            Type = 1
                        },
                        new
                        {
                            Number = new Guid("e1743286-9b70-4dfa-b157-363bd33ece26"),
                            Alias = "CC.SEED.EPSILON",
                            DateCreated = new DateTime(2020, 5, 26, 14, 40, 22, 243, DateTimeKind.Local).AddTicks(9440),
                            Overdraft = 1000.0,
                            Type = 1
                        },
                        new
                        {
                            Number = new Guid("75fc66c6-242f-455e-a6b9-682270331694"),
                            Alias = "CC.SEED.OMEGA",
                            DateCreated = new DateTime(2020, 5, 26, 14, 40, 22, 243, DateTimeKind.Local).AddTicks(9440),
                            Overdraft = 750.0,
                            Type = 1
                        });
                });

            modelBuilder.Entity("Domain.Models.Deposit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("TargetAccountId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TargetAccountId");

                    b.ToTable("Deposit");
                });

            modelBuilder.Entity("Domain.Models.Transfer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("SourceAccountId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TargetAccountId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SourceAccountId");

                    b.HasIndex("TargetAccountId");

                    b.ToTable("Transfer");
                });

            modelBuilder.Entity("Domain.Models.Withdrawal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("TargetAccountId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TargetAccountId");

                    b.ToTable("Withdrawal");
                });

            modelBuilder.Entity("Domain.Models.Deposit", b =>
                {
                    b.HasOne("Domain.Models.BankAccount", "TargetAccount")
                        .WithMany("Deposits")
                        .HasForeignKey("TargetAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Transfer", b =>
                {
                    b.HasOne("Domain.Models.BankAccount", "SourceAccount")
                        .WithMany("TransfersAsSource")
                        .HasForeignKey("SourceAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Models.BankAccount", "TargetAccount")
                        .WithMany("TransfersAsTarget")
                        .HasForeignKey("TargetAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Withdrawal", b =>
                {
                    b.HasOne("Domain.Models.BankAccount", "TargetAccount")
                        .WithMany("Withdrawals")
                        .HasForeignKey("TargetAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
