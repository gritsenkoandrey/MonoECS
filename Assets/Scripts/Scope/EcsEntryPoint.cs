﻿using System;
using MonoEcs.Core;
using MonoEcs.Example.Components;
using MonoEcs.Example.EntityOne;
using MonoEcs.Example.EntityTwo;
using VContainer.Unity;

namespace MonoEcs.Scope
{
    public sealed class EcsEntryPoint : IInitializable, IStartable, ITickable, IFixedTickable, ILateTickable, IDisposable
    {
        private readonly EcsWorld _ecsWorld;

        public EcsEntryPoint()
        {
            _ecsWorld = new EcsWorld();
        }
        
        void IInitializable.Initialize()
        {
            _ecsWorld.BindComponent<DebugOneComponent>();
            _ecsWorld.BindComponent<DebugTwoComponent>();

            _ecsWorld.BindSystem(new DebugInitSystem(_ecsWorld));
            _ecsWorld.BindSystem(new ColorInitSystem(_ecsWorld));
            
            _ecsWorld.BindSystem(new DebugRunSystem(_ecsWorld));
            _ecsWorld.BindSystem(new ColorRunSystem(_ecsWorld));
        }

        void IStartable.Start() => _ecsWorld.EnableSystem();

        void ITickable.Tick() => _ecsWorld.Update();

        void IFixedTickable.FixedTick() => _ecsWorld.FixedUpdate();

        void ILateTickable.LateTick() => _ecsWorld.LateUpdate();

        void IDisposable.Dispose() => _ecsWorld.DisableSystem();
    }
}