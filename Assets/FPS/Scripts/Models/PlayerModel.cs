using System.Collections;
using System.Collections.Generic;
using FPS;
using UnityEngine;

namespace FPS
{
    public class PlayerModel : BaseSceneObject
    {
        public static PlayerModel LocalPlayer { get; private set; }

        public BaseWeapon[] Weapons;

        //состояние. перетаскивает ли какой-либо объект в данный момент
        private bool _isDragging = false;
        public bool IsDragging
        {
            get { return _isDragging; }
            set { _isDragging = value; }
        }

        protected override void Awake()
        {
            if (LocalPlayer) DestroyImmediate(gameObject);
            else LocalPlayer = this;

            base.Awake();

            Weapons = GetComponentsInChildren<BaseWeapon>(true);
        }
    }
}
