using System.Collections;
using _Internal.CodeBase.Infrastructure;
using _Internal.CodeBase.Infrastructure.StateMachine;
using UnityEngine;
using UnityEngine.AI;

namespace _Internal.CodeBase.Core.Cockroach.States
{
    public class RunAwayState : IState
    {
        private readonly CockroachStateMachine _cockroachStateMachine;
        private readonly NavMeshAgent _navMeshAgent;
        private readonly Transform _levelStartPoint;
        private readonly ICoroutineRunner _coroutineRunner;

        public RunAwayState(CockroachStateMachine cockroachStateMachine, NavMeshAgent navMeshAgent, 
            Transform levelStartPoint, ICoroutineRunner coroutineRunner)
        {
            _cockroachStateMachine = cockroachStateMachine;
            _navMeshAgent = navMeshAgent;
            _levelStartPoint = levelStartPoint;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter()
        {
            var targetPosition = GetRandomPointNearToStartPoint(4);
            _navMeshAgent.speed = 5;
            _navMeshAgent.SetDestination(targetPosition);
            _coroutineRunner.StartCoroutine(RunAwayTimer(2));
        }

        private Vector3 GetRandomPointNearToStartPoint(float radius = 1)
        {
            var randomPoint = Random.insideUnitCircle * radius ;
            return new Vector3(randomPoint.x, 0, randomPoint.y) + _levelStartPoint.position;
        }

        public void Exit()
        {
            _navMeshAgent.speed = 3.5f;
        }

        private IEnumerator RunAwayTimer(float time)
        {
            yield return new WaitForSeconds(time);
            _cockroachStateMachine.Enter<RunToDestinationState>();
        }
    }
}