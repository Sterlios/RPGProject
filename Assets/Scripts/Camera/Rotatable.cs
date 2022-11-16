using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraSpace
{
    [RequireComponent(typeof(Camera))]
    public class Rotatable : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        [SerializeField] private Transform _followTarget;

        private void Awake()
        {

        }
    }
}
