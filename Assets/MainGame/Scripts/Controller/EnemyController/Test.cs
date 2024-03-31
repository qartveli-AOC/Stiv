using System;
using Commponents;
using UnityEditor.Animations;
using UnityEngine;

namespace Controller
{
    public class Test : MonoBehaviour
    {
        public LayerMask lar;
        private float delay = 5;
        private float timer = 0f;
        public AnimationClip clip;
        public AnimatorState state;
        [field:SerializeField] public AnimatorStateInfo sssa;

        public GameObject[] cubes ;
        private int currrent;

        private void Start()
        {
            state.speed = 1;
        }
    }
}
