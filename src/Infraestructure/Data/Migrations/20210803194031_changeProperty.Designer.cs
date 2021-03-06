// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Weelo.Infraestructure.Data;

namespace Weelo.Infraestructure.Data.Migrations
{
    [DbContext(typeof(WeeloDbContext))]
    [Migration("20210803194031_changeProperty")]
    partial class changeProperty
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("Weelo.Core.Entities.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Photo")
                        .HasColumnType("TEXT");

                    b.Property<bool>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("Weelo.Core.Entities.Property", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<int>("Calification")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CodeInternal")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PropertyImageId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PropertyTraceId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("State")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Weelo.Core.Entities.PropertyImage", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Enabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("File")
                        .HasColumnType("TEXT");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("State")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Width")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("PropertyImages");
                });

            modelBuilder.Entity("Weelo.Core.Entities.PropertyTrace", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateSale")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("State")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Tax")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PropertyTraces");
                });

            modelBuilder.Entity("Weelo.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<bool>("State")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Weelo.Core.Entities.Property", b =>
                {
                    b.HasOne("Weelo.Core.Entities.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Weelo.Core.Entities.PropertyImage", b =>
                {
                    b.HasOne("Weelo.Core.Entities.Property", "Property")
                        .WithOne("PropertyImage")
                        .HasForeignKey("Weelo.Core.Entities.PropertyImage", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("Weelo.Core.Entities.PropertyTrace", b =>
                {
                    b.HasOne("Weelo.Core.Entities.Property", "Property")
                        .WithOne("PropertyTrace")
                        .HasForeignKey("Weelo.Core.Entities.PropertyTrace", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("Weelo.Core.Entities.Property", b =>
                {
                    b.Navigation("PropertyImage");

                    b.Navigation("PropertyTrace");
                });
#pragma warning restore 612, 618
        }
    }
}
