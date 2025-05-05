using Tapsi.Ordering.Domain.Enums;

namespace Tapsi.Ordering.Application.Contract.Services;

public interface IImageService:IFileService
{
     void Compress(CompresstionLevel level);
     public void Resize(int width, int height);
     public void Resize(double factor);
}