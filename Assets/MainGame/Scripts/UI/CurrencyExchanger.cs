using System;
using TMPro;
using UnityEngine;

namespace MainGame.Scripts.UI
{
    public class CurrencyExchanger : MonoBehaviour
    {
        [SerializeField] private int priceBuy;
        [SerializeField] private int takeEmerald;
        [SerializeField] private Res res;

        private TextMeshProUGUI _priceBuyText;
        private TextMeshProUGUI _takeEmeraldText;

        private AudioSource _audioSource;
        [SerializeField] private AudioClip buy;
        [SerializeField] private AudioClip cantBuy;

        private void Start()
        {
            Initialization();
            ShowText();
        }

        private void Initialization()
        {
            _priceBuyText = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
            _takeEmeraldText = transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void ShowText()
        {
            _priceBuyText.text = priceBuy.ToString();
            _takeEmeraldText.text = takeEmerald.ToString();
        }

        public void ChangeResource()
        {
            Changer(res);
        }
        
        
        private void Changer(Res resourceType)
        {
            switch(resourceType)
            {
                case Res.Coal:
                    if (StaticValue.Coal >= priceBuy)
                    {
                        StaticValue.Coal -= priceBuy;
                        StaticValue.Emerald += takeEmerald;
                        Debug.Log("TAKE" + takeEmerald + "  /Coal");
                        _audioSource.PlayOneShot(buy);
                    }
                    else
                    {
                        Debug.Log("Not enough Coal to exchange.");
                        _audioSource.PlayOneShot(cantBuy);
                    }
                    break;
                case Res.Diamond:
                    if (StaticValue.Diamond >= priceBuy)
                    {
                        StaticValue.Diamond -= priceBuy;
                        StaticValue.Emerald += takeEmerald;
                        _audioSource.PlayOneShot(buy);
                    }
                    else
                    {
                        Debug.Log("Not enough Diamond to exchange.");
                        _audioSource.PlayOneShot(cantBuy);
                    }
                    break;
                
                
                case Res.Bread:
                    if (StaticValue.Bread >= priceBuy)
                    {
                        StaticValue.Bread -= priceBuy;
                        StaticValue.Emerald += takeEmerald;
                        Debug.Log("TAKE" + takeEmerald + "  /Bread");
                        _audioSource.PlayOneShot(buy);
                    }
                    else
                    {
                        Debug.Log("Not enough Bread to exchange.");
                        _audioSource.PlayOneShot(cantBuy);
                    }
                    break;
                case Res.Gold:
                    if (StaticValue.Gold >= priceBuy)
                    {
                        StaticValue.Gold -= priceBuy;
                        StaticValue.Emerald += takeEmerald;
                        Debug.Log("TAKE" + takeEmerald + "  /Gold");
                        _audioSource.PlayOneShot(buy);
                        
                    }
                    else
                    {
                        Debug.Log("Not enough Gold to exchange.");
                        _audioSource.PlayOneShot(cantBuy);
                    }
                    break;
                
                case Res.Iron:
                    if (StaticValue.Iron >= priceBuy)
                    {
                        StaticValue.Iron -= priceBuy;
                        StaticValue.Emerald += takeEmerald;
                        Debug.Log("TAKE" + takeEmerald + "  /Iron");
                        _audioSource.PlayOneShot(buy);
                    }
                    else
                    {
                        Debug.Log("Not enough Iron to exchange.");
                        _audioSource.PlayOneShot(cantBuy);
                    }
                    break;
                case Res.RedStone:
                    if (StaticValue.RedStone >= priceBuy)
                    {
                        StaticValue.RedStone -= priceBuy;
                        StaticValue.Emerald += takeEmerald;
                        Debug.Log("TAKE" + takeEmerald + "  /RedStone");
                        _audioSource.PlayOneShot(buy);
                    }
                    else
                    {
                        Debug.Log("Not enough RedStone to exchange.");
                        _audioSource.PlayOneShot(cantBuy);
                    }
                    break;
               
            }
        }
    }
    }

