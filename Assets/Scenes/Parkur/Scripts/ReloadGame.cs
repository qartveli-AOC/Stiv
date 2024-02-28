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
    [HideInInspector] public static int heart=2;

    private void Start()
    {
        savePoint = FindAnyObjectByType<SavePoint>();


        if (heart < 0)
            heart = 2;
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
        animator.SetBool("bb", true);
        yield return new WaitForSeconds(0.44f);
        animator.SetBool("bb", false);
        heart--;        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
    }
  
}
