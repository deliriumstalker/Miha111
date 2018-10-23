using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class FlashLightModel : MonoBehaviour
    {
        public AudioClip FlashlightOn;
        public AudioClip FlashlightOff;

        private Light _light;

        public bool IsOn
        {
            get
            {
                if (!_light) return false;
                return _light.enabled;
            }
        }

        private void Awake()
        {
            _light = GetComponent<Light>();
        }

        public void On()
        {
            _light.enabled = true;
            Main.Instance.PlayerAudioSource.PlayOneShot(FlashlightOn, 0.3f);
        }

        public void Off()
        {
            _light.enabled = false;
            Main.Instance.PlayerAudioSource.PlayOneShot(FlashlightOff, 0.3f);
        }

        public void Switch()
        {
            if (IsOn) Off();
            else On();
        }
    }
}
