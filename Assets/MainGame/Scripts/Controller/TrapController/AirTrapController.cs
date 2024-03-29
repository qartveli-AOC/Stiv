using System;
using System.Collections;
using UnityEngine;

public class AirTrapController : MonoBehaviour
{
    [SerializeField] private float airFlowSpeed = 5f;

    public PlayerMotor playerMotor;
    private Animator _animator;
    private static readonly int JumpTrap = Animator.StringToHash("JumpTrap");


    private void Start()
    {
        _animator = gameObject.GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(WaitJump());
        }
    }
    
    private void TryJump()
    {
        playerMotor.Jump(airFlowSpeed);
        _animator.SetTrigger(JumpTrap);
    }

    private IEnumerator WaitJump()
    {
        TryJump();
        gameObject.GetComponent<BoxCollider>().enabled  = false;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<BoxCollider>().enabled  = true;
    }

    private void OnDrawGizmos()
    {
        Vector3 pos = transform.TransformDirection(Vector3.forward) * 5;
        Vector3 endPosition = Vector3.MoveTowards(transform.position, transform.position + transform.forward, 1f);
    
       
        Gizmos.DrawRay(transform.position, transform.forward * 2);
    }

    
}