using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using UnityEngine;
using UnityEngine.AI;

public class DestroySlime : MonoBehaviour
{
    [SerializeField] private BoxCollider[] collider;
    
     private NavMeshAgent agent;
     private SkilletController controller;
     private GameObject MeshObject;


     private void Start()
     {
         agent = GetComponent<NavMeshAgent>();
         controller = GetComponent<SkilletController>();
         MeshObject = transform.GetChild(0).gameObject;
     }


     public void DestroySlimeStart()
    {
        agent.enabled = false;
        collider[0].enabled = false;
        collider[1].enabled = false;
        controller.enabled = false;
        MeshObject.SetActive(false);
        Destroy(gameObject,0.5f);
    }
}
