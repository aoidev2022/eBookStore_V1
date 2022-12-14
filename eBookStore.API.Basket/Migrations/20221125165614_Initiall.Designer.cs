// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eBookStore.API.Basket.Persistence;

namespace eBookStore.API.Basket.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221125165614_Initiall")]
    partial class Initiall
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eBookStore.API.Basket.Model.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Baskets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 11, 25, 16, 56, 14, 18, DateTimeKind.Unspecified).AddTicks(2386), new TimeSpan(0, 0, 0, 0, 0)),
                            Status = 1,
                            Username = "aoi@182@live.com"
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 11, 25, 16, 56, 14, 18, DateTimeKind.Unspecified).AddTicks(3414), new TimeSpan(0, 0, 0, 0, 0)),
                            Status = 1,
                            Username = "aoi@182@live.com"
                        });
                });

            modelBuilder.Entity("eBookStore.API.Basket.Model.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BasketId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("PurchasedPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BasketId = 1,
                            BookId = 1,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 11, 25, 16, 56, 14, 19, DateTimeKind.Unspecified).AddTicks(5835), new TimeSpan(0, 0, 0, 0, 0)),
                            PurchasedPrice = 5
                        },
                        new
                        {
                            Id = 2,
                            BasketId = 1,
                            BookId = 2,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 11, 25, 16, 56, 14, 19, DateTimeKind.Unspecified).AddTicks(7019), new TimeSpan(0, 0, 0, 0, 0)),
                            PurchasedPrice = 5
                        },
                        new
                        {
                            Id = 3,
                            BasketId = 1,
                            BookId = 3,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 11, 25, 16, 56, 14, 19, DateTimeKind.Unspecified).AddTicks(7055), new TimeSpan(0, 0, 0, 0, 0)),
                            PurchasedPrice = 5
                        },
                        new
                        {
                            Id = 5,
                            BasketId = 2,
                            BookId = 2,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 11, 25, 16, 56, 14, 19, DateTimeKind.Unspecified).AddTicks(7057), new TimeSpan(0, 0, 0, 0, 0)),
                            PurchasedPrice = 5
                        },
                        new
                        {
                            Id = 6,
                            BasketId = 2,
                            BookId = 2,
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 11, 25, 16, 56, 14, 19, DateTimeKind.Unspecified).AddTicks(7060), new TimeSpan(0, 0, 0, 0, 0)),
                            PurchasedPrice = 5
                        });
                });

            modelBuilder.Entity("eBookStore.API.Basket.Model.Item", b =>
                {
                    b.HasOne("eBookStore.API.Basket.Model.Basket", "Basket")
                        .WithMany("Items")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
