using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GoHome : MonoBehaviour
{
    [SerializeField] private int home = 0;
    [SerializeField] private int nextLevelNum;
    [SerializeField] private UnityEvent levelFinish; 
    

    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("Level" + nextLevelNum, 1);
        levelFinish?.Invoke();
        
    }
    public void NextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene++);
    }
    public void GoBase()
    {
        SceneManager.LoadScene(home);
        Debug.Log("reload");
    }

}


