using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Rideout.Domain.Models;

namespace Rideout.Infrastructure.Data.Config;

public partial class RideOutDbContext : DbContext
{
    public RideOutDbContext()
    {
    }

    public RideOutDbContext(DbContextOptions<RideOutDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Losses> Losses { get; set; }

    public virtual DbSet<Messages> Messages { get; set; }

    public virtual DbSet<Notifications> Notifications { get; set; }

    public virtual DbSet<Participants> Participants { get; set; }

    public virtual DbSet<Reviews> Reviews { get; set; }

    public virtual DbSet<Rideouts> Rideouts { get; set; }

    public virtual DbSet<Rides> Rides { get; set; }

    public virtual DbSet<Stats> Stats { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    public virtual DbSet<Vehicle> Vehicle { get; set; }

    public virtual DbSet<Wins> Wins { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Losses>(entity =>
        {
            entity.HasKey(e => e.Lossid).HasName("losses_pkey");

            entity.ToTable("losses");

            entity.Property(e => e.Lossid).HasColumnName("lossid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("createdat");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Details).HasColumnName("details");
            entity.Property(e => e.Rideid).HasColumnName("rideid");
            entity.Property(e => e.Rideoutid).HasColumnName("rideoutid");
            entity.Property(e => e.Updatedat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("updatedat");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Ride).WithMany(p => p.Losses)
                .HasForeignKey(d => d.Rideid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_ride_losses");

            entity.HasOne(d => d.Rideout).WithMany(p => p.Losses)
                .HasForeignKey(d => d.Rideoutid)
                .HasConstraintName("fk_rideout_losses");

            entity.HasOne(d => d.User).WithMany(p => p.Losses)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("fk_user_losses");
        });

        modelBuilder.Entity<Messages>(entity =>
        {
            entity.HasKey(e => e.Messageid).HasName("messages_pkey");

            entity.ToTable("messages");

            entity.HasIndex(e => e.Rideoutid, "idx_messages_rideout");

            entity.HasIndex(e => e.Senderuserid, "idx_messages_sender");

            entity.Property(e => e.Messageid).HasColumnName("messageid");
            entity.Property(e => e.Messagetext).HasColumnName("messagetext");
            entity.Property(e => e.Rideoutid).HasColumnName("rideoutid");
            entity.Property(e => e.Senderuserid).HasColumnName("senderuserid");
            entity.Property(e => e.Sentat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("sentat");

            entity.HasOne(d => d.Rideout).WithMany(p => p.Messages)
                .HasForeignKey(d => d.Rideoutid)
                .HasConstraintName("fk_rideout");

            entity.HasOne(d => d.Senderuser).WithMany(p => p.Messages)
                .HasForeignKey(d => d.Senderuserid)
                .HasConstraintName("fk_sender");
        });

        modelBuilder.Entity<Notifications>(entity =>
        {
            entity.HasKey(e => e.Notificationid).HasName("notifications_pkey");

            entity.ToTable("notifications");

            entity.Property(e => e.Notificationid).HasColumnName("notificationid");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.Isread)
                .HasDefaultValue(false)
                .HasColumnName("isread");
            entity.Property(e => e.Sentat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("sentat");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("notifications_userid_fkey");
        });

        modelBuilder.Entity<Participants>(entity =>
        {
            entity.HasKey(e => e.Participantid).HasName("participants_pkey");

            entity.ToTable("participants");

            entity.Property(e => e.Participantid).HasColumnName("participantid");
            entity.Property(e => e.Joinedat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("joinedat");
            entity.Property(e => e.Rideoutid).HasColumnName("rideoutid");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Rideout).WithMany(p => p.Participants)
                .HasForeignKey(d => d.Rideoutid)
                .HasConstraintName("participants_rideoutid_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Participants)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("participants_userid_fkey");
        });

        modelBuilder.Entity<Reviews>(entity =>
        {
            entity.HasKey(e => e.Reviewid).HasName("reviews_pkey");

            entity.ToTable("reviews");

            entity.HasIndex(e => e.Rideoutid, "idx_rideout_reviews");

            entity.HasIndex(e => e.Userid, "idx_user_reviews");

            entity.Property(e => e.Reviewid).HasColumnName("reviewid");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Reviewedat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("reviewedat");
            entity.Property(e => e.Rideoutid).HasColumnName("rideoutid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Rideout).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.Rideoutid)
                .HasConstraintName("fk_rideout");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("fk_user");
        });

        modelBuilder.Entity<Rideouts>(entity =>
        {
            entity.HasKey(e => e.Rideoutid).HasName("rideouts_pkey");

            entity.ToTable("rideouts");

            entity.Property(e => e.Rideoutid).HasColumnName("rideoutid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Datetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datetime");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Hostuserid).HasColumnName("hostuserid");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            entity.Property(e => e.Maxparticipants)
                .HasDefaultValue(0)
                .HasColumnName("maxparticipants");
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(255)
                .HasColumnName("thumbnail");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.Updatedat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatedat");
            entity.Property(e => e.Vehicletype).HasColumnName("vehicletype");

            entity.HasOne(d => d.Hostuser).WithMany(p => p.Rideouts)
                .HasForeignKey(d => d.Hostuserid)
                .HasConstraintName("fk_host_user");

            entity.HasOne(d => d.VehicletypeNavigation).WithMany(p => p.Rideouts)
                .HasForeignKey(d => d.Vehicletype)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_vehicle_type");
        });

        modelBuilder.Entity<Rides>(entity =>
        {
            entity.HasKey(e => e.Rideid).HasName("rides_pkey");

            entity.ToTable("rides");

            entity.Property(e => e.Rideid).HasColumnName("rideid");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .HasColumnName("color");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("createdat");
            entity.Property(e => e.Isprimary).HasColumnName("isprimary");
            entity.Property(e => e.Updatedat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("updatedat");
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Vehicleid).HasColumnName("vehicleid");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.User).WithMany(p => p.Rides)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_user");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Rides)
                .HasForeignKey(d => d.Vehicleid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_vehicle");
        });

        modelBuilder.Entity<Stats>(entity =>
        {
            entity.HasKey(e => e.Statid).HasName("stats_pkey");

            entity.ToTable("stats");

            entity.Property(e => e.Statid).HasColumnName("statid");
            entity.Property(e => e.Averagespeed)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("0.00")
                .HasColumnName("averagespeed");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("createdat");
            entity.Property(e => e.Losses)
                .HasDefaultValue(0)
                .HasColumnName("losses");
            entity.Property(e => e.Rideid).HasColumnName("rideid");
            entity.Property(e => e.Totaldistance)
                .HasDefaultValue(0)
                .HasColumnName("totaldistance");
            entity.Property(e => e.Totalrides)
                .HasDefaultValue(0)
                .HasColumnName("totalrides");
            entity.Property(e => e.Updatedat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("updatedat");
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Wins)
                .HasDefaultValue(0)
                .HasColumnName("wins");

            entity.HasOne(d => d.Ride).WithMany(p => p.Stats)
                .HasForeignKey(d => d.Rideid)
                .HasConstraintName("fk_ride_stats");

            entity.HasOne(d => d.User).WithMany(p => p.Stats)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("fk_user_stats");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Bio).HasColumnName("bio");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("createdat");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Passwordhash).HasColumnName("passwordhash");
            entity.Property(e => e.Profilepicture).HasColumnName("profilepicture");
            entity.Property(e => e.Rideid).HasColumnName("rideid");
            entity.Property(e => e.Statid).HasColumnName("statid");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Updatedat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("updatedat");

            entity.HasOne(d => d.Ride).WithMany(p => p.Users)
                .HasForeignKey(d => d.Rideid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_ride");

            entity.HasOne(d => d.Stat).WithMany(p => p.Users)
                .HasForeignKey(d => d.Statid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_stats");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.Vehicleid).HasName("vehicle_pkey");

            entity.ToTable("vehicle");

            entity.Property(e => e.Vehicleid).HasColumnName("vehicleid");
            entity.Property(e => e.Vehicle1)
                .HasMaxLength(50)
                .HasColumnName("vehicle");
        });

        modelBuilder.Entity<Wins>(entity =>
        {
            entity.HasKey(e => e.Winid).HasName("wins_pkey");

            entity.ToTable("wins");

            entity.Property(e => e.Winid).HasColumnName("winid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("createdat");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Details).HasColumnName("details");
            entity.Property(e => e.Rideid).HasColumnName("rideid");
            entity.Property(e => e.Rideoutid).HasColumnName("rideoutid");
            entity.Property(e => e.Updatedat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("updatedat");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Ride).WithMany(p => p.Wins)
                .HasForeignKey(d => d.Rideid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_ride_wins");

            entity.HasOne(d => d.Rideout).WithMany(p => p.Wins)
                .HasForeignKey(d => d.Rideoutid)
                .HasConstraintName("fk_rideout_wins");

            entity.HasOne(d => d.User).WithMany(p => p.Wins)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("fk_user_wins");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
