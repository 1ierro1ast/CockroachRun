using _Internal.CodeBase.Core.Cockroach;
using _Internal.CodeBase.Core.Threat;
using _Internal.CodeBase.Infrastructure.Services.AssetManagement;

namespace _Internal.CodeBase.Infrastructure.Services.Factories
{
    public class GameComponentsFactory : IGameComponentsFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameComponentsFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public Cockroach CreateCockroach()
        {
            return _assetProvider.Instantiate<Cockroach>(AssetPath.CockroachPath);
        }

        public Threat CreateThreat()
        {
            return _assetProvider.Instantiate<Threat>(AssetPath.ThreatPath);
        }
    }
}