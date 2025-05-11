using System;
using System.Collections.Generic;
using Football.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Football.Data;

public partial class FootballContext : DbContext
{
    public FootballContext()
    {
    }

    public FootballContext(DbContextOptions<FootballContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Coach> Coaches { get; set; }

    public virtual DbSet<League> Leagues { get; set; }

    public virtual DbSet<Nationality> Nationalities { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayerTeam> PlayerTeams { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=football;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coach>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__coaches__3213E83FBE8D649A");

            entity.ToTable("coaches");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<League>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__leagues__3213E83FC1AF64E4");

            entity.ToTable("leagues");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Nationality>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__national__3213E83F76AEBCE6");

            entity.ToTable("nationality");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.BestPlayer).HasColumnName("best_player");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__players__3213E83FA51948D5");

            entity.ToTable("players");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.NationalityId).HasColumnName("nationality_id");
            entity.Property(e => e.TeamId).HasColumnName("team_id");

            entity.HasOne(d => d.Nationality).WithMany(p => p.Players)
                .HasForeignKey(d => d.NationalityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__players__nationa__2F10007B");

            entity.HasOne(d => d.Team).WithMany(p => p.Players)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__players__team_id__2E1BDC42");
        });

        modelBuilder.Entity<PlayerTeam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__player_t__3213E83F14B7283F");

            entity.ToTable("player_teams");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.MonthsActive).HasColumnName("months_active");
            entity.Property(e => e.PlayersId).HasColumnName("players_id");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.TeamId).HasColumnName("team_id");

            entity.HasOne(d => d.Players).WithMany(p => p.PlayerTeams)
                .HasForeignKey(d => d.PlayersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__player_te__playe__31EC6D26");

            entity.HasOne(d => d.Team).WithMany(p => p.PlayerTeams)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__player_te__team___32E0915F");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__teams__3213E83F83079E49");

            entity.ToTable("teams");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CoachesId).HasColumnName("coaches_id");
            entity.Property(e => e.LeagueId).HasColumnName("league_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Trophies).HasColumnName("trophies");

            entity.HasOne(d => d.Coaches).WithMany(p => p.Teams)
                .HasForeignKey(d => d.CoachesId)
                .HasConstraintName("FK__teams__coaches_i__2B3F6F97");

            entity.HasOne(d => d.League).WithMany(p => p.Teams)
                .HasForeignKey(d => d.LeagueId)
                .HasConstraintName("FK__teams__league_id__2A4B4B5E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
