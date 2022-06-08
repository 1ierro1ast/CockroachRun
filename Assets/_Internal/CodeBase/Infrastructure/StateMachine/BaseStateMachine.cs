using System;
using System.Collections.Generic;

namespace _Internal.CodeBase.Infrastructure.StateMachine
{
    public abstract class BaseStateMachine
    {
        protected IExitableState ActiveState;
        protected Dictionary<Type, IExitableState> States;

        public void Enter<TState>() where TState : class, IState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            var state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            ActiveState?.Exit();
            
            var state = GetState<TState>();
            ActiveState = state;
            
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
        {
            return States[typeof(TState)] as TState;
        }
    }
}