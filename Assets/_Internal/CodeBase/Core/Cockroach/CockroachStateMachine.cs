using System;
using System.Collections.Generic;
using _Internal.CodeBase.Core.Cockroach.States;
using _Internal.CodeBase.Infrastructure;
using _Internal.CodeBase.Infrastructure.StateMachine;
using UnityEngine;
using UnityEngine.AI;

namespace _Internal.CodeBase.Core.Cockroach
{
    public class CockroachStateMachine : BaseStateMachine
    {
        public CockroachStateMachine(NavMeshAgent navMeshAgent, CockroachSensor cockroachSensor, Finish finish,
            Transform levelStartPoint, ICoroutineRunner coroutineRunner)
        {
            States = new Dictionary<Type, IExitableState>()
            {
                [typeof(RunToDestinationState)] =
                    new RunToDestinationState(this, navMeshAgent, cockroachSensor, finish),
                [typeof(RunAwayState)] = new RunAwayState(this, navMeshAgent, levelStartPoint , coroutineRunner)
            };
        }
    }
}