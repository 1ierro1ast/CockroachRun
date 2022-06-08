using _Internal.CodeBase.Infrastructure.StateMachine;

namespace _Internal.CodeBase.Core.States
{
    public class RunAwayState : IState
    {
        private CockroachStateMachine _cockroachStateMachine;
        public RunAwayState(CockroachStateMachine cockroachStateMachine)
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