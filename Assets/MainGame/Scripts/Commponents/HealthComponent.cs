using UnityEngine;
using UnityEngine.Events;

namespace Commponents
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private float health;
        [Space(25)]
        [SerializeField] private UnityEvent onDamage;
        [Space(25)]
        [SerializeField] private UnityEvent onDie;

        
        public void ModifyHealth(float damage)
        {
            health -= damage;
            onDamage?.Invoke();
            if (health <= 0)
            {
                onDie?.Invoke();
                return;
            }
           
        }
    }
}
