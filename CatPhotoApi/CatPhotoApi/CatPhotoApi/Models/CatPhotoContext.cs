namespace CatPhotoApi.Models;
using Microsoft.EntityFrameworkCore;

public class CatPhotoContext : DbContext
{
    public DbSet<CatPhoto> CatPhotos { get; set; }
    private string DbPath { get; }
    
    public CatPhotoContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "photos.db");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}