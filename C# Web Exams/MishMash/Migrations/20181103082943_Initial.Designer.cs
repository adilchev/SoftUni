﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MishMashExam.Data;

namespace MishMashExam.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181103082943_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MishMashExam.Models.Channel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Channels");
                });

            modelBuilder.Entity("MishMashExam.Models.ChannelTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChannelId");

                    b.Property<int>("TagId");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId");

                    b.HasIndex("TagId");

                    b.ToTable("ChannelTags");
                });

            modelBuilder.Entity("MishMashExam.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("MishMashExam.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<int>("Role");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MishMashWebApp.Models.UserInChannel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChannelId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId");

                    b.HasIndex("UserId");

                    b.ToTable("UserInChannel");
                });

            modelBuilder.Entity("MishMashExam.Models.ChannelTag", b =>
                {
                    b.HasOne("MishMashExam.Models.Channel", "Channel")
                        .WithMany("Tags")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MishMashExam.Models.Tag", "Tag")
                        .WithMany("Channels")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MishMashWebApp.Models.UserInChannel", b =>
                {
                    b.HasOne("MishMashExam.Models.Channel", "Channel")
                        .WithMany("Followers")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MishMashExam.Models.User", "User")
                        .WithMany("Channels")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
