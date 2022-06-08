using _Internal.CodeBase.Infrastructure.Services.Factories;

namespace _Internal.CodeBase.Infrastructure.StateMachine.States
{
    public class FinishState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPopupFactory _popupFactory;

        public FinishState(GameStateMachine gameStateMachine, IPopupFactory popupFactory)
        {
            _gameStateMachine = gameStateMachine;
            _popupFactory = popupFactory;
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }

        public void Enter()
        {
            throw new System.NotImplementedException();
        }
    }
}