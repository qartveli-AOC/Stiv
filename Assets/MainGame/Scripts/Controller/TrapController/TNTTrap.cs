using System;
using System.Collections;
using UnityEngine;

namespace Controller
{
    public class TNTTrap : MonoBehaviour
    {
        [SerializeField] private Sprite red;
        [SerializeField] private Sprite white;

        public SpriteRenderer[] blockTNT = new SpriteRenderer[6];
        private AudioSource _source;

        [SerializeField] private float explosionForce = 100000f;
        [SerializeField] private float explosionRadius = 50f;


        private void Start()
        {
            _source = GetComponent<AudioSource>();
        }

        [ContextMenu("ActivateBomb")]
        public void ActivateBomb()
        {
            StartCoroutine(TNTActivator());
        }


        private void OnTriggerEnter(Collider other)
        {
            ActivateBomb();
            Debug.Log("Active");
        }

        private IEnumerator TNTActivator()
        {
            _source.Play();
            yield return new WaitForSeconds(0.5f);
            int repeat = 4;

            for (int i = 0; i < repeat; i++)
            {
                foreach (var block in blockTNT)
                {
                    block.sprite = white;
                }

                yield return new WaitForSeconds(0.3f);

                foreach (var block in blockTNT)
                {
                    block.sprite = red;
                }

                yield return new WaitForSeconds(0.3f);
            }

           
            gameObject.SetActive(false);





        }


        
    }
}
