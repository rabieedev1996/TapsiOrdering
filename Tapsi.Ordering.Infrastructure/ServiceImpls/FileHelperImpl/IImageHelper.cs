using Tapsi.Ordering.Domain.Enums;

namespace Tapsi.Ordering.Infrastructure.ServiceImpls.FileHelperImpl;

public interface IImageHelper
{
    byte[] Compress(byte[] bytes, CompresstionLevel level);
}