using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class WeaponController : BaseController
    {
        private BaseWeapon[] _weapons;
        private int _currentWeapon = 0;
        public bool IsFiring { get; set; }

        private void Awake()
        {
            _weapons = PlayerModel.LocalPlayer.Weapons;
            for (int i = 0; i < _weapons.Length; i++)
            {
                _weapons[i].IsVisible = i == 0;
            }
            _weapons[0].RefreshHUD();
        }

        public void ChangeWeapon(bool up)
        {
            _weapons[_currentWeapon].IsVisible = false;
            if (up) _currentWeapon++;
            else _currentWeapon--;
            if (_currentWeapon >= _weapons.Length) _currentWeapon = 0;
            if (_currentWeapon < 0) _currentWeapon = _weapons.Length - 1;
            _weapons[_currentWeapon].IsVisible = true;
            _weapons[_currentWeapon].RefreshHUD();
        }

        public void Fire()
        {
            if (_weapons.Length > _currentWeapon && _weapons[_currentWeapon])
            {
                if (!_weapons[_currentWeapon].IsAuto) _weapons[_currentWeapon].Fire();
                if (_weapons[_currentWeapon].IsAuto) _weapons[_currentWeapon].StartCoroutine("RapidFire");
            }
        }

        public void Reload()
        {
            _weapons[_currentWeapon].Reload();
        }
    }
}
