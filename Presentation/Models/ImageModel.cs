using Domain.Models;

namespace Presentation.Models;

public record ImageModel(byte[] Data, Guid BeachId, PictureType PictureType){}