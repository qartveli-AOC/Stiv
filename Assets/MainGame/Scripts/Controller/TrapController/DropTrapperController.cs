using System;
using UnityEngine;

namespace Controller
{
    public class DropTrapperController : MonoBehaviour
    {
        [SerializeField] private Transform spawnPos;
        [SerializeField] private float spawnDelay = 1;
        private GameObject _spawnObject;
        private AudioSource _audio;


        private void Awake()
        {
            _spawnObject = Resources.Load<GameObject>("Arrow");
        }

        private void Start()
        {
            _audio = GetComponent<AudioSource>();
            InvokeRepeating(nameof(Spawn),1,spawnDelay);
        }

        private void Spawn()
        {
            GameObject arrow = Instantiate(_spawnObject, spawnPos.position, Quaternion.identity);
            _audio.Play();
            Destroy(arrow,10);
        }
    }
}
