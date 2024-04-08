using System;
using UnityEngine;

namespace Commponents
{
    public class TeleporterComponent : MonoBehaviour
    { 
        private Transform teleportPosition;


        private void Start()
        {
            teleportPosition = transform.GetChild(0).transform;
        }

        private void OnTriggerEnter(Collider other)
        {
            CharacterController characterController = other.GetComponent<CharacterController>();

            if (characterController != null)
            {
                characterController.enabled = false;
                other.transform.position = teleportPosition.position;
                characterController.enabled = true;
                Debug.Log("Teleport Works");
            }

           
        }
    }
}