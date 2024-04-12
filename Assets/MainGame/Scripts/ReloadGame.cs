using System;
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
        StartCoroutine(CursorDisableActivator());
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
        Debug.Log("Dieing true");
        animator.SetBool("isDeath", true);
        yield return new WaitForSeconds(0.44f);
        animator.SetBool("isDeath", false);
        Debug.Log("Dieing false");
        DamageHeart();
      
        
       
    }
    public void DamageHeart()
    {
        StaticValue.thisHeart--;
        if (StaticValue.thisHeart <= 0)
            savePoint.Reset2();
        PlayerPrefs.SetInt("thisHeart", StaticValue.thisHeart);
        Debug.Log("Dieing Scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Dieing after Scene");
    }

    private IEnumerator CursorDisableActivator()
    {
        yield return new WaitForSeconds(0.4f);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
  
}
