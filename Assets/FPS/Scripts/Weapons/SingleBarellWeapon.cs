using System.Collections;
using System.Collections.Generic;
using FPS;
using UnityEngine;

namespace FPS
{
    public class SingleBarellWeapon : BaseWeapon
    {
        [SerializeField] private Transform _firePoint;

        public override void Fire()
        {
            if (TryShoot())
            {
                CreateBullet();
                AmmoInMag--;
                RefreshHUD();
            }
        }

        protected override void CreateBullet()
        {
            BaseAmmo bullet = Instantiate(_ammoPrefab, _firePoint.position, _firePoint.rotation);
            bullet.Initialize(_force);
        }
    }
}
