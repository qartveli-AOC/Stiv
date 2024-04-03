using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeInShop : MonoBehaviour
{
    [SerializeField] int price;
    [SerializeField] int priceUpperX;
    [SerializeField] int maxUpdate;
    [SerializeField] Image imgMax;
    private TextMeshProUGUI priceTxt;
    private string keyButton;
    private int nowUpdate;

    private void Start()
    {      
        keyButton = gameObject.name;
        nowUpdate = PlayerPrefs.GetInt(keyButton,0);
        if (nowUpdate > 0)
        price = price*(priceUpperX * nowUpdate);
        Debug.Log(keyButton+" now "+ nowUpdate);

        //if (nowUpdate >= maxUpdate)
           // imgMax.enabled = true;
        priceTxt = transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        priceTxt.text = price.ToString(); 
    }
    public void Heart()
    {
        if(nowUpdate < maxUpdate)
        {
            StaticValue.Heart += 1;
            PlayerPrefs.SetInt("Heart", StaticValue.Heart);
            nowUpdate++;
            PlayerPrefs.SetInt(keyButton,nowUpdate);
        }
        
    }

    public void Earn()
    {
        StaticValue.EarnPower = (nowUpdate * StaticValue.EarnPower)+1;   
        PlayerPrefs.SetInt("EarnPower", StaticValue.EarnPower);
        nowUpdate++;
        PlayerPrefs.SetInt(keyButton, nowUpdate);      
    }

    public void RunSpeed()
    {
        if(nowUpdate < maxUpdate)
        {
            StaticValue.RunSpeed += 0.05f;
            PlayerPrefs.SetFloat("RunSpeed", StaticValue.RunSpeed);
            nowUpdate++;
            PlayerPrefs.SetInt(keyButton, nowUpdate);
        }
        
    }
    public void AtackPower()
    {
        if(nowUpdate < maxUpdate)
        {
            StaticValue.Attack += 0.5f;
            PlayerPrefs.SetFloat("Attack", StaticValue.Attack);
            nowUpdate++;
            PlayerPrefs.SetInt(keyButton, nowUpdate);
        }
    }
    public void UnStop()
    {
        if (nowUpdate < maxUpdate)
        {
            nowUpdate++;
            PlayerPrefs.SetInt(keyButton, nowUpdate);
        }
    }
    public void BaseLevelUp()
    {
        if(nowUpdate<maxUpdate)
        {
            StaticValue.BaseLevel++;
            PlayerPrefs.SetInt("BaseLevel", StaticValue.BaseLevel);

            nowUpdate++;
            PlayerPrefs.SetInt(keyButton, nowUpdate);
        }
    }
}
