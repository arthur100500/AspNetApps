namespace CatPhotoApi.Models;

public class CatPhoto
{
    public int CatPhotoId { get; set; }
    public string Url { get; set; }
    public string CatName { get; set; }

    public CatPhoto(string url, string catName)
    {
        Url = url;
        CatName = catName;
    }
}