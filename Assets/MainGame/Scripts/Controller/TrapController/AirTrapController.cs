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
        playerMotor = FindObjectOfType<PlayerMotor>();
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



    
}