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
        private ParticleSystem _hitParticle;
        private bool _isHitted = false;
        private float _speed;
        
        public override void Initialize(float force)
        {
            _speed = force;
            _hitParticle = GetComponent<ParticleSystem>();
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

                //IsVisible = false;
                _hitParticle.Play();
                Destroy(gameObject, 0.2f);
            }
            else
            {
                transform.position = finalPos;
            }
        }
    }
}
