using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class FlashLightControl : BaseController
    {
        private FlashLightModel _model;
        private BatteryModel _battery;

        private void Awake()
        {
            _model = FindObjectOfType<FlashLightModel>();
            _battery = FindObjectOfType<BatteryModel>();
            Off();
        }

        public override void Off()
        {
            base.Off();
            _model.Off();
            _battery.Off();
        }
        public override void On()
        {
            if (_battery.Charge >= 0.1f)
            {
                base.On();
                _model.On();
                _battery.On();
            }
        }

        public void Switch()
        {
            if (IsEnabled)
            {
                Off();
            }
            else
            {
                On();
            }
        }
    }
}
