using _Internal.CodeBase.Core.States;
using _Internal.CodeBase.Infrastructure;
using UnityEngine;
using UnityEngine.AI;

namespace _Internal.CodeBase.Core.Cockroach
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(CockroachSensor))]
    public class Cockroach : MonoBehaviour, ICoroutineRunner
    {
        private NavMeshAgent _navMeshAgent;
        private CockroachSensor _cockroachSensor;
        private CockroachStateMachine _cockroachStateMachine;
        private Finish _finish;

        public void Initialize(Transform levelStartPoint, Finish levelFinish)
        {
            SetStartPosition(levelStartPoint);
            _finish = levelFinish;

            _cockroachSensor = GetComponent<CockroachSensor>();
            _navMeshAgent = GetComponent<NavMeshAgent>();

            _cockroachStateMachine = new CockroachStateMachine(_navMeshAgent, _cockroachSensor, _finish, this);
            _cockroachStateMachine.Enter<RunToDestinationState>();
        }

        private void SetStartPosition(Transform levelStartPoint)
        {
            transform.position = levelStartPoint.position;
            transform.rotation = levelStartPoint.rotation;
        }
    }
}