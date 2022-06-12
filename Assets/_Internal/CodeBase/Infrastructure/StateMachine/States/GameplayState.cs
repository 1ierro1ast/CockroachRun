using _Internal.CodeBase.Core;

namespace _Internal.CodeBase.Infrastructure.StateMachine.States
{
    public class GameplayState : IPayloadedState<Level>
    {
        private readonly GameStateMachine _gameStateMachine;
        
        public GameplayState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter(Level level)
        {
            level.Finish.EndGameEvent += FinishOnEndGameEvent;
        }

        private void FinishOnEndGameEvent()
        {
            _gameStateMachine.Enter<FinishState>();
        }

        public void Exit()
        {
        }
    }
}