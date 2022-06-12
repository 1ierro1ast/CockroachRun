using _Internal.CodeBase.Core.Ui;
using _Internal.CodeBase.Infrastructure.Services.AssetManagement;

namespace _Internal.CodeBase.Infrastructure.Services.Factories
{
    public class UiFactory : IUiFactory
    {
        private readonly IAssetProvider _assetProvider;

        public UiFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public Hud CreateHud()
        {
            return _assetProvider.Instantiate<Hud>(AssetPath.HudPath);
        }

        public FinishPopup CreateFinishPopup()
        {
            return _assetProvider.Instantiate<FinishPopup>(AssetPath.FinishPopupPath);
        }
    }
}