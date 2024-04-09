using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoHome : MonoBehaviour
{
    [SerializeField] private int home = 0;
    [SerializeField] private int nextLevelNum;
    [SerializeField] private UnityEvent levelFinish;
    private Image[] image;

    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("Level" + nextLevelNum, 1);
        levelFinish?.Invoke();
        
    }
    public void NextLevel()
    {
        ResetHeart();
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(++currentScene);
    }
    public void GoBase()
    {
        ResetHeart();
        SceneManager.LoadScene(home);       
    }

    public void ResetHeart()
    {
        PlayerPrefs.SetInt("thisHeart", StaticValue.Heart);       
    }

}


