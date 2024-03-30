using System;
using UnityEngine;
using UnityEngine.Events;

namespace Commponents
{
    public class OnCollisionComponent : MonoBehaviour
    {
        [SerializeField] private UnityEvent onEnter;
        [SerializeField] private UnityEvent onExit;
        [SerializeField] private string target;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(target))
            {
                onEnter?.Invoke();
            }
           
        }


        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag(target))
            {
                onExit?.Invoke();
            }
        }
    }
}
