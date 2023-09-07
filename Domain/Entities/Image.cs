using Domain.Models;

namespace Domain.Entities;

public class Image
{
    public Image(Guid id, byte[] data, Guid beachId)
    {
        Id = id;
        Data = data;
        BeachId = beachId;
    }

    protected Image()
    {
    }

    public Guid Id { get; set; }
    public byte[] Data { get; set; }
    
    public Guid? BeachId { get; set; }
    
}