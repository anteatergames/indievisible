using System.Threading.Tasks;

namespace IndieVisible.Application.Interfaces
{
    public interface IImageStorageService
    {
        Task<string> StoreImageAsync(string container, string filename, byte[] image);

        Task<string> DeleteImageAsync(string container, string filename);
    }
}
