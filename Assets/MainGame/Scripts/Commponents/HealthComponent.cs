using Controller;
using UnityEngine;
using UnityEngine.AI;
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
                GetComponent<MobController>()._agent.SetDestination(Vector3.zero);
                onDie?.Invoke();
               
                return;
            }
           
        }
    }
}
   