using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHeart : MonoBehaviour
{
    [SerializeField] Image[] heartImg;
    void Start()
    {
        StaticValue.Heart = PlayerPrefs.GetInt("Heart", 2);
        Debug.Log(StaticValue.Heart + " heart");
        heartImg = new Image[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            heartImg[i] = transform.GetChild(i).GetComponent<Image>();
        }
        for (int i = 0; i < StaticValue.Heart; i++)
        {
            heartImg[i].enabled = true;
        }
    }
}