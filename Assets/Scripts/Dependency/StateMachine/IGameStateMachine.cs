﻿namespace MonoEcs.Dependency.StateMachine
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : class, IEnterState;
        void Enter<TState, TLoad>(TLoad load) where TState : class, IEnterLoadState<TLoad>;
    }
}