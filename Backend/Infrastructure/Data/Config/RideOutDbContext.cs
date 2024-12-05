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

    public virtual DbSet<Messages> Messages { get; set; }

    public virtual DbSet<Notifications> Notifications { get; set; }

    public virtual DbSet<Participants> Participants { get; set; }

    public virtual DbSet<Reviews> Reviews { get; set; }

    public virtual DbSet<Rideouts> Rideouts { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.Updatedat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatedat");

            entity.HasOne(d => d.Hostuser).WithMany(p => p.Rideouts)
                .HasForeignKey(d => d.Hostuserid)
                .HasConstraintName("fk_host_user");
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
            entity.Property(e => e.Updatedat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("updatedat");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
