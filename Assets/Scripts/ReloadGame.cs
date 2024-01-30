using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadGame : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject hand;

    private void OnTriggerEnter(Collider other)
    {

        StartCoroutine(timer());
        
        
    }
    IEnumerator timer()
    {
        hand.SetActive(false);
        animator.SetBool("bb", true);
        yield return new WaitForSeconds(0.44f);
        animator.SetBool("bb", false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
