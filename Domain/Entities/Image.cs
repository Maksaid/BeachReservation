using Domain.Models;

namespace Domain.Entities;

public class Image
{
    public Image(Guid id, byte[] data, Guid beachId, PictureType pictureType)
    {
        Id = id;
        Data = data;
        BeachId = beachId;
        ImageType = pictureType.ToString();
    }

    protected Image()
    {
    }

    public Guid Id { get; set; }
    public byte[] Data { get; set; }
    
    public Guid? BeachId { get; set; }
    
    public string ImageType { get; set; }
}