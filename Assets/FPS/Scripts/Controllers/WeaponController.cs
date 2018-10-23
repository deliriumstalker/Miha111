using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class WeaponController : BaseController
    {
        private BaseWeapon[] _weapons;
        private int _currentWeapon = 0;

        private void Awake()
        {
            _weapons = PlayerModel.LocalPlayer.Weapons;
            for (int i = 0; i < _weapons.Length; i++)
            {
                _weapons[i].IsVisible = i == 0;
            }
            Debug.Log(_weapons.Length.ToString());
        }

        public void ChangeWeapon()
        {
            _weapons[_currentWeapon].IsVisible = false;
            _currentWeapon++;
            if (_currentWeapon >= _weapons.Length) _currentWeapon = 0;
            _weapons[_currentWeapon].IsVisible = true;
        }

        public void Fire()
        {
            if (_weapons.Length > _currentWeapon && _weapons[_currentWeapon])
                _weapons[_currentWeapon].Fire();
        }

        public void UnFire()
        {
            if (_weapons[_currentWeapon].IsFiring)
                _weapons[_currentWeapon].UnFire();
        }
    }
}
