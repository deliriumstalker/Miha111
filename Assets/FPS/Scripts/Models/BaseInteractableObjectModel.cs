using System.Collections;
using System.Collections.Generic;
using FPS;
using UnityEngine;

namespace FPS
{
    public abstract class BaseInteractableObjectModel : BaseSceneObject
    {
        public abstract void Interact(PlayerModel player);
    }
}
