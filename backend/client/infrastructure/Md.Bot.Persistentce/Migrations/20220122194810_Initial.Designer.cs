﻿// <auto-generated />
using Md.Bot.Persistentce.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Md.Bot.Persistentce.Migrations
{
    [DbContext(typeof(TelegramDbContext))]
    [Migration("20220122194810_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("Md.Bot.Domain.Entities.TelegramUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PreviousCommandName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TelegramUsers");
                });
#pragma warning restore 612, 618
        }
    }
}