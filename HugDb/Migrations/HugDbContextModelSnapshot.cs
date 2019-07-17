﻿// <auto-generated />
using System;
using HugDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HugDb.Migrations
{
    [DbContext(typeof(HugDbContext))]
    partial class HugDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HugDb.Entities.Committee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Committees");
                });

            modelBuilder.Entity("HugDb.Entities.Hug", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CommitteeId");

                    b.Property<DateTime>("Created");

                    b.Property<int?>("FromUserId");

                    b.Property<int?>("ToUserId");

                    b.Property<bool>("Used");

                    b.Property<int?>("UserId");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CommitteeId");

                    b.HasIndex("FromUserId");

                    b.HasIndex("ToUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Hugs");
                });

            modelBuilder.Entity("HugDb.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("SocEmail");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HugDb.Entities.UserCommittee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CommitteeId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CommitteeId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCommittees");
                });

            modelBuilder.Entity("HugDb.Entities.Hug", b =>
                {
                    b.HasOne("HugDb.Entities.Committee", "Committee")
                        .WithMany("Hugs")
                        .HasForeignKey("CommitteeId");

                    b.HasOne("HugDb.Entities.User", "FromUser")
                        .WithMany()
                        .HasForeignKey("FromUserId");

                    b.HasOne("HugDb.Entities.User", "ToUser")
                        .WithMany()
                        .HasForeignKey("ToUserId");

                    b.HasOne("HugDb.Entities.User")
                        .WithMany("Hugs")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("HugDb.Entities.UserCommittee", b =>
                {
                    b.HasOne("HugDb.Entities.Committee", "Committee")
                        .WithMany("UserCommittees")
                        .HasForeignKey("CommitteeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HugDb.Entities.User", "User")
                        .WithMany("UserCommittees")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
