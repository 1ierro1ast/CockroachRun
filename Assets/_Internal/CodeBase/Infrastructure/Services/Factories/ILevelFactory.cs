using _Internal.CodeBase.Core;

namespace _Internal.CodeBase.Infrastructure.Services.Factories
{
    public interface ILevelFactory : IService
    {
        Level CreateLevel(int levelNumber);
    }
}