using System.Collections;
using UnityEngine;

public class TrapTimer : MonoBehaviour
{
    
    [SerializeField] private Animator animator;
    [SerializeField] private float timeMin = 1f;
    [SerializeField] private float timeMax = 2f;

    private void Start()
    {
        StartCoroutine(TimeStop());
    }
   

    private IEnumerator TimeStop()
    {
        
        while (true)
        {
            animator.SetBool("isTrapWork", true);
            Debug.Log("start");
            yield return new WaitForSeconds(2);
            animator.SetBool("isTrapWork", false);
            yield return new WaitForSeconds(2);
            Debug.Log("exiet");
        }
           
        
        
    }


   
}
