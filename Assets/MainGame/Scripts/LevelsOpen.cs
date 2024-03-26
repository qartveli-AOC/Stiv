using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsOpen : MonoBehaviour
{
    [SerializeField] private int levelActive;
    [SerializeField] private Image lockImg;
    [SerializeField] private int thisLevelNum;
    
    
    
    void Start()
    {
        

        lockImg = transform.GetChild(1).GetComponent<Image>();
        levelActive = PlayerPrefs.GetInt("Level"+thisLevelNum, 0);
        if (levelActive == 1 || thisLevelNum == 1)
        {
            lockImg.gameObject.SetActive(false);
        }
            
    }
    public void OpenLevel()
    {
        if (levelActive == 1 || thisLevelNum == 1)
        {
            SceneManager.LoadScene(thisLevelNum);
        }
    }
}