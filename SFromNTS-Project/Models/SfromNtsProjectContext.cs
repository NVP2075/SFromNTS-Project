using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SFromNTS_Project.Models;

public partial class SfromNtsProjectContext : DbContext
{
    public SfromNtsProjectContext()
    {
    }

    public SfromNtsProjectContext(DbContextOptions<SfromNtsProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PostComment> PostComments { get; set; }

    public virtual DbSet<PostView> PostViews { get; set; }

    public virtual DbSet<PostedDocument> PostedDocuments { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    public virtual DbSet<UserInformation> UserInformations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SFromNTS-Project;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PostComment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__PostComm__C3B4DFAA7548CC62");

            entity.ToTable("PostComment");

            entity.Property(e => e.CommentId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("CommentID");
            entity.Property(e => e.CommentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CommentStatus).HasDefaultValue(true);
            entity.Property(e => e.Content).HasMaxLength(500);
            entity.Property(e => e.ParentCommentId).HasColumnName("ParentCommentID");
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.ParentComment).WithMany(p => p.InverseParentComment)
                .HasForeignKey(d => d.ParentCommentId)
                .HasConstraintName("FK__PostComme__Paren__66603565");

            entity.HasOne(d => d.Post).WithMany(p => p.PostComments)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__PostComme__PostI__656C112C");

            entity.HasOne(d => d.User).WithMany(p => p.PostComments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__PostComme__UserI__6477ECF3");
        });

        modelBuilder.Entity<PostView>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__PostView__AA126038872173E5");

            entity.ToTable("PostView");

            entity.Property(e => e.PostId)
                .ValueGeneratedNever()
                .HasColumnName("PostID");
            entity.Property(e => e.ViewCount).HasDefaultValue(0);

            entity.HasOne(d => d.Post).WithOne(p => p.PostView)
                .HasForeignKey<PostView>(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostView__PostID__59FA5E80");
        });

        modelBuilder.Entity<PostedDocument>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__PostedDo__AA126038FADEAC81");

            entity.ToTable("PostedDocument");

            entity.Property(e => e.PostId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("PostID");
            entity.Property(e => e.DocStatus).HasDefaultValue(true);
            entity.Property(e => e.DocumentDescribe).HasMaxLength(300);
            entity.Property(e => e.DocumentTitle).HasMaxLength(150);
            entity.Property(e => e.DocumentType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PostDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.PostedDocuments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__PostedDoc__UserI__571DF1D5");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserAcco__1788CCACAFDDC90E");

            entity.ToTable("UserAccount");

            entity.HasIndex(e => e.AccountName, "UQ__UserAcco__406E0D2ED3389B8D").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__UserAcco__A9D10534D2DABE43").IsUnique();

            entity.Property(e => e.UserId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("UserID");
            entity.Property(e => e.AccountName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.AccountStatus).HasDefaultValue(true);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HashedPassword)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserInformation>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserInfo__1788CCACE4EF8B7C");

            entity.ToTable("UserInformation");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Occupation).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(20);
            entity.Property(e => e.UserSurname).HasMaxLength(20);

            entity.HasOne(d => d.User).WithOne(p => p.UserInformation)
                .HasForeignKey<UserInformation>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserInfor__UserI__5165187F");

            entity.HasMany(d => d.Posts).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "PostLike",
                    r => r.HasOne<PostedDocument>().WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PostLike__PostID__5EBF139D"),
                    l => l.HasOne<UserInformation>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PostLike__UserID__5DCAEF64"),
                    j =>
                    {
                        j.HasKey("UserId", "PostId").HasName("PK__PostLike__8D29EAAFBFC605E3");
                        j.ToTable("PostLike");
                        j.IndexerProperty<Guid>("UserId").HasColumnName("UserID");
                        j.IndexerProperty<Guid>("PostId").HasColumnName("PostID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
