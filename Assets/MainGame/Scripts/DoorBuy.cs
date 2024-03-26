using Newtonsoft.Json.Bson;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DoorBuy : MonoBehaviour
{
    [Header("____Resurses Price____")]
    [SerializeField] private int Emirald;
    [SerializeField] private int Diamond;
    [SerializeField] private int Gold;
    [SerializeField] private int Iron;
    [SerializeField] private int Bread;
    [SerializeField] private int Coal;
    [SerializeField] private int RedStone;
    
     private TextMeshProUGUI  emerald_txt;
     private TextMeshProUGUI  diamond_txt;
     private TextMeshProUGUI  gold_txt;
     private TextMeshProUGUI  iron_txt;
     private TextMeshProUGUI  bread_txt;
     private TextMeshProUGUI  coal_txt;
     private TextMeshProUGUI  redStone_txt;

    private string doorKey;

    [Header("____Events____")]    
    [SerializeField] private int DoorActive = 1;
    public UnityEvent openLevels;  
    public UnityEvent closeLevels;
    public UnityEvent buyRoom;
    private Coroutine keyCheckCoroutine;
    
    private void Start()
    {
        doorKey = gameObject.name;
        DoorActive = PlayerPrefs.GetInt(doorKey,1);
        if(DoorActive == 0)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.name !="Portal")
            keyCheckCoroutine = StartCoroutine(IKeyChecker());                     
            openLevels?.Invoke();
        if (gameObject.name != "Portal")
            FindText();
    }
    private void OnTriggerExit(Collider other)
    {
        if (gameObject.name != "Portal")
            StopCoroutine(keyCheckCoroutine);              
        closeLevels?.Invoke(); 
    }
    
    IEnumerator IKeyChecker()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                if(StaticValue.Emerald >= Emirald && StaticValue.Coal >= Coal && StaticValue.RedStone >= RedStone && StaticValue.Diamond >= Diamond && StaticValue.Bread >= Bread&& StaticValue.Iron >= Iron&& StaticValue.Gold >= Gold)
                {
                    closeLevels?.Invoke();
                    StopCoroutine(keyCheckCoroutine);
                    PriceCount();
                    buyRoom?.Invoke();
                    PlayerPrefs.SetInt(doorKey, 0);
                    gameObject.SetActive(false);
                }
            }    
            yield return null;
        }   
    }
    [ContextMenu("GiveGold")]
    public void GiveGold()
    {
        StaticValue.Gold = StaticValue.Gold +10;
        PlayerPrefs.SetInt("Gold", StaticValue.Gold);
        PlayerPrefs.SetInt(doorKey, 1);
    }

    private void PriceCount()
    {
        StaticValue.Emerald = StaticValue.Emerald - Emirald;
        StaticValue.Coal = StaticValue.Emerald - Emirald;
        StaticValue.RedStone = StaticValue.RedStone - RedStone;
        StaticValue.Diamond = StaticValue.Diamond - Diamond;
        StaticValue.Bread = StaticValue.Bread - Bread;
        StaticValue.Iron = StaticValue.Iron - Iron;
        StaticValue.Gold = StaticValue.Gold - Gold;       
    }

    private void FindText()
    {
        emerald_txt = GameObject.FindWithTag("Emirald").GetComponent<TextMeshProUGUI>();
        diamond_txt = GameObject.FindWithTag("Diamond").GetComponent<TextMeshProUGUI>();
        gold_txt = GameObject.FindWithTag("Gold").GetComponent<TextMeshProUGUI>();
        iron_txt = GameObject.FindWithTag("Iron").GetComponent<TextMeshProUGUI>();
        bread_txt = GameObject.FindWithTag("Bread").GetComponent<TextMeshProUGUI>();
        coal_txt = GameObject.FindWithTag("Coal").GetComponent<TextMeshProUGUI>();
        redStone_txt = GameObject.FindWithTag("RedStone").GetComponent<TextMeshProUGUI>();

        emerald_txt.text = Emirald.ToString();
        diamond_txt.text = Diamond.ToString();
        gold_txt.text = Gold.ToString();
        iron_txt.text = Iron.ToString();
        bread_txt.text = Bread.ToString();
        coal_txt.text = Coal.ToString();
        redStone_txt.text = RedStone.ToString();

    }
}


