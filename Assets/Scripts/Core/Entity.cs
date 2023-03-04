﻿using System;
using UnityEngine;

namespace AndreyGritsenko.MonoECS.Core
{
    public abstract class Entity : MonoBehaviour
    {
        public static Action<Entity> OnRegistered;
        public static Action<Entity> OnUnregistered;

        protected virtual void OnEntityCreate() { }
        protected virtual void OnEntityEnable() { }
        protected virtual void OnEntityDisable() { }
    }
}