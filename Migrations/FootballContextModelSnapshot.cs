﻿// <auto-generated />
using Football.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Football.Migrations
{
    [DbContext(typeof(FootballContext))]
    partial class FootballContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Football.Data.Models.Coach", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PK__coaches__3213E83FBE8D649A");

                    b.ToTable("coaches", (string)null);
                });

            modelBuilder.Entity("Football.Data.Models.League", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PK__leagues__3213E83FC1AF64E4");

                    b.ToTable("leagues", (string)null);
                });

            modelBuilder.Entity("Football.Data.Models.Nationality", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("BestPlayer")
                        .HasColumnType("int")
                        .HasColumnName("best_player");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PK__national__3213E83F76AEBCE6");

                    b.ToTable("nationality", (string)null);
                });

            modelBuilder.Entity("Football.Data.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<int>("NationalityId")
                        .HasColumnType("int")
                        .HasColumnName("nationality_id");

                    b.Property<int>("TeamId")
                        .HasColumnType("int")
                        .HasColumnName("team_id");

                    b.HasKey("Id")
                        .HasName("PK__players__3213E83FA51948D5");

                    b.HasIndex("NationalityId");

                    b.HasIndex("TeamId");

                    b.ToTable("players", (string)null);
                });

            modelBuilder.Entity("Football.Data.Models.PlayerTeam", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("MonthsActive")
                        .HasColumnType("int")
                        .HasColumnName("months_active");

                    b.Property<int>("PlayersId")
                        .HasColumnType("int")
                        .HasColumnName("players_id");

                    b.Property<int>("Salary")
                        .HasColumnType("int")
                        .HasColumnName("salary");

                    b.Property<int>("TeamId")
                        .HasColumnType("int")
                        .HasColumnName("team_id");

                    b.HasKey("Id")
                        .HasName("PK__player_t__3213E83F14B7283F");

                    b.HasIndex("PlayersId");

                    b.HasIndex("TeamId");

                    b.ToTable("player_teams", (string)null);
                });

            modelBuilder.Entity("Football.Data.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("CoachesId")
                        .HasColumnType("int")
                        .HasColumnName("coaches_id");

                    b.Property<int?>("LeagueId")
                        .HasColumnType("int")
                        .HasColumnName("league_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<int>("Trophies")
                        .HasColumnType("int")
                        .HasColumnName("trophies");

                    b.HasKey("Id")
                        .HasName("PK__teams__3213E83F83079E49");

                    b.HasIndex("CoachesId");

                    b.HasIndex("LeagueId");

                    b.ToTable("teams", (string)null);
                });

            modelBuilder.Entity("Football.Data.Models.Player", b =>
                {
                    b.HasOne("Football.Data.Models.Nationality", "Nationality")
                        .WithMany("Players")
                        .HasForeignKey("NationalityId")
                        .IsRequired()
                        .HasConstraintName("FK__players__nationa__2F10007B");

                    b.HasOne("Football.Data.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .IsRequired()
                        .HasConstraintName("FK__players__team_id__2E1BDC42");

                    b.Navigation("Nationality");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Football.Data.Models.PlayerTeam", b =>
                {
                    b.HasOne("Football.Data.Models.Player", "Players")
                        .WithMany("PlayerTeams")
                        .HasForeignKey("PlayersId")
                        .IsRequired()
                        .HasConstraintName("FK__player_te__playe__31EC6D26");

                    b.HasOne("Football.Data.Models.Team", "Team")
                        .WithMany("PlayerTeams")
                        .HasForeignKey("TeamId")
                        .IsRequired()
                        .HasConstraintName("FK__player_te__team___32E0915F");

                    b.Navigation("Players");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Football.Data.Models.Team", b =>
                {
                    b.HasOne("Football.Data.Models.Coach", "Coaches")
                        .WithMany("Teams")
                        .HasForeignKey("CoachesId")
                        .HasConstraintName("FK__teams__coaches_i__2B3F6F97");

                    b.HasOne("Football.Data.Models.League", "League")
                        .WithMany("Teams")
                        .HasForeignKey("LeagueId")
                        .HasConstraintName("FK__teams__league_id__2A4B4B5E");

                    b.Navigation("Coaches");

                    b.Navigation("League");
                });

            modelBuilder.Entity("Football.Data.Models.Coach", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Football.Data.Models.League", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Football.Data.Models.Nationality", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("Football.Data.Models.Player", b =>
                {
                    b.Navigation("PlayerTeams");
                });

            modelBuilder.Entity("Football.Data.Models.Team", b =>
                {
                    b.Navigation("PlayerTeams");

                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
