using _Internal.CodeBase.Infrastructure.Services.AssetManagement;

namespace _Internal.CodeBase.Infrastructure.Services.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public void CreateHud()
        {
            var hud = _assetProvider.Instantiate(AssetPath.HudPath);
        }
    }
}