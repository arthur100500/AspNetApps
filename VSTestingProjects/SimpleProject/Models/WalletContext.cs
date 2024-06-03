using Microsoft.EntityFrameworkCore;

namespace VSTestingProjects.Models;

public class WalletContext : DbContext
{
    public DbSet<Wallet> CatPhotos { get; set; }
    private string DbPath { get; }

    public WalletContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "photos.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}