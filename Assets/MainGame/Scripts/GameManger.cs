using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
     [SerializeField] private GameObject MenuBackground;
     [SerializeField] private AudioSource audioSource;
     [SerializeField] private AudioClip audioClip;

    [SerializeField] private TextMeshProUGUI emerald_txt;
    [SerializeField] private TextMeshProUGUI diamond_txt;
    [SerializeField] private TextMeshProUGUI gold_txt;
    [SerializeField] private TextMeshProUGUI iron_txt;
    [SerializeField] private TextMeshProUGUI bread_txt;
    [SerializeField] private TextMeshProUGUI coal_txt;
    [SerializeField] private TextMeshProUGUI redStone_txt;
    [SerializeField] private TextMeshProUGUI baseLevel_txt;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject tp;
    [SerializeField] private GameObject levelCanvas;
    [SerializeField] private GameObject shopCanvas;
    void Start()
    {
        tp = GameObject.Find("TP");
        player = GameObject.FindWithTag("Player");
        levelCanvas = GameObject.Find("Levels Canvas");
        shopCanvas = GameObject.Find("Shop UI");
        levelCanvas.SetActive(false);
        shopCanvas.SetActive(false);
        LoadResurses();
        GiveText();
        MenuBackground.SetActive(false);
       


    }
    private void Update()
    {

        if(player.activeInHierarchy)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
        if(Input.GetKey(KeyCode.Tab))
        {
            Debug.Log("TAB");
            player.SetActive(false);
            MenuBackground.SetActive(true);           
            Time.timeScale = 0.000001f;
            levelCanvas.SetActive(false);
           shopCanvas.SetActive(false);

        }
        
        
    }
    [ContextMenu("GiveGold")]
    public void GiveGold()
    {
        StaticValue.Gold = StaticValue.Iron + 1;
        
        PlayerPrefs.SetInt("Gold", StaticValue.Gold);
        PlayerPrefs.SetInt("BaseLevel", 1);
    }
   
    public void SavePrice()
    {
        PlayerPrefs.SetInt("Emerald", StaticValue.Emerald);
        PlayerPrefs.SetInt("Coal", StaticValue.Coal);
        PlayerPrefs.SetInt("RedStone", StaticValue.RedStone);
        PlayerPrefs.SetInt("Diamond", StaticValue.Diamond);
        PlayerPrefs.SetInt("Bread", StaticValue.Bread);
        PlayerPrefs.SetInt("Iron", StaticValue.Iron);
        PlayerPrefs.SetInt("Gold", StaticValue.Gold);
        PlayerPrefs.SetInt("BaseLevel", StaticValue.BaseLevel);
        GiveText();
        
    }

    [ContextMenu("TurnGame")]
    public void TurnGame()
    {
            
        Time.timeScale = 1f;
        player.SetActive(true);
    }

    public void LoadResurses()
    {
        StaticValue.Emerald = PlayerPrefs.GetInt("Emerald", StaticValue.Emerald);
        StaticValue.Coal = PlayerPrefs.GetInt("Coal", StaticValue.Coal);
        StaticValue.RedStone = PlayerPrefs.GetInt("RedStone", StaticValue.RedStone);
        StaticValue.Diamond = PlayerPrefs.GetInt("Diamond", StaticValue.Diamond);
        StaticValue.Bread = PlayerPrefs.GetInt("Bread", StaticValue.Bread);
        StaticValue.Iron = PlayerPrefs.GetInt("Iron", StaticValue.Iron);
        StaticValue.Gold = PlayerPrefs.GetInt("Gold", StaticValue.Gold);
        StaticValue.BaseLevel = PlayerPrefs.GetInt("BaseLevel", 1);

        StaticValue.MoreRes = PlayerPrefs.GetInt("MoreRes",0);
        StaticValue.PicleSpeed = PlayerPrefs.GetFloat("PicleSpeed",0);
        StaticValue.RunSpeed = PlayerPrefs.GetFloat("StaticValue.RunSpeed",0);
        StaticValue.Attack = PlayerPrefs.GetInt("Attack", 0);


        StaticValue.CHEmerald = PlayerPrefs.GetInt("CHEmerald", StaticValue.CHEmerald);
        StaticValue.CHCoal = PlayerPrefs.GetInt("CHCoal", StaticValue.CHCoal);
        StaticValue.CHRedStone = PlayerPrefs.GetInt("CHRedStone", StaticValue.CHRedStone);
        StaticValue.CHDiamond = PlayerPrefs.GetInt("CHDiamond", StaticValue.CHDiamond);
        StaticValue.CHBread = PlayerPrefs.GetInt("CHBread", StaticValue.CHBread);
        StaticValue.CHIron = PlayerPrefs.GetInt("CHIron", StaticValue.CHIron);
        StaticValue.CHGold = PlayerPrefs.GetInt("CHGold", StaticValue.CHGold);

    }
    public void GiveText()
    {
        emerald_txt.text = StaticValue.Emerald.ToString();
        coal_txt.text = StaticValue.Coal.ToString();
        redStone_txt.text = StaticValue.RedStone.ToString();
        diamond_txt.text = StaticValue.Diamond.ToString();
        bread_txt.text = StaticValue.Bread.ToString();
        iron_txt.text = StaticValue.Iron.ToString();
        gold_txt.text = StaticValue.Gold.ToString();
        baseLevel_txt.text = StaticValue.BaseLevel.ToString();
    }
    public void TpPlayer()
    {
        player.transform.position = tp.transform.position;
    }
}


