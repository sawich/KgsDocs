using Api.Infrastructure.Persistent.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Persistent;

public sealed class PersistentContext(DbContextOptions<PersistentContext> options) : IdentityUserContext<UserModel>(options)
{
    public DbSet<TaskModel> Tasks => Set<TaskModel>();
    public DbSet<FileModel> Files => Set<FileModel>();
    public DbSet<HistoryModel> Histories => Set<HistoryModel>();
    public DbSet<DocumentModel> Documents => Set<DocumentModel>();
    public DbSet<DiscussionModel> Discussions => Set<DiscussionModel>();
    public DbSet<FamiliarizationModel> Familiarizations => Set<FamiliarizationModel>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<TaskModel>().HasKey(e => e.Id);
        builder.Entity<TaskModel>().HasOne(e => e.Author).WithMany(e => e.Tasks);

        builder.Entity<FileModel>().HasKey(e => e.Id);
        builder.Entity<HistoryModel>().HasKey(e => e.Id);
        builder.Entity<DocumentModel>().HasKey(e => e.Id);
        builder.Entity<DiscussionModel>().HasKey(e => e.Id);
        builder.Entity<FamiliarizationModel>().HasKey(e => e.Id);

        base.OnModelCreating(builder);
    }
}
