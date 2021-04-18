using System.Threading;
using System.Threading.Tasks;

namespace Salon.CustomerBase.Core.Interfaces
{
    public interface IFileSystem
    {
        Task<bool> SavePicture(string pictureName, string pictureBase64, CancellationToken cancellationToken);
    }
}
