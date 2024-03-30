using System;
using UnityEngine;

namespace Controller
{
    public class ArrowController : MonoBehaviour
    {
        [SerializeField] private Vector3 position;

        private void FixedUpdate()
        {
            transform.position += position;
        }
    }
}
