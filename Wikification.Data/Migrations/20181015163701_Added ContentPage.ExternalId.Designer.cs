﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wikification.Data;

namespace Wikification.Data.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20181015163701_Added ContentPage.ExternalId")]
    partial class AddedContentPageExternalId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("wikifi")
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Wikification.Data.Datastructure.Badge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AwardedXp");

                    b.Property<string>("Description")
                        .HasMaxLength(300);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("SymbolUrl")
                        .HasMaxLength(150);

                    b.Property<int>("SystemId");

                    b.HasKey("Id");

                    b.HasIndex("SystemId");

                    b.ToTable("Badges");
                });

            modelBuilder.Entity("Wikification.Data.Datastructure.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AwardedXp");

                    b.Property<int?>("BadgeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("SystemId");

                    b.HasKey("Id");

                    b.HasIndex("BadgeId");

                    b.HasIndex("SystemId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Wikification.Data.Datastructure.ContentPage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BadgeId");

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("SystemId");

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("BadgeId");

                    b.HasIndex("SystemId");

                    b.ToTable("ContentPages");
                });

            modelBuilder.Entity("Wikification.Data.Datastructure.Edition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AwardedXp");

                    b.Property<string>("Contents");

                    b.Property<long>("DateCreated");

                    b.Property<string>("EditionDescription")
                        .HasMaxLength(150);

                    b.Property<int>("PageId");

                    b.HasKey("Id");

                    b.HasIndex("PageId");

                    b.ToTable("Edition");
                });

            modelBuilder.Entity("Wikification.Data.Datastructure.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("SystemId");

                    b.HasKey("Id");

                    b.HasIndex("SystemId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("Wikification.Data.Datastructure.ExternalSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CallbackUrl")
                        .HasMaxLength(200);

                    b.Property<string>("ExternalId")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Systems");
                });

            modelBuilder.Entity("Wikification.Data.Datastructure.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("SystemId");

                    b.Property<int>("XpThreshold");

                    b.HasKey("Id");

                    b.HasIndex("SystemId");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("Wikification.Data.Datastructure.Linking.PageCategory", b =>
                {
                    b.Property<int>("CategoryId");

                    b.Property<int>("PageId");

                    b.HasKey("CategoryId", "PageId");

                    b.HasIndex("PageId");

                    b.ToTable("PageCategory");
                });

            modelBuilder.Entity("Wikification.Data.Datastructure.Linking.UserBadge", b =>
                {
                    b.Property<int>("BadgeId");

                    b.Property<int>("UserId");

                    b.HasKey("BadgeId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBadge");
                });

            modelBuilder.Entity("Wikification.Data.Datastructure.Linking.UserEdition", b =>
                {
                    b.Property<int>("EditionId");

                    b.Property<int>("UserId");

                    b.HasKey("EditionId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserEdition");
                });

            modelBuilder.Entity("Wikification.Data.Datastructure.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExternalId")
                        .HasMaxLength(50);

                    b.Property<int?>("LevelId");

                    b.Property<int>("SystemId");

                    b.Property<string>("Username")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("LevelId");

                    b.HasIndex("SystemId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Wikification.Data.Datastructure.Badge", b =>
                {
                    b.HasOne("Wikification.Data.Datastructure.ExternalSystem", "System")
                        .WithMany()
                        .HasForeignKey("SystemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Wikification.Data.Datastructure.Category", b =>
                {
                    b.HasOne("Wikification.Data.Datastructure.Badge", "Badge")
                        .WithMany()
                        .HasForeignKey("BadgeId");

                    b.HasOne("Wikification.Data.Datastructure.ExternalSystem", "System")
                        .WithMany()
                        .HasForeignKey("SystemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Wikification.Data.Datastructure.ContentPage", b =>
                {
                    b.HasOne("Wikification.Data.Datastructure.Badge", "Badge")
                        .WithMany()
                        .HasForeignKey("BadgeId");

                    b.HasOne("Wikification.Data.Datastructure.ExternalSystem", "System")
                        .WithMany("Pages")
                        .HasForeignKey("SystemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Wikification.Data.Datastructure.Edition", b =>
                {
                    b.HasOne("Wikification.Data.Datastructure.ContentPage", "Page")
                        .WithMany("Editions")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Wikification.Data.Datastructure.Edition+EditionVersion", "Version", b1 =>
                        {
                            b1.Property<int>("EditionId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Change");

                            b1.Property<int>("Major");

                            b1.Property<int>("Minor");

                            b1.ToTable("Edition");

                            b1.HasOne("Wikification.Data.Datastructure.Edition")
                                .WithOne("Version")
                                .HasForeignKey("Wikification.Data.Datastructure.Edition+EditionVersion", "EditionId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Wikification.Data.Datastructure.Event", b =>
                {
                    b.HasOne("Wikification.Data.Datastructure.ExternalSystem", "System")
                        .WithMany("Events")
                        .HasForeignKey("SystemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Wikification.Data.Datastructure.Level", b =>
                {
                    b.HasOne("Wikification.Data.Datastructure.ExternalSystem", "System")
                        .WithMany()
                        .HasForeignKey("SystemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Wikification.Data.Datastructure.Linking.PageCategory", b =>
                {
                    b.HasOne("Wikification.Data.Datastructure.ContentPage", "Page")
                        .WithMany("Categories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Wikification.Data.Datastructure.Category", "Category")
                        .WithMany("Pages")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Wikification.Data.Datastructure.Linking.UserBadge", b =>
                {
                    b.HasOne("Wikification.Data.Datastructure.User", "User")
                        .WithMany("EarnedBadges")
                        .HasForeignKey("BadgeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Wikification.Data.Datastructure.Badge", "Badge")
                        .WithMany("Users")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Wikification.Data.Datastructure.Linking.UserEdition", b =>
                {
                    b.HasOne("Wikification.Data.Datastructure.User", "User")
                        .WithMany("ReadEditions")
                        .HasForeignKey("EditionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Wikification.Data.Datastructure.Edition", "Edition")
                        .WithMany("Users")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Wikification.Data.Datastructure.User", b =>
                {
                    b.HasOne("Wikification.Data.Datastructure.Level", "Level")
                        .WithMany()
                        .HasForeignKey("LevelId");

                    b.HasOne("Wikification.Data.Datastructure.ExternalSystem", "System")
                        .WithMany("Users")
                        .HasForeignKey("SystemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
