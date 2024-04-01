using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChestScript : MonoBehaviour
{
    [SerializeField] private Res chestRes;

    public UnityEvent ResTake;
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
                StaticValue.Bread += StaticValue.CHBread;
                StaticValue.CHBread = 0;
                PlayerPrefs.SetInt("CHBread", 0);
                break;
            case Res.Coal:
                StaticValue.Coal += StaticValue.CHCoal;
                StaticValue.CHCoal = 0;
                PlayerPrefs.SetInt("CHCoal", 0);
                break;
            case Res.RedStone:
                StaticValue.RedStone += StaticValue.CHRedStone;
                StaticValue.CHRedStone = 0;
                PlayerPrefs.SetInt("CHRedStone", 0);
                break;
            case Res.Iron:
                StaticValue.Iron += StaticValue.CHIron;
                StaticValue.CHIron = 0;
                PlayerPrefs.SetInt("CHIron", 0);
                break;
            case Res.Gold:
                StaticValue.Gold += StaticValue.CHGold;
                StaticValue.CHGold = 0;
                PlayerPrefs.SetInt("CHGold", 0);
                break;
            case Res.Emerald:
                StaticValue.Emerald += StaticValue.CHEmerald;
                StaticValue.CHEmerald = 0;
                PlayerPrefs.SetInt("CHEmerald", 0);
                break;
            case Res.Diamond:
                StaticValue.Diamond += StaticValue.CHDiamond;
                StaticValue.CHDiamond = 0;
                PlayerPrefs.SetInt("CHDiamond", 0);
                break;

        }

    }

}



