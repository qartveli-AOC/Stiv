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

        if (nowUpdate > 0)
        price = price*(priceUpperX * nowUpdate);
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
    }

    public void Heart()
    {
        if(nowUpdate < maxUpdate && StaticValue.Emerald >= price)
        {
            StaticValue.Heart += 1;
            PlayerPrefs.SetInt("Heart", StaticValue.Heart);
            nowUpdate++;
            PlayerPrefs.SetInt(keyButton,nowUpdate);
            _audioSource.PlayOneShot(buy);
            StaticValue.Emerald -= price;
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
            nowUpdate++;
            PlayerPrefs.SetInt(keyButton, nowUpdate);
            StaticValue.Emerald -= price;
            if (nowUpdate >= maxUpdate)
                imgMax.enabled = true;
        }
        else
            _audioSource.PlayOneShot(cantBuy);

    }

    public void RunSpeed()
    {
        if(nowUpdate < maxUpdate && StaticValue.Emerald >= price)
        {
            StaticValue.RunSpeed += 0.08f;
            PlayerPrefs.SetFloat("RunSpeed", StaticValue.RunSpeed);
            nowUpdate++;
            PlayerPrefs.SetInt(keyButton, nowUpdate);
            StaticValue.Emerald -= price;
            if (nowUpdate >= maxUpdate)
                imgMax.enabled = true;
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
            nowUpdate++;
            PlayerPrefs.SetInt(keyButton, nowUpdate);
            StaticValue.Emerald -= price;
            if (nowUpdate >= maxUpdate)
                imgMax.enabled = true;
        }
        else
            _audioSource.PlayOneShot(cantBuy);
    }
    public void UnStop()
    {
        if (nowUpdate < maxUpdate && StaticValue.Emerald >= price)
        {
            nowUpdate++;
            PlayerPrefs.SetInt(keyButton, nowUpdate);
            StaticValue.Emerald -= price;
            if (nowUpdate >= maxUpdate)
                imgMax.enabled = true;
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
            StaticValue.BaseLevel++;
            PlayerPrefs.SetInt("BaseLevel", StaticValue.BaseLevel);

            nowUpdate++;
            PlayerPrefs.SetInt(keyButton, nowUpdate);
            StaticValue.Emerald -= price;
            if (nowUpdate >= maxUpdate)
                imgMax.enabled = true;
        }
        else
            _audioSource.PlayOneShot(cantBuy);
    }

    public void PickleSpeed()
    {
        if (nowUpdate < maxUpdate && StaticValue.Emerald >= price)
        {
            StaticValue.PicleSpeed += 0.2f;
            PlayerPrefs.SetFloat("PicleSpeed", StaticValue.PicleSpeed);
            nowUpdate++;
            PlayerPrefs.SetInt(keyButton, nowUpdate);
            StaticValue.Emerald -= price;
            if (nowUpdate >= maxUpdate)
                imgMax.enabled = true;
        }
        else
            _audioSource.PlayOneShot(cantBuy);
    }
    public void MoreResurses()
    {
        if (nowUpdate < maxUpdate && StaticValue.Emerald >= price) 
        {
            StaticValue.MoreRes++;
            PlayerPrefs.SetFloat("MoreRes", StaticValue.MoreRes);
            nowUpdate++;
            PlayerPrefs.SetInt(keyButton, nowUpdate);
            StaticValue.Emerald -= price;
            if (nowUpdate >= maxUpdate)
                imgMax.enabled = true;
        }
        else
            _audioSource.PlayOneShot(cantBuy);
    }
}
