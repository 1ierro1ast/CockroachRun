using System.Collections;
using _Internal.CodeBase.Infrastructure;
using _Internal.CodeBase.Infrastructure.StateMachine;
using UnityEngine;
using UnityEngine.AI;

namespace _Internal.CodeBase.Core.States
{
    public class RunAwayState : IPayloadedState<Threat.Threat>
    {
        private CockroachStateMachine _cockroachStateMachine;
        private readonly NavMeshAgent _navMeshAgent;
        private readonly CockroachSensor _cockroachSensor;
        private readonly ICoroutineRunner _coroutineRunner;

        public RunAwayState(CockroachStateMachine cockroachStateMachine, NavMeshAgent navMeshAgent,
            CockroachSensor cockroachSensor, ICoroutineRunner coroutineRunner)
        {
            _cockroachStateMachine = cockroachStateMachine;
            _navMeshAgent = navMeshAgent;
            _cockroachSensor = cockroachSensor;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter(Threat.Threat threat)
        {
            var targetPosition = (threat.transform.position - _navMeshAgent.transform.position).normalized *
                                 (threat.Radius + 5);
            _navMeshAgent.speed = 5;
            _navMeshAgent.SetDestination(targetPosition);
            //_coroutineRunner.StartCoroutine(CheckDestination());
        }

        public void Enter()
        {
        }

        public void Exit()
        {
            _navMeshAgent.speed = 3.5f;
        }

        private IEnumerator CheckDestination()
        {
            while (_navMeshAgent.pathStatus != NavMeshPathStatus.PathComplete)
            {
                yield return new WaitForEndOfFrame();
            }
            _cockroachStateMachine.Enter<RunToDestinationState>();
        }
    }
}