using System.Collections;
using System.Collections.Generic;
using FPS;
using UnityEngine;

namespace FPS
{
    public class Bullet : BaseAmmo
    {
        [SerializeField] private float _destroyTime = 2f;
        [SerializeField] private LayerMask _layerMask;

        private bool _isHitted = false;
        private float _speed;
        
        public override void Initialize(float force)
        {
            _speed = force;
        }

        private void FixedUpdate()
        {
            if (_isHitted) return;

            Vector3 finalPos = transform.position + transform.forward * _speed * Time.fixedDeltaTime;
            RaycastHit hit;
            if (Physics.Linecast(transform.position, finalPos, out hit, _layerMask))
            {
                _isHitted = true;
                transform.position = hit.point;

                IDamageable d = hit.collider.GetComponent<IDamageable>();
                if (d != null) d.ApplyDamage(_damage);

                Destroy(gameObject, 0.3f);
            }
            else
            {
                transform.position = finalPos;
            }
        }
    }
}
