using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class Main : MonoBehaviour
    {
        public static Main Instance { get; private set; }

        public InputController InputController { get; private set; }
        public FlashLightControl FlashLightControl { get; private set; }
        public DragController DragController { get; private set; }
        public WeaponController WeaponController { get; private set; }
        public AudioSource PlayerAudioSource;
        public GameObject Canvas;

        private GameObject _hit;
        private LayerMask _movableObjectLayer;
        //private GameObject[] _movableObjectsParent;

        private void Start()
        {
            InputController = gameObject.AddComponent<InputController>();
            FlashLightControl = gameObject.AddComponent<FlashLightControl>();
            WeaponController = gameObject.AddComponent<WeaponController>();

            
            _movableObjectLayer = LayerMask.NameToLayer("MovableObjects");
            var movableObjectsArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
            foreach (var a in movableObjectsArray)
            {
                if (a.layer == _movableObjectLayer)
                {
                    a.AddComponent<MovableObjectModel>();
                }
            }
        }
        
        private void Awake()
        {
            if (Instance)
                DestroyImmediate(this);
            else Instance = this;
        }
    }
}
