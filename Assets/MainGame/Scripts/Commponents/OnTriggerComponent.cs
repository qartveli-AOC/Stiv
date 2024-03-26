using UnityEngine;
using UnityEngine.Events;

namespace Commponents
{
    public class OnTriggerComponent : MonoBehaviour
    {
        [SerializeField] private UnityEvent onEnter;
        [SerializeField] private UnityEvent onExit;
        [SerializeField] private string target;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(target))
            {
                onEnter?.Invoke();
            }
           
        }
        
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(target))
            {
                onEnter?.Invoke();
            }
           
        }
    }
    
    
}
