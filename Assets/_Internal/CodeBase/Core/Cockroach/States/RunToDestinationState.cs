using _Internal.CodeBase.Infrastructure.StateMachine;

namespace _Internal.CodeBase.Core.States
{
    public class RunToDestinationState : IState
    {
        private CockroachStateMachine _cockroachStateMachine;
        public RunToDestinationState(CockroachStateMachine cockroachStateMachine)
        {
            _cockroachStateMachine = cockroachStateMachine;
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