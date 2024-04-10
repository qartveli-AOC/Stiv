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
    [SerializeField] private float[] values = new float[3];



    void Start()
    {
        thisLevelNum += 1;

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
            ResetPosition();
            SceneManager.LoadScene(thisLevelNum);
        }
    }
    [ContextMenu("ResetLevel")]
    public void ResetLevels()
    {
        PlayerPrefs.SetInt("Level"+thisLevelNum, 0);
    }
    public void ResetPosition()
    {
        values[0] = 1.453161f;
        values[1] = -4.68f;
        values[2] = -26.86665f;
        PlayerPrefs.SetFloat("value" + 0, values[0]);
        PlayerPrefs.SetFloat("value" + 1, values[1]);
        PlayerPrefs.SetFloat("value" + 2, values[2]);
    }
}
