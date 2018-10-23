using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class MovableObjectModel : BaseInteractableObjectModel
    {
        public override void Interact(PlayerModel player)
        {
            if (!PlayerModel.LocalPlayer.IsDragging)
            {
                DragController dragController = this.GameObject.AddComponent<DragController>();
            }
        }
    }
}
