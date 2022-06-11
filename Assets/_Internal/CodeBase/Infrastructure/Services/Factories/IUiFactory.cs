using _Internal.CodeBase.Core.Ui;

namespace _Internal.CodeBase.Infrastructure.Services.Factories
{
    public interface IUiFactory : IService
    {
        Hud CreateHud();
        FinishPopup CreateFinishPopup();
    }
}