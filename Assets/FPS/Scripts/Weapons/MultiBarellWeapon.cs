using System.Collections;
using System.Collections.Generic;
using FPS;
using UnityEngine;

namespace FPS
{
    public class MultiBarellWeapon : BaseWeapon
    {
        [SerializeField] private Transform[] _firePoints;
        private int _currentFirePoint;

        public override void Fire()
        {
            if (!TryShoot()) return;

            BaseAmmo bullet = Instantiate(_ammoPrefab, _firePoints[_currentFirePoint].position, _firePoints[_currentFirePoint].rotation);
            bullet.Initialize(_force);

            _currentFirePoint++;
            if (_currentFirePoint >= _firePoints.Length) _currentFirePoint = 0;
        }

        public override void Reload()
        {
            //потом
        }
    }
}
