using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Entities;
#nullable disable

namespace SignLanguage.Models
{
    public partial class SignLanguageDBContext : DbContext
    {
        public SignLanguageDBContext()
        {
        }

        public SignLanguageDBContext(DbContextOptions<SignLanguageDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        //public virtual DbSet<Text> Texts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Word> Words { get; set; }
        public virtual DbSet<WordToText> WordToTexts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=srv2\\pupils;Database=SignLanguageDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(10);
            });


            //modelBuilder.Entity<Text>(entity =>
            //{
            //    entity.ToTable("Text");

            //    entity.Property(e => e.TextId).ValueGeneratedNever();

            //    entity.Property(e => e.TextValue)
            //        .IsRequired()
            //        .HasMaxLength(400);
            //});

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UserFirstName)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.UserLastName)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.UserSalt)
                   .HasMaxLength(50)
                   .IsFixedLength(true);

            });
            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("RATING");

                entity.Property(e => e.RatingId).HasColumnName("RATING_ID");

                entity.Property(e => e.Host)
                    .HasColumnName("HOST")
                    .HasMaxLength(50);

                entity.Property(e => e.Method)
                    .HasColumnName("METHOD")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Path)
                    .HasColumnName("PATH")
                    .HasMaxLength(50);

                entity.Property(e => e.RecordDate)
                 .HasColumnName("Record_Date")
                 .HasColumnType("datetime");

                entity.Property(e => e.Referer)
                    .HasColumnName("REFERER")
                    .HasMaxLength(100);

                entity.Property(e => e.UserAgent).HasColumnName("USER_AGENT");
            });

            modelBuilder.Entity<Word>(entity =>
            {
                entity.ToTable("Word");

                entity.Property(e => e.WordId).ValueGeneratedNever();

                entity.Property(e => e.NameWord)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.SignWord)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<WordToText>(entity =>
            {
                entity.HasKey(e => new { e.TextId, e.WordId });

                entity.ToTable("WordToText");
            });

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
