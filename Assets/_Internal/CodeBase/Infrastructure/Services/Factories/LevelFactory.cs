using _Internal.CodeBase.Core;
using _Internal.CodeBase.Infrastructure.Services.AssetManagement;

namespace _Internal.CodeBase.Infrastructure.Services.Factories
{
    public class LevelFactory : ILevelFactory
    {
        private readonly IAssetProvider _assetProvider;

        public LevelFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public Level CreateLevel(int levelNumber)
        {
            Level level = _assetProvider.Instantiate<Level>(AssetPath.LevelPrefabsPath + $"/Level{levelNumber}");
            return level;
        }
    }
}