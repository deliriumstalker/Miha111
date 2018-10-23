using System.Collections;
using System.Collections.Generic;
using FPS;
using UnityEngine;

namespace FPS
{
    public class AutomaticWeapon : BaseWeapon
    {
        [SerializeField] private Transform _firePoint;

        public override void Fire()
        {
            if (!_isFiring)
            {
                StartCoroutine("RapidFire");
                _isFiring = true;
            }
        }

        public override void UnFire()
        {
            StopCoroutine("RapidFire");
            _isFiring = false;
        }

        public void AutoFire()
        {
            audioSource.PlayOneShot(ShotClip, 0.5f);
            BaseAmmo bullet = Instantiate(_ammoPrefab, _firePoint.position, _firePoint.rotation);
            bullet.Initialize(_force);
        }

        public override void Reload()
        {
            //потом
        }


        IEnumerator RapidFire()
        {
            while (true)
            {
                AutoFire();
                yield return new WaitForSeconds(_timeout);
            }
        }

        void Awake()
        {
            IsAuto = true;
        }
    }
}
