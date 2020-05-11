﻿// <auto-generated />
using System;
using DateNiteBackEndCapstone.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DateNiteBackEndCapstone.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DateNiteBackEndCapstone.Models.Business", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicatonUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BusinessId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DateId")
                        .HasColumnType("int");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocationAddressId")
                        .HasColumnType("int");

                    b.Property<int>("LocationTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicatonUserId");

                    b.HasIndex("LocationAddressId");

                    b.ToTable("Businesses");
                });

            modelBuilder.Entity("DateNiteBackEndCapstone.Models.Date", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsScheduled")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Dates");
                });

            modelBuilder.Entity("DateNiteBackEndCapstone.Models.LocationAddress", b =>
                {
                    b.Property<int>("LocationAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("LocationAddressId");

                    b.ToTable("LocationAddress");
                });

            modelBuilder.Entity("DateNiteBackEndCapstone.Models.LocationType", b =>
                {
                    b.Property<int>("LocationTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationTypeId");

                    b.ToTable("LocationTypes");

                    b.HasData(
                        new
                        {
                            LocationTypeId = 1,
                            Type = "Food"
                        },
                        new
                        {
                            LocationTypeId = 2,
                            Type = "Fun"
                        });
                });

            modelBuilder.Entity("DateNiteBackEndCapstone.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "AL"
                        },
                        new
                        {
                            Id = 2,
                            Name = "AK"
                        },
                        new
                        {
                            Id = 3,
                            Name = "AZ"
                        },
                        new
                        {
                            Id = 4,
                            Name = "AR"
                        },
                        new
                        {
                            Id = 5,
                            Name = "CA"
                        },
                        new
                        {
                            Id = 6,
                            Name = "CO"
                        },
                        new
                        {
                            Id = 7,
                            Name = "CT"
                        },
                        new
                        {
                            Id = 8,
                            Name = "DE"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Fl"
                        },
                        new
                        {
                            Id = 10,
                            Name = "GA"
                        },
                        new
                        {
                            Id = 11,
                            Name = "HI"
                        },
                        new
                        {
                            Id = 12,
                            Name = "ID"
                        },
                        new
                        {
                            Id = 13,
                            Name = "IL"
                        },
                        new
                        {
                            Id = 14,
                            Name = "IN"
                        },
                        new
                        {
                            Id = 15,
                            Name = "IA"
                        },
                        new
                        {
                            Id = 16,
                            Name = "KS"
                        },
                        new
                        {
                            Id = 17,
                            Name = "KY"
                        },
                        new
                        {
                            Id = 18,
                            Name = "LA"
                        },
                        new
                        {
                            Id = 19,
                            Name = "ME"
                        },
                        new
                        {
                            Id = 20,
                            Name = "MD"
                        },
                        new
                        {
                            Id = 21,
                            Name = "MA"
                        },
                        new
                        {
                            Id = 22,
                            Name = "MI"
                        },
                        new
                        {
                            Id = 23,
                            Name = "MN"
                        },
                        new
                        {
                            Id = 24,
                            Name = "MS"
                        },
                        new
                        {
                            Id = 25,
                            Name = "MO"
                        },
                        new
                        {
                            Id = 26,
                            Name = "MT"
                        },
                        new
                        {
                            Id = 27,
                            Name = "NE"
                        },
                        new
                        {
                            Id = 28,
                            Name = "NV"
                        },
                        new
                        {
                            Id = 29,
                            Name = "NH"
                        },
                        new
                        {
                            Id = 30,
                            Name = "NJ"
                        },
                        new
                        {
                            Id = 31,
                            Name = "NM"
                        },
                        new
                        {
                            Id = 32,
                            Name = "NY"
                        },
                        new
                        {
                            Id = 33,
                            Name = "NC"
                        },
                        new
                        {
                            Id = 34,
                            Name = "ND"
                        },
                        new
                        {
                            Id = 35,
                            Name = "OH"
                        },
                        new
                        {
                            Id = 36,
                            Name = "OK"
                        },
                        new
                        {
                            Id = 37,
                            Name = "OR"
                        },
                        new
                        {
                            Id = 38,
                            Name = "PA"
                        },
                        new
                        {
                            Id = 39,
                            Name = "RI"
                        },
                        new
                        {
                            Id = 40,
                            Name = "SC"
                        },
                        new
                        {
                            Id = 41,
                            Name = "SD"
                        },
                        new
                        {
                            Id = 42,
                            Name = "TN"
                        },
                        new
                        {
                            Id = 43,
                            Name = "TX"
                        },
                        new
                        {
                            Id = 44,
                            Name = "UT"
                        },
                        new
                        {
                            Id = 45,
                            Name = "VT"
                        },
                        new
                        {
                            Id = 46,
                            Name = "VA"
                        },
                        new
                        {
                            Id = 47,
                            Name = "WA"
                        },
                        new
                        {
                            Id = 48,
                            Name = "WV"
                        },
                        new
                        {
                            Id = 49,
                            Name = "WI"
                        },
                        new
                        {
                            Id = 50,
                            Name = "WY"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DateNiteBackEndCapstone.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("DateNiteBackEndCapstone.Models.Business", b =>
                {
                    b.HasOne("DateNiteBackEndCapstone.Models.ApplicationUser", "ApplicatonUser")
                        .WithMany()
                        .HasForeignKey("ApplicatonUserId");

                    b.HasOne("DateNiteBackEndCapstone.Models.LocationAddress", "LocationAddress")
                        .WithMany()
                        .HasForeignKey("LocationAddressId");
                });

            modelBuilder.Entity("DateNiteBackEndCapstone.Models.Date", b =>
                {
                    b.HasOne("DateNiteBackEndCapstone.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
