using System.Collections;
using System.Collections.Generic;
using FPS;
using UnityEngine;

namespace FPS
{
    public abstract class BaseAmmo : BaseSceneObject
    {
        [SerializeField] protected float _damage = 20f;

        public abstract void Initialize(float force);
    }
}