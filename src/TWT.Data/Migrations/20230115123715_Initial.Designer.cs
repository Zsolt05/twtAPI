// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TWT.Data;

#nullable disable

namespace TWT.Data.Migrations
{
    [DbContext(typeof(CarStoreDbContext))]
    [Migration("20230115123715_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TWT.Data.Models.Car", b =>
                {
                    b.Property<string>("LincensePlate")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("LincensePlate");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("OwnerName");

                    b.Property<int>("Power")
                        .HasColumnType("int")
                        .HasColumnName("Power");

                    b.HasKey("LincensePlate");

                    b.ToTable("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
