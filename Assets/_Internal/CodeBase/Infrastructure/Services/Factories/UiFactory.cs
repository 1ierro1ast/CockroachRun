using _Internal.CodeBase.Infrastructure.Services.AssetManagement;

namespace _Internal.CodeBase.Infrastructure.Services.Factories
{
    public class UiFactory : IUiFactory
    {
        private IAssetProvider _assetProvider;

        public UiFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public void CreateHud()
        {
            var hud = _assetProvider.Instantiate(AssetPath.HudPath);
        }
    }
}