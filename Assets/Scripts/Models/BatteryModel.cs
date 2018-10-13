using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPS
{
    public class BatteryModel : MonoBehaviour
    {
        public float DischargeSpeed = 0.07f;
        public float ChargeSpeed = 0.1f;
        public float RedValue = 0.12f;
        public float YellowValue = 0.3f;
        public Image BatteryFill;

        private float _charge = 1;
        private Image _batteryColor;

        public bool IsOn;

        public float Charge
        {
            get { return _charge; }
            set
            {
                if (value <= 1 && value >= 0)
                    _charge = value;
                else
                {
                    if (value < 0) _charge = 0;
                    else _charge = 1;
                }
            }
        }
        
        private void SetChargeImage()
        {
            BatteryFill.fillAmount = _charge;
            SetBatteryColor();
        }

        private void SetBatteryColor()
        {
            if (Charge <= YellowValue)
            {
                if (Charge <= RedValue)
                {
                    BatteryFill.color = Color.red;
                    _batteryColor.color = Color.red;
                }
                else
                {
                    BatteryFill.color = Color.yellow;
                    _batteryColor.color = Color.yellow;
                }
            } else
            {
                BatteryFill.color = Color.green;
                _batteryColor.color = Color.green;
            }
        }

        public void On()
        {
            IsOn = true;
        }

        public void Off()
        {
            IsOn = false;
        }

        void Awake()
        {
            _batteryColor = GetComponent<Image>();
            SetBatteryColor();
        }

        void Update()
        {
            if (IsOn)
            {
                Charge -= (DischargeSpeed * Time.deltaTime);
                SetChargeImage();
                if (Charge <= 0) Main.Instance.FlashLightControl.Off();
            }
            else
            {
                if (_charge < 1)
                {
                    Charge += ChargeSpeed * Time.deltaTime;
                    SetChargeImage();
                }
            }
        }
    }
}
