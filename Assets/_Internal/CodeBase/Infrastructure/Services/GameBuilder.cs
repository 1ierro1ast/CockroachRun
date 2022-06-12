using _Internal.CodeBase.Core;
using _Internal.CodeBase.Core.Cockroach;
using _Internal.CodeBase.Core.Threat;
using _Internal.CodeBase.Core.Ui;
using _Internal.CodeBase.Infrastructure.Services.Factories;

namespace _Internal.CodeBase.Infrastructure.Services
{
    public class GameBuilder : IGameBuilder
    {
        public Level Build(ILevelFactory levelFactory, IGameComponentsFactory gameComponentsFactory,
            IInputService inputService, IUiFactory uiFactory)
        {
            Level level = levelFactory.CreateLevel();

            Cockroach cockroach = gameComponentsFactory.CreateCockroach();
            Threat threat = gameComponentsFactory.CreateThreat();
            Hud hud = uiFactory.CreateHud();

            cockroach.Initialize(level.StartPoint, level.Finish);
            threat.Initialize(inputService);
            hud.RadiusView.Initialize(threat.ThreatScaler);
            
            return level;
        }
    }
}