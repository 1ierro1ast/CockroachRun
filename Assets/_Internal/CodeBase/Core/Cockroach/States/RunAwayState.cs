using _Internal.CodeBase.Infrastructure.StateMachine;
using UnityEngine.AI;

namespace _Internal.CodeBase.Core.States
{
    public class RunAwayState : IPayloadedState<Threat.Threat>
    {
        private CockroachStateMachine _cockroachStateMachine;
        private readonly NavMeshAgent _navMeshAgent;
        private readonly CockroachSensor _cockroachSensor;

        public RunAwayState(CockroachStateMachine cockroachStateMachine, NavMeshAgent navMeshAgent,
            CockroachSensor cockroachSensor)
        {
            _cockroachStateMachine = cockroachStateMachine;
            _navMeshAgent = navMeshAgent;
            _cockroachSensor = cockroachSensor;
        }

        public void Enter(Threat.Threat payload)
        {
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }
    }
}