using System;
using Commponents;
using UnityEngine;

namespace Controller
{
    public class Test : MonoBehaviour
    {
        public HealthComponent enemy;


        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                enemy.ModifyHealth(1);
            }
        }
    }
}
