using System;
using UnityEngine;

namespace Controller
{
    public class DropTrapperController : MonoBehaviour
    {
        [SerializeField] private Transform spawnPos;
        [SerializeField] private float spawnDelay = 1;
        private GameObject _spawnObject;


        private void Awake()
        {
            _spawnObject = Resources.Load<GameObject>("Arrow");
        }

        private void Start()
        {
           
            InvokeRepeating(nameof(Spawn),1,spawnDelay);
        }

        private void Spawn()
        {
            GameObject arrow = Instantiate(_spawnObject, spawnPos.position, Quaternion.identity);
            Destroy(arrow,10);
        }
    }
}
