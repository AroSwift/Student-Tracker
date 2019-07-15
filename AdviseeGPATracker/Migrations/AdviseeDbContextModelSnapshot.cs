﻿// <auto-generated />
using AdviseeGPATracker.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdviseeGPATracker.Migrations
{
    [DbContext(typeof(AdviseeDbContext))]
    partial class AdviseeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdviseeGPATracker.Models.Entities.Advisee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Advisees");
                });

            modelBuilder.Entity("AdviseeGPATracker.Models.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdviseeId");

                    b.Property<string>("Code");

                    b.Property<int>("CreditHours");

                    b.Property<string>("LetterGrade");

                    b.HasKey("Id");

                    b.HasIndex("AdviseeId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("AdviseeGPATracker.Models.Entities.Course", b =>
                {
                    b.HasOne("AdviseeGPATracker.Models.Entities.Advisee", "Advisee")
                        .WithMany("Courses")
                        .HasForeignKey("AdviseeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
