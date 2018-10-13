using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class InputController : BaseController
    {
        void Update()
        {
            if (Input.GetButtonDown("SwitchFlashLight"))
                Main.Instance.FlashLightControl.Switch();

            if (Input.GetButtonDown("Use"))
                Main.Instance.TryDrag();
        }
    }
}
