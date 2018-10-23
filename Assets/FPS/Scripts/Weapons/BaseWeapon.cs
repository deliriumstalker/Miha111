using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public abstract class BaseWeapon : BaseSceneObject
    {
        //[SerializeField] protected float _bulletPrefab;
        [SerializeField] protected float _force;
        [SerializeField] protected float _timeout = 0.5f;
        [SerializeField] protected float _reloadTime;
        [SerializeField] protected BaseAmmo _ammoPrefab;
        [SerializeField] protected AudioSource audioSource;
        [SerializeField] protected bool _isFiring = false;
        public bool IsFiring
        {
            get { return _isFiring; }
        }

        public bool IsAuto = false;
        private float _reloadTimer;
        protected float _lastShotTime;
        public AudioClip ShotClip;

        public abstract void Fire();

        public virtual void UnFire()
        {
            //ничего
        }
        public abstract void Reload();

        protected bool TryShoot()
        {
            if (Time.time - _lastShotTime < _timeout) return false;
            _lastShotTime = Time.time;
            audioSource.PlayOneShot(ShotClip, 0.5f);
            return true;
        }

        void Awake()
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
}
