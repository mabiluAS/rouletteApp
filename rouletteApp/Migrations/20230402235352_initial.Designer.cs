﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rouletteApp.Data;

namespace rouletteApp.Migrations
{
    [DbContext(typeof(RouletteDbContext))]
    [Migration("20230402235352_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("rouletteApp.Models.Bet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("BetDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberSelection")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Payout")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Bets");
                });

            modelBuilder.Entity("rouletteApp.Models.Spin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Spins");
                });
#pragma warning restore 612, 618
        }
    }
}
