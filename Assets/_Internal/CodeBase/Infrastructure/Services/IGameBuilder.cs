using _Internal.CodeBase.Core;

namespace _Internal.CodeBase.Infrastructure.Services.Factories
{
    public interface IGameBuilder : IService
    {
        Level Build(ILevelFactory levelFactory, IGameComponentsFactory gameComponentsFactory,
            IInputService inputService, IUiFactory uiFactory);
    }
}