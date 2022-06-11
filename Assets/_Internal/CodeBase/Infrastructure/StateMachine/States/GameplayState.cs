using _Internal.CodeBase.Core;
using _Internal.CodeBase.Core.Ui;
using _Internal.CodeBase.Infrastructure.Services.Factories;

namespace _Internal.CodeBase.Infrastructure.StateMachine.States
{
    public class GameplayState : IPayloadedState<Level>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IUiFactory _uiFactory;
        
        public GameplayState(GameStateMachine gameStateMachine, IUiFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
        }

        public void Enter(Level level)
        {
            level.Finish.EndGameEvent += FinishOnEndGameEvent;
        }

        private void FinishOnEndGameEvent()
        {
            FinishPopup finishPopup = _uiFactory.CreateFinishPopup();
            finishPopup.TryAgainButton.onClick.AddListener(OnTryAgainButtonClick);
        }

        private void OnTryAgainButtonClick()
        {
            _gameStateMachine.Enter<LoadGameState, string>("GameScene");
        }

        public void Exit()
        {
        }
    }
}