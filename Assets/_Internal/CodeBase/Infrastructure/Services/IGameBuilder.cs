using _Internal.CodeBase.Core;
using _Internal.CodeBase.Infrastructure.Services.Factories;

namespace _Internal.CodeBase.Infrastructure.Services
{
    public interface IGameBuilder : IService
    {
        Level Build(ILevelFactory levelFactory, IGameComponentsFactory gameComponentsFactory,
            IInputService inputService, IUiFactory uiFactory);
    }
}