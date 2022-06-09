using System;
using System.Collections.Generic;
using _Internal.CodeBase.Core.States;
using _Internal.CodeBase.Infrastructure.StateMachine;
using UnityEngine.AI;

namespace _Internal.CodeBase.Core
{
    public class CockroachStateMachine : BaseStateMachine
    {
        public CockroachStateMachine(NavMeshAgent navMeshAgent, CockroachSensor cockroachSensor, Finish finish)
        {
            States = new Dictionary<Type, IExitableState>()
            {
                [typeof(RunToDestinationState)] =
                    new RunToDestinationState(this, navMeshAgent, cockroachSensor, finish),
                [typeof(RunAwayState)] = new RunAwayState(this, navMeshAgent, cockroachSensor)
            };
        }
    }
}