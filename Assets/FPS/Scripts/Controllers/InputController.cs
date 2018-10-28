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

            if (Input.GetButtonDown("Reload"))
                Main.Instance.WeaponController.Reload();

            if (Input.GetButtonDown("ChangeWeaponUp") || Input.GetAxis("Mouse ScrollWheel") > 0)
                Main.Instance.WeaponController.ChangeWeapon(true);

            if (Input.GetAxis("Mouse ScrollWheel") < 0)
                Main.Instance.WeaponController.ChangeWeapon(false);

            if (Input.GetButtonDown("Fire1"))
            {
                Main.Instance.WeaponController.IsFiring = true;
                Main.Instance.WeaponController.Fire();
            }

            if (!Input.GetButton("Fire1") && Main.Instance.WeaponController.IsFiring)
                Main.Instance.WeaponController.IsFiring = false;

            if (Input.GetButtonDown("Use"))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position,
                    Camera.main.transform.TransformDirection(Vector3.forward), out hit, 3f, LayerMask.NameToLayer("MovableObjects")))
                {
                    //DragController DragController = hit.collider.gameObject.AddComponent<DragController>();
                    BaseInteractableObjectModel obj = hit.collider.gameObject.GetComponent<BaseInteractableObjectModel>();
                    //MovableObjectModel obj = hit.collider.gameObject.GetComponent<MovableObjectModel>();
                    if (obj) obj.Interact(PlayerModel.LocalPlayer);
                    //PlayerModel.LocalPlayer.IsDragging = true;
                }
            }
        }
    }
}
