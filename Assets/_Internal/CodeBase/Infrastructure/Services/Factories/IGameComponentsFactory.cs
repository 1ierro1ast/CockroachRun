using _Internal.CodeBase.Core.Cockroach;
using _Internal.CodeBase.Core.Threat;

namespace _Internal.CodeBase.Infrastructure.Services.Factories
{
    public interface IGameComponentsFactory : IService
    {
        Cockroach CreateCockroach();
        Threat CreateThreat();
    }
}