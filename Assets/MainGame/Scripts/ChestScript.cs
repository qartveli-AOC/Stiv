using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChestScript : MonoBehaviour
{
    [SerializeField] private Res chestRes;
    public UnityEvent ResTake;
    
    private Animator _animator;
    private AudioSource _audio;
    
    private static readonly int Open = Animator.StringToHash("Open");

    private void Start()
    {
        Initialization();
    }

    private void Initialization()
    {
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        TakeResurses();
        ResTake?.Invoke();
    }


    private void TakeResurses()
    {
      
            switch (chestRes)
            {
                case Res.Bread:
                    if (StaticValue.CHBread> 0)
                    {
                        StaticValue.Bread += StaticValue.CHBread;
                        StaticValue.CHBread = 0;
                        PlayerPrefs.SetInt("CHBread", 0);
                        _animator.SetTrigger(Open);
                        _audio.Play();
                       
                    }
                    break;
                case Res.Coal:
                    if (StaticValue.CHCoal> 0)
                    {
                        StaticValue.Coal += StaticValue.CHCoal;
                        StaticValue.CHCoal = 0;
                        PlayerPrefs.SetInt("CHCoal", 0);
                        _animator.SetTrigger(Open);
                        _audio.Play();
                    }
                   
                    break;
                case Res.RedStone:
                    if (StaticValue.CHRedStone> 0)
                    {
                        StaticValue.RedStone += StaticValue.CHRedStone;
                        StaticValue.CHRedStone = 0;
                        PlayerPrefs.SetInt("CHRedStone", 0);
                        _animator.SetTrigger(Open);
                        _audio.Play();
                    }
                   
                    break;
                case Res.Iron:
                    if (StaticValue.CHIron> 0)
                    {
                        StaticValue.Iron += StaticValue.CHIron;
                        StaticValue.CHIron = 0;
                        PlayerPrefs.SetInt("CHIron", 0);
                        _animator.SetTrigger(Open);
                        _audio.Play();
                    }
                   
                    break;
                case Res.Gold:
                    if (StaticValue.CHGold> 0)
                    {
                        StaticValue.Gold += StaticValue.CHGold;
                        StaticValue.CHGold = 0;
                        PlayerPrefs.SetInt("CHGold", 0);
                        _animator.SetTrigger(Open);
                        _audio.Play();
                    }
                    
                   
                    break;
                case Res.Emerald:
                    if (StaticValue.CHEmerald> 0)
                    {
                        StaticValue.Emerald += StaticValue.CHEmerald;
                        StaticValue.CHEmerald = 0;
                        PlayerPrefs.SetInt("CHEmerald", 0); 
                        _animator.SetTrigger(Open);
                        _audio.Play();
                    }
                   
                    break;
                case Res.Diamond:
                    if (StaticValue.CHDiamond> 0)
                    {
                        StaticValue.Diamond += StaticValue.CHDiamond;
                        StaticValue.CHDiamond = 0;
                        PlayerPrefs.SetInt("CHDiamond", 0);
                        _animator.SetTrigger(Open);
                        _audio.Play();
                    }
                   
                    break;

            }
        }
    

    }





