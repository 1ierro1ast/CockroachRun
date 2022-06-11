using _Internal.CodeBase.Infrastructure.StateMachine;
using UnityEngine;
using UnityEngine.AI;

namespace _Internal.CodeBase.Core.States
{
    public class RunToDestinationState : IState
    {
        private readonly NavMeshAgent _navMeshAgent;
        private readonly CockroachSensor _cockroachSensor;
        private readonly CockroachStateMachine _cockroachStateMachine;
        private readonly Finish _finish;

        public RunToDestinationState(CockroachStateMachine cockroachStateMachine, NavMeshAgent navMeshAgent,
            CockroachSensor cockroachSensor, Finish finish)
        {
            _cockroachStateMachine = cockroachStateMachine;
            _navMeshAgent = navMeshAgent;
            _cockroachSensor = cockroachSensor;
            _finish = finish;
        }

        public void Exit()
        {
            _cockroachSensor.ReachedTheFinish -= CockroachSensorOnReachedTheFinish;
            _cockroachSensor.ThreatDetected -= CockroachSensorOnThreatDetected;
        }

        public void Enter()
        {
            _navMeshAgent.SetDestination(_finish.transform.position);

            _cockroachSensor.ReachedTheFinish += CockroachSensorOnReachedTheFinish;
            _cockroachSensor.ThreatDetected += CockroachSensorOnThreatDetected;
        }

        private void CockroachSensorOnThreatDetected(Threat.Threat threat)
        {
            _cockroachStateMachine.Enter<RunAwayState>();
        }

        private void CockroachSensorOnReachedTheFinish()
        {
            _finish.BroadcastFinish();
        }
    }
}