using System.Collections;
using System.Collections.Generic;
using FPS;
using UnityEngine;

namespace FPS
{
    public class DragController : BaseSceneObject
    {
        public float velo = 3f;
        private Vector3 vect;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //vect = Camera.main.transform.forward * velo;
            vect = Camera.main.transform.position + (Camera.main.transform.forward * velo);
            //Debug.Log(vect.ToString());
            transform.position = vect;
        }
    }
}
