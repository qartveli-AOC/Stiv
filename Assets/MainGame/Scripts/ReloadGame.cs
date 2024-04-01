using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadGame : MonoBehaviour
{
    private Transform cameraMain;
    private Transform handPosition;
    private Animator animator;
    private Transform player;
    [SerializeField] SavePoint savePoint;
    
    private void Start()
    {
        savePoint = FindAnyObjectByType<SavePoint>();
        

        if (StaticValue.Heart <= 0)
            StaticValue.Heart = 3;
    }
    void OnTriggerEnter(Collider other)
    {
        
        cameraMain = other.transform.Find("CameraMain");
        handPosition = other.transform.Find("hand");
        player = other.transform.Find("Player 1 Variant");
        animator = cameraMain.GetComponent<Animator>();
        


        StartCoroutine(timer());
    }
    IEnumerator timer()
    {
        handPosition.gameObject.SetActive(false);
        animator.SetBool("isDeath", true);
        yield return new WaitForSeconds(0.44f);
        animator.SetBool("isDeath", false);
        StaticValue.Heart--;        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
    }
  
}
