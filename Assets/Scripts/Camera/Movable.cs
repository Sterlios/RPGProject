using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CameraSpace
{
    [RequireComponent(typeof(Camera))]
    public class Movable : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        [SerializeField] private Transform _followTarget;

        private Camera _camera;

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
                Debug.Log("Pressed right click.");
        }


    }
}