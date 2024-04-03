using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeInShop : MonoBehaviour
{
    [SerializeField] int price;
    [SerializeField] int maxUpdate;
    [SerializeField] Image imgMax;
    private string keyButton;
    private int nowUpdate;

    private void Start()
    {
        keyButton = gameObject.name;
        nowUpdate = PlayerPrefs.GetInt(keyButton,0);
        if (nowUpdate >= maxUpdate)
            imgMax.enabled = true;
    }
    public void ClickHeart()
    {
        if(nowUpdate >= maxUpdate)
        {
            StaticValue.Heart += 1;
            PlayerPrefs.SetInt("Heart", StaticValue.Heart);
        }
    }
}
