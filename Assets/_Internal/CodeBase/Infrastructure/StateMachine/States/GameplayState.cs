using _Internal.CodeBase.Core;
using _Internal.CodeBase.Infrastructure.Services.Factories;

namespace _Internal.CodeBase.Infrastructure.StateMachine.States
{
    public class GameplayState : IPayloadedState<Level>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPopupFactory _popupFactory;
        
        public GameplayState(GameStateMachine gameStateMachine, IPopupFactory popupFactory)
        {
            _gameStateMachine = gameStateMachine;
            _popupFactory = popupFactory;
        }

        public void Enter(Level level)
        {
        }

        public void Exit()
        {
        }
    }
}