﻿// <auto-generated />
using System;
using BeatLeader_Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeatLeader_Server.Migrations.Storage
{
    [DbContext(typeof(StorageContext))]
    partial class StorageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BeatLeader_Server.Models.PlayerLeaderboardStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("AccLeft")
                        .HasColumnType("real");

                    b.Property<float>("AccPP")
                        .HasColumnType("real");

                    b.Property<float>("AccRight")
                        .HasColumnType("real");

                    b.Property<float>("Accuracy")
                        .HasColumnType("real");

                    b.Property<int>("AnonimusReplayWatched")
                        .HasColumnType("int");

                    b.Property<int>("AttemptsCount")
                        .HasColumnType("int");

                    b.Property<int>("AuthorizedReplayWatched")
                        .HasColumnType("int");

                    b.Property<int>("BadCuts")
                        .HasColumnType("int");

                    b.Property<int>("BaseScore")
                        .HasColumnType("int");

                    b.Property<int>("BombCuts")
                        .HasColumnType("int");

                    b.Property<float>("BonusPp")
                        .HasColumnType("real");

                    b.Property<int>("Controller")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryRank")
                        .HasColumnType("int");

                    b.Property<float>("FcAccuracy")
                        .HasColumnType("real");

                    b.Property<float>("FcPp")
                        .HasColumnType("real");

                    b.Property<bool>("FullCombo")
                        .HasColumnType("bit");

                    b.Property<int>("Hmd")
                        .HasColumnType("int");

                    b.Property<string>("LeaderboardId")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<float>("LeftTiming")
                        .HasColumnType("real");

                    b.Property<int>("MaxCombo")
                        .HasColumnType("int");

                    b.Property<int?>("MaxStreak")
                        .HasColumnType("int");

                    b.Property<int>("MissedNotes")
                        .HasColumnType("int");

                    b.Property<int>("ModifiedScore")
                        .HasColumnType("int");

                    b.Property<string>("Modifiers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PassPP")
                        .HasColumnType("real");

                    b.Property<int>("Pauses")
                        .HasColumnType("int");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerId")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<float>("Pp")
                        .HasColumnType("real");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<bool>("Qualification")
                        .HasColumnType("bit");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<string>("Replay")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("ReplayOffsetsId")
                        .HasColumnType("int");

                    b.Property<float>("RightTiming")
                        .HasColumnType("real");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int?>("ScoreId")
                        .HasColumnType("int");

                    b.Property<int?>("ScoreImprovementId")
                        .HasColumnType("int");

                    b.Property<float>("TechPP")
                        .HasColumnType("real");

                    b.Property<float>("Time")
                        .HasColumnType("real");

                    b.Property<int>("Timepost")
                        .HasColumnType("int");

                    b.Property<int>("Timeset")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("WallsHit")
                        .HasColumnType("int");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ReplayOffsetsId");

                    b.HasIndex("ScoreImprovementId");

                    b.HasIndex("PlayerId", "LeaderboardId", "Timeset");

                    b.ToTable("PlayerLeaderboardStats");
                });

            modelBuilder.Entity("BeatLeader_Server.Models.PlayerScoreStatsHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("APlays")
                        .HasColumnType("int");

                    b.Property<float>("AccPp")
                        .HasColumnType("real");

                    b.Property<float>("AverageAccuracy")
                        .HasColumnType("real");

                    b.Property<float>("AverageLeftTiming")
                        .HasColumnType("real");

                    b.Property<float>("AverageRank")
                        .HasColumnType("real");

                    b.Property<float>("AverageRankedAccuracy")
                        .HasColumnType("real");

                    b.Property<float>("AverageRankedRank")
                        .HasColumnType("real");

                    b.Property<float>("AverageRightTiming")
                        .HasColumnType("real");

                    b.Property<float>("AverageUnrankedAccuracy")
                        .HasColumnType("real");

                    b.Property<float>("AverageUnrankedRank")
                        .HasColumnType("real");

                    b.Property<float>("AverageWeightedRankedAccuracy")
                        .HasColumnType("real");

                    b.Property<float>("AverageWeightedRankedRank")
                        .HasColumnType("real");

                    b.Property<int>("Context")
                        .HasColumnType("int");

                    b.Property<int>("CountryRank")
                        .HasColumnType("int");

                    b.Property<int>("DailyImprovements")
                        .HasColumnType("int");

                    b.Property<int>("LastRankedScoreTime")
                        .HasColumnType("int");

                    b.Property<int>("LastScoreTime")
                        .HasColumnType("int");

                    b.Property<int>("LastUnrankedScoreTime")
                        .HasColumnType("int");

                    b.Property<int>("MaxStreak")
                        .HasColumnType("int");

                    b.Property<float>("MedianAccuracy")
                        .HasColumnType("real");

                    b.Property<float>("MedianRankedAccuracy")
                        .HasColumnType("real");

                    b.Property<float>("PassPp")
                        .HasColumnType("real");

                    b.Property<float>("PeakRank")
                        .HasColumnType("real");

                    b.Property<string>("PlayerId")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<float>("Pp")
                        .HasColumnType("real");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<int>("RankedImprovementsCount")
                        .HasColumnType("int");

                    b.Property<int>("RankedPlayCount")
                        .HasColumnType("int");

                    b.Property<int>("ReplaysWatched")
                        .HasColumnType("int");

                    b.Property<int>("SPPlays")
                        .HasColumnType("int");

                    b.Property<int>("SPlays")
                        .HasColumnType("int");

                    b.Property<int>("SSPPlays")
                        .HasColumnType("int");

                    b.Property<int>("SSPlays")
                        .HasColumnType("int");

                    b.Property<float>("TechPp")
                        .HasColumnType("real");

                    b.Property<int>("Timestamp")
                        .HasColumnType("int");

                    b.Property<float>("TopAccuracy")
                        .HasColumnType("real");

                    b.Property<float>("TopBonusPP")
                        .HasColumnType("real");

                    b.Property<int>("TopHMD")
                        .HasColumnType("int");

                    b.Property<string>("TopPlatform")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("TopPp")
                        .HasColumnType("real");

                    b.Property<float>("TopRankedAccuracy")
                        .HasColumnType("real");

                    b.Property<float>("TopUnrankedAccuracy")
                        .HasColumnType("real");

                    b.Property<int>("TotalImprovementsCount")
                        .HasColumnType("int");

                    b.Property<int>("TotalPlayCount")
                        .HasColumnType("int");

                    b.Property<long>("TotalRankedScore")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalScore")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalUnrankedScore")
                        .HasColumnType("bigint");

                    b.Property<int>("UnrankedImprovementsCount")
                        .HasColumnType("int");

                    b.Property<int>("UnrankedPlayCount")
                        .HasColumnType("int");

                    b.Property<int>("WatchedReplays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId", "Context", "Timestamp");

                    b.ToTable("PlayerScoreStatsHistory");
                });

            modelBuilder.Entity("BeatLeader_Server.Models.ScoreImprovement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("AccLeft")
                        .HasColumnType("real");

                    b.Property<float>("AccRight")
                        .HasColumnType("real");

                    b.Property<float>("Accuracy")
                        .HasColumnType("real");

                    b.Property<float>("AverageRankedAccuracy")
                        .HasColumnType("real");

                    b.Property<int>("BadCuts")
                        .HasColumnType("int");

                    b.Property<int>("BombCuts")
                        .HasColumnType("int");

                    b.Property<float>("BonusPp")
                        .HasColumnType("real");

                    b.Property<int>("MissedNotes")
                        .HasColumnType("int");

                    b.Property<int>("Pauses")
                        .HasColumnType("int");

                    b.Property<float>("Pp")
                        .HasColumnType("real");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Timeset")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TotalPp")
                        .HasColumnType("real");

                    b.Property<int>("TotalRank")
                        .HasColumnType("int");

                    b.Property<int>("WallsHit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ScoreImprovement");
                });

            modelBuilder.Entity("OpenIddict.EntityFrameworkCore.Models.OpenIddictEntityFrameworkCoreApplication", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApplicationType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ClientId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ClientSecret")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ConsentType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayNames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JsonWebKeySet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Permissions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostLogoutRedirectUris")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Properties")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RedirectUris")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Requirements")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Settings")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique()
                        .HasFilter("[ClientId] IS NOT NULL");

                    b.ToTable("OpenIddictApplications", (string)null);
                });

            modelBuilder.Entity("OpenIddict.EntityFrameworkCore.Models.OpenIddictEntityFrameworkCoreAuthorization", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApplicationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Properties")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scopes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Subject")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId", "Status", "Subject", "Type");

                    b.ToTable("OpenIddictAuthorizations", (string)null);
                });

            modelBuilder.Entity("OpenIddict.EntityFrameworkCore.Models.OpenIddictEntityFrameworkCoreScope", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descriptions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayNames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Properties")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resources")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("OpenIddictScopes", (string)null);
                });

            modelBuilder.Entity("OpenIddict.EntityFrameworkCore.Models.OpenIddictEntityFrameworkCoreToken", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApplicationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AuthorizationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Payload")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Properties")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RedemptionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReferenceId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Subject")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorizationId");

                    b.HasIndex("ReferenceId")
                        .IsUnique()
                        .HasFilter("[ReferenceId] IS NOT NULL");

                    b.HasIndex("ApplicationId", "Status", "Subject", "Type");

                    b.ToTable("OpenIddictTokens", (string)null);
                });

            modelBuilder.Entity("ReplayDecoder.ReplayOffsets", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Frames")
                        .HasColumnType("int");

                    b.Property<int>("Heights")
                        .HasColumnType("int");

                    b.Property<int>("Notes")
                        .HasColumnType("int");

                    b.Property<int>("Pauses")
                        .HasColumnType("int");

                    b.Property<int>("Walls")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ReplayOffsets");
                });

            modelBuilder.Entity("BeatLeader_Server.Models.PlayerLeaderboardStats", b =>
                {
                    b.HasOne("ReplayDecoder.ReplayOffsets", "ReplayOffsets")
                        .WithMany()
                        .HasForeignKey("ReplayOffsetsId");

                    b.HasOne("BeatLeader_Server.Models.ScoreImprovement", "ScoreImprovement")
                        .WithMany()
                        .HasForeignKey("ScoreImprovementId");

                    b.Navigation("ReplayOffsets");

                    b.Navigation("ScoreImprovement");
                });

            modelBuilder.Entity("OpenIddict.EntityFrameworkCore.Models.OpenIddictEntityFrameworkCoreAuthorization", b =>
                {
                    b.HasOne("OpenIddict.EntityFrameworkCore.Models.OpenIddictEntityFrameworkCoreApplication", "Application")
                        .WithMany("Authorizations")
                        .HasForeignKey("ApplicationId");

                    b.Navigation("Application");
                });

            modelBuilder.Entity("OpenIddict.EntityFrameworkCore.Models.OpenIddictEntityFrameworkCoreToken", b =>
                {
                    b.HasOne("OpenIddict.EntityFrameworkCore.Models.OpenIddictEntityFrameworkCoreApplication", "Application")
                        .WithMany("Tokens")
                        .HasForeignKey("ApplicationId");

                    b.HasOne("OpenIddict.EntityFrameworkCore.Models.OpenIddictEntityFrameworkCoreAuthorization", "Authorization")
                        .WithMany("Tokens")
                        .HasForeignKey("AuthorizationId");

                    b.Navigation("Application");

                    b.Navigation("Authorization");
                });

            modelBuilder.Entity("OpenIddict.EntityFrameworkCore.Models.OpenIddictEntityFrameworkCoreApplication", b =>
                {
                    b.Navigation("Authorizations");

                    b.Navigation("Tokens");
                });

            modelBuilder.Entity("OpenIddict.EntityFrameworkCore.Models.OpenIddictEntityFrameworkCoreAuthorization", b =>
                {
                    b.Navigation("Tokens");
                });
#pragma warning restore 612, 618
        }
    }
}
