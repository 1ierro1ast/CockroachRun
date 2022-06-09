using _Internal.CodeBase.Core;
using _Internal.CodeBase.Core.Cockroach;
using _Internal.CodeBase.Core.Threat;

namespace _Internal.CodeBase.Infrastructure.Services.Factories
{
    public class GameBuilder : IGameBuilder
    {
        public Level Build(ILevelFactory levelFactory, IGameComponentsFactory gameComponentsFactory,
            IInputService inputService)
        {
            Level level = levelFactory.CreateLevel();

            Cockroach cockroach = gameComponentsFactory.CreateCockroach();
            Threat threat = gameComponentsFactory.CreateThreat();

            cockroach.Initialize(level.StartPoint, level.Finish);
            threat.Initialize(inputService);
            return level;
        }
    }
}