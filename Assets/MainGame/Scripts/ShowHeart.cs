using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHeart : MonoBehaviour
{

    [SerializeField] Image[] heartImg;
    public ReloadGame reloadGame;
    void Start()
    {
        reloadGame = FindAnyObjectByType<ReloadGame>();
        ShowHeartUpdate();

    }
    public void ShowHeartUpdate()
    {
        StaticValue.Heart = PlayerPrefs.GetInt("Heart", 2);
        StaticValue.thisHeart = PlayerPrefs.GetInt("thisHeart", StaticValue.Heart);

        if (StaticValue.thisHeart <= 0)
            StaticValue.thisHeart = PlayerPrefs.GetInt("Heart", StaticValue.Heart);
        Debug.Log("this heart: " + StaticValue.thisHeart);


        heartImg = new Image[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            heartImg[i] = transform.GetChild(i).GetComponent<Image>();
        }
        for (int i = 0; i < StaticValue.thisHeart; i++)
        {
            heartImg[i].enabled = true;
        }
    }
    
}