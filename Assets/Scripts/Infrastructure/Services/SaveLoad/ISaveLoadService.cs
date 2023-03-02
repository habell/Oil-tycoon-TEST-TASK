using Infrastructure.Data;
using Unity.VisualScripting;

namespace Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService : ISaveService
    { }

    public interface ISaveService : ILoadService
    {
        void Save();
    }

    public interface ILoadService
    {
        void Load();
    }
}