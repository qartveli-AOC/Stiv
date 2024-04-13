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

    private AudioSource _audioSource;
    [SerializeField] private AudioClip buy;
    [SerializeField] private AudioClip cantBuy;
    [SerializeField] private AudioClip dog;

    private TextMeshProUGUI priceTxt;
    private string keyButton;
    private int nowUpdate;

    private void Start()
    {      
        keyButton = gameObject.name;
        nowUpdate = PlayerPrefs.GetInt(keyButton,0);

        price = PlayerPrefs.GetInt("price" + keyButton, price);
        imgMax = transform.GetChild(1).GetComponent<Image>();

        if (nowUpdate >= maxUpdate)
            imgMax.enabled = true;

        priceTxt = transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();

        priceTxt.text = price.ToString();
        _audioSource = GetComponent<AudioSource>();
    }
    [ContextMenu("ResetInfo")]
    public void ResetInfo()
    {
        nowUpdate = 0;
        PlayerPrefs.SetInt(keyButton, nowUpdate);
        PlayerPrefs.SetInt("Heart", 2);
        PlayerPrefs.SetInt("EarnPower", 0);
        PlayerPrefs.SetFloat("RunSpeed", 0);
        PlayerPrefs.SetInt("Attack", 0);
        PlayerPrefs.SetInt("BaseLevel", 1);
        PlayerPrefs.SetFloat("PicleSpeed", 0);
        PlayerPrefs.SetFloat("MoreRes", 0);
        PlayerPrefs.SetInt("thisHeart", 2);
    }

    public void Heart()
    {
        if(nowUpdate < maxUpdate && StaticValue.Emerald >= price)
        {
            StaticValue.Heart += 1;
            PlayerPrefs.SetInt("Heart", StaticValue.Heart);
            PlayerPrefs.SetInt("thisHeart",StaticValue.Heart);
            ShowInfo();
        }
        else
            _audioSource.PlayOneShot(cantBuy);
    }

    public void Earn()
    {
        if(StaticValue.Emerald >= price)
        {
            StaticValue.EarnPower = (nowUpdate * StaticValue.EarnPower) + 1;
            PlayerPrefs.SetInt("EarnPower", StaticValue.EarnPower);
            ShowInfo();

        }
        else
            _audioSource.PlayOneShot(cantBuy);

    }

    public void RunSpeed()
    {
        if(nowUpdate < maxUpdate && StaticValue.Emerald >= price)
        {
            StaticValue.RunSpeed += 0.15f;
            PlayerPrefs.SetFloat("RunSpeed", StaticValue.RunSpeed);
            nowUpdate++;
            ShowInfo();

        }
        else
            _audioSource.PlayOneShot(cantBuy);

    }
    public void AtackPower()
    {
        if(nowUpdate < maxUpdate && StaticValue.Emerald >= price)
        {
            StaticValue.Attack += 1;
            PlayerPrefs.SetInt("Attack", StaticValue.Attack);           
            ShowInfo();
        }
        else
            _audioSource.PlayOneShot(cantBuy);
    }
    public void UnStop()
    {
        if (nowUpdate < maxUpdate && StaticValue.Emerald >= price)
        {          
            ShowInfo();
        }
        else
            _audioSource.PlayOneShot(cantBuy);
    }
    public void Dog()
    {
        if (nowUpdate < maxUpdate && StaticValue.Emerald >= price)
        {
            nowUpdate++;
            PlayerPrefs.SetInt(keyButton, nowUpdate);
            _audioSource.PlayOneShot(buy);
            StaticValue.Emerald -= price;
            if (nowUpdate >= maxUpdate)
                imgMax.enabled = true;
        }
        else
            _audioSource.PlayOneShot(dog);
    }
    public void BaseLevelUp()
    {
        if(nowUpdate < maxUpdate && StaticValue.Emerald >= price)
        {
            ShowInfo();
            StaticValue.BaseLevel++;
            PlayerPrefs.SetInt("BaseLevel", StaticValue.BaseLevel);                          
        }
        else
            _audioSource.PlayOneShot(cantBuy);
    }

    public void PickleSpeed()
    {
        if (nowUpdate < maxUpdate && StaticValue.Emerald >= price)
        {
            ShowInfo();
            StaticValue.PicleSpeed += 0.2f;
            PlayerPrefs.SetFloat("PicleSpeed", StaticValue.PicleSpeed);                        
        }
        else
            _audioSource.PlayOneShot(cantBuy);
    }
    public void MoreResurses()
    {
        if (nowUpdate < maxUpdate && StaticValue.Emerald >= price) 
        {
             ShowInfo();   
            StaticValue.MoreRes++;
            PlayerPrefs.SetFloat("MoreRes", StaticValue.MoreRes);                
        }
        else
            _audioSource.PlayOneShot(cantBuy);
    }
    public void ShowInfo()
    {
        _audioSource.PlayOneShot(buy);
        nowUpdate++;            
        PlayerPrefs.SetInt(keyButton, nowUpdate);
        StaticValue.Emerald -= price;
        if (nowUpdate >= maxUpdate)
            imgMax.enabled = true;       
            price = price + (nowUpdate*nowUpdate * 4);
        PlayerPrefs.SetInt("price" + keyButton, price);
        priceTxt.text = price.ToString();
    }
}
