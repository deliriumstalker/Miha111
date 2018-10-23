using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public abstract class BaseEnemy : BaseSceneObject, IDamageable
    {
        public float Health = 100f;
        public float TimeToDestroy = 3f;

        public virtual void ApplyDamage(float damage)
        {
            if (Health <= 0) return;

            Health -= damage;

            if (Health <= 0) Die();
        }

        public virtual void Die()
        {
            Destroy(gameObject, TimeToDestroy);
        }
    }
}
