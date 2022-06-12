using _Internal.CodeBase.Core.Ui;
using _Internal.CodeBase.Infrastructure.Services.Factories;

namespace _Internal.CodeBase.Infrastructure.StateMachine.States
{
    public class FinishState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IUiFactory _uiFactory;

        public FinishState(GameStateMachine gameStateMachine, IUiFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            FinishPopup finishPopup = _uiFactory.CreateFinishPopup();
            finishPopup.TryAgainButton.onClick.AddListener(OnTryAgainButtonClick);
            finishPopup.Open();
        }
        
        private void OnTryAgainButtonClick()
        {
            _gameStateMachine.Enter<LoadGameState, string>("GameScene");
        }
    }
}