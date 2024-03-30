using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCrack : MonoBehaviour
{
   [SerializeField] private float maxDistance = 5f;
   [SerializeField] private LayerMask layerMask;
   [SerializeField] private Animator animator;
    

    // Update is called once per frame
    void Update()
    {
        Vector3 rayOrigin = transform.position;
        Vector3 rayDirection = transform.forward;
       // Debug.DrawRay(rayOrigin, rayDirection,Color.red);
        RaycastHit hit;
        if(Physics.Raycast(rayOrigin, rayDirection,out hit,maxDistance, layerMask))
        {
            if(Input.GetMouseButtonDown(0)) 
            { 
            hit.rigidbody.gameObject.SetActive(false);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
     Gizmos.DrawFrustum(transform.position,60f,5f,3f,33f);
        
        
    }

}
