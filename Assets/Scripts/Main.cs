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
        public AudioSource PlayerAudioSource;

        private GameObject _hit;
        private bool _drag;
        private LayerMask _movableObjects;

        private void Start()
        {
            InputController = gameObject.AddComponent<InputController>();
            FlashLightControl = gameObject.AddComponent<FlashLightControl>();

            _drag = false;
            _movableObjects = 1 << 9;
        }

        public void TryDrag()
        {
            if (!_drag)
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position,
                    Camera.main.transform.TransformDirection(Vector3.forward), out hit, 3f, _movableObjects))
                {
                    DragController = hit.collider.gameObject.AddComponent<DragController>();
                    _drag = true;
                }
            }
            else
            {
                Destroy(DragController);
                _drag = false;
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
