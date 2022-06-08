using UnityEngine;
using UnityEngine.AI;

namespace _Internal.CodeBase.Core.Cockroach
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(CockroachSensor))]
    public class Cockroach : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        private CockroachSensor _cockroachSensor;
        private CockroachStateMachine _cockroachStateMachine;

        private void Awake()
        {
            _cockroachSensor = GetComponent<CockroachSensor>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _cockroachStateMachine = new CockroachStateMachine(_navMeshAgent, _cockroachSensor);
        }
    }
}