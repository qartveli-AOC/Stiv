using UnityEngine;
using UnityEngine.Events;

namespace Commponents
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int health;
        [Space(25)]
        [SerializeField] private UnityEvent onDamage;
        [Space(25)]
        [SerializeField] private UnityEvent onDie;

        
        public void ModifyHealth(int damage)
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
 