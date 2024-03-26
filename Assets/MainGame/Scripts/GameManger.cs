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
    void Start()
    {
        LoadResurses();
        GiveText();
        MenuBackground.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Tab))
        { 
            MenuBackground.SetActive(true); 
            audioSource.mute=true;
            Time.timeScale = 0.000001f; 

            if(Input.GetKey(KeyCode.Tab))
            {
                TurnGame();
            }
        }
        
        Debug.Log( "  Coal  "+ StaticValue.Coal );
    }
    [ContextMenu("GiveGold")]
    public void GiveGold()
    {
        StaticValue.Gold = StaticValue.Gold + 1;
        PlayerPrefs.SetInt("Gold", StaticValue.Gold);
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


    public void TurnGame()
    {
        audioSource.mute = false;
        Time.timeScale = 1f;
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
        StaticValue.BaseLevel = PlayerPrefs.GetInt("BaseLevel", StaticValue.BaseLevel);

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
}


