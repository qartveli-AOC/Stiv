using System;
using UnityEngine;

namespace Controller
{
    public class Test : MonoBehaviour
    {

        private float num1 = 1;
        public float num2;
       

      

        private void Start()
        {
            
            num1 *= num2 + 3;
            Debug.Log(num1 + ";;;;1 ");
            num1 = 1 * num2 + 3;
            Debug.Log(num1 + " ;;;2222232");
            num1 = (1 * num2) + 3;
            Debug.Log(num1 + " ;;;;;");
            
        }
    }
}
