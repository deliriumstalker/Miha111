using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        [SerializeField] protected Animator _animator;
        [SerializeField] protected int MagCapacity;
        [SerializeField] protected int AmmoInMag;
        [SerializeField] protected int AmmoInInventory;
        [SerializeField] protected bool _isFiring = false;
        public bool IsFiring
        {
            get { return _isFiring; }
        }

        public bool IsAuto = false;

        private float _reloadTimer;
        private Text _ammoInMag;
        private Text _ammoInInventory;
        private GameObject _ammoInfo;
        protected float _lastShotTime;
        public AudioClip ShotClip;
        public AudioClip ClickClip;

        public abstract void Fire();
        protected abstract void CreateBullet();

        public virtual void Reload()
        {
            if (AmmoInMag < MagCapacity && AmmoInInventory > 0)
                StartCoroutine("ReloadEnumerator");
        }

        protected bool TryShoot()
        {
            if (!IsAuto && Time.time - _lastShotTime < _timeout) return false;
            if (AmmoInMag <= 0)
            {
                audioSource.PlayOneShot(ClickClip, 0.3f);
                return false;
            }
            _lastShotTime = Time.time;
            audioSource.PlayOneShot(ShotClip, 0.5f);
            if (AmmoInMag <= 1) _animator.SetBool("IsEmpty", true);
            _animator.SetTrigger("Fire");
            return true;
        }

        protected override void Awake()
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            _ammoInfo = GameObject.Find("/Canvas/AmmoInfo");
            _ammoInMag = GameObject.Find("/Canvas/AmmoInfo/AmmoMagazineText").GetComponent<Text>();
            _ammoInInventory = GameObject.Find("/Canvas/AmmoInfo/AmmoInventoryText").GetComponent<Text>();
            _animator = GetComponent<Animator>();
            base.Awake();
        }

        IEnumerator RapidFire()
        {
            while (Main.Instance.WeaponController.IsFiring && AmmoInMag > 0)
            {
                Fire();
                yield return new WaitForSeconds(_timeout);
            }
            if (AmmoInMag <= 0) audioSource.PlayOneShot(ClickClip, 0.3f);
            StopCoroutine("RapidFire");
            _isFiring = false;
        }

        IEnumerator ReloadEnumerator()
        {
            _isFiring = false;
            _animator.SetTrigger("Reload");
            yield return new WaitForSeconds(_reloadTime);
            if (AmmoInInventory + AmmoInMag >= MagCapacity)
            {
                AmmoInInventory -= MagCapacity - AmmoInMag;
                AmmoInMag = MagCapacity;
            }
            else
            {
                AmmoInMag = AmmoInMag + AmmoInInventory;
                AmmoInInventory = 0;
            }
            RefreshHUD();
            StopCoroutine("ReloadEnumerator");
        }

        public void RefreshHUD()
        {
            _ammoInMag.text = AmmoInMag.ToString();
            _ammoInInventory.text = AmmoInInventory.ToString();
        }
    }
}
