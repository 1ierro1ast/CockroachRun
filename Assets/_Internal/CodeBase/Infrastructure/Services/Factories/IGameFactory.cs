using _Internal.CodeBase.Infrastructure.Services.AssetManagement;

namespace _Internal.CodeBase.Infrastructure.Services.Factories
{
    public interface IGameFactory : IService
    {
        void CreateHud();
    }
}