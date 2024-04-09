using Newtonsoft.Json.Bson;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorBuy : MonoBehaviour
{
    [Header("____Resurses Price____")]
    [SerializeField] private int Emerald;
    [SerializeField] private int Diamond;
    [SerializeField] private int Gold;
    [SerializeField] private int Iron;
    [SerializeField] private int Bread;
    [SerializeField] private int Coal;
    [SerializeField] private int RedStone;

    [Header("____Base Level____")]
    [SerializeField] private int baseLevelNeed = 1;
    [SerializeField] private float colorChangeTime;

     private TextMeshProUGUI  emerald_txt;
     private TextMeshProUGUI  diamond_txt;
     private TextMeshProUGUI  gold_txt;
     private TextMeshProUGUI  iron_txt;
     private TextMeshProUGUI  bread_txt;
     private TextMeshProUGUI  coal_txt;
     private TextMeshProUGUI  redStone_txt;   
     public TextMeshProUGUI  baseLevel_txt;

    bool isWorkCorutine = false;

    private string doorKey;

    [Header("____Events____")]    
    [SerializeField] private int DoorActive = 1;
    public UnityEvent openLevels;  
    public UnityEvent closeLevels;
    public UnityEvent closeMoreLevel;
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
            openLevels?.Invoke();
            FindText();
            keyCheckCoroutine = StartCoroutine(IKeyChecker());          
              
    }
    private void OnTriggerExit(Collider other)
    {
            if(baseLevelNeed <= StaticValue.BaseLevel)
            StopCoroutine(keyCheckCoroutine);            
            closeLevels?.Invoke(); 
    }
    
    IEnumerator IKeyChecker()
    {
        if(baseLevelNeed<=StaticValue.BaseLevel)
        {
            closeMoreLevel?.Invoke();
            while (true)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    Debug.Log("E");
                    StartColorChange();
                    if (StaticValue.Emerald >= Emerald && StaticValue.Coal >= Coal && StaticValue.RedStone >= RedStone && StaticValue.Diamond >= Diamond && StaticValue.Bread >= Bread && StaticValue.Iron >= Iron && StaticValue.Gold >= Gold)
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
        StaticValue.Emerald = StaticValue.Emerald - Emerald;
        StaticValue.Coal = StaticValue.Coal - Coal;
        StaticValue.RedStone = StaticValue.RedStone - RedStone;
        StaticValue.Diamond = StaticValue.Diamond - Diamond;
        StaticValue.Bread = StaticValue.Bread - Bread;
        StaticValue.Iron = StaticValue.Iron - Iron;
        StaticValue.Gold = StaticValue.Gold - Gold;       
    }

    private void FindText()
    {
        if(Emerald != 0)
        {
            emerald_txt = GameObject.FindWithTag("Emerald").GetComponent<TextMeshProUGUI>();
            emerald_txt.text = Emerald.ToString();
        }            
        if (Diamond != 0)
        {
            diamond_txt = GameObject.FindWithTag("Diamond").GetComponent<TextMeshProUGUI>();
            diamond_txt.text = Diamond.ToString();
        }           
        if (Gold != 0)
        {
            gold_txt = GameObject.FindWithTag("Gold").GetComponent<TextMeshProUGUI>();
            gold_txt.text = Gold.ToString();
        }          
        if (Iron != 0)
        {
            iron_txt = GameObject.FindWithTag("Iron").GetComponent<TextMeshProUGUI>();
            iron_txt.text = Iron.ToString();
        }           
        if (Bread != 0)
        {
            bread_txt = GameObject.FindWithTag("Bread").GetComponent<TextMeshProUGUI>();
            bread_txt.text = Bread.ToString();
        }            
        if (Coal != 0)
        {
            coal_txt = GameObject.FindWithTag("Coal").GetComponent<TextMeshProUGUI>();
            coal_txt.text = Coal.ToString();
        }           
        if (RedStone != 0)
        {
            redStone_txt = GameObject.FindWithTag("RedStone").GetComponent<TextMeshProUGUI>();
            redStone_txt.text = RedStone.ToString();
        }
            baseLevel_txt = GameObject.FindWithTag("BaseLevel").GetComponent<TextMeshProUGUI>();
            baseLevel_txt.text = baseLevelNeed.ToString();

        
    }
    private void StartColorChange()
    {
        
        if(isWorkCorutine == false)
          {
            isWorkCorutine = true;
            StartCoroutine(ChangeEmerald());
            StartCoroutine(ChangeCoal());
            StartCoroutine(ChangeRedStone());
            StartCoroutine(ChangeDiamond());
            StartCoroutine(ChangeBread());
            StartCoroutine(ChangeIron());
            StartCoroutine(ChangeGold());
            
        }
        
    }
   
    IEnumerator ChangeEmerald()
    {
        if (StaticValue.Emerald < Emerald && Emerald !=0)
        {
            emerald_txt.color = Color.red;
            yield return new WaitForSeconds(colorChangeTime);
            emerald_txt.color = Color.black;
            yield return new WaitForSeconds(colorChangeTime);
            emerald_txt.color = Color.red;
            yield return new WaitForSeconds(colorChangeTime);
            emerald_txt.color = Color.black;
            isWorkCorutine = false;
        }
      
    }
    IEnumerator ChangeCoal()
    {
        if (StaticValue.Coal < Coal && Coal != 0)
        {
            coal_txt.color = Color.red;
            yield return new WaitForSeconds(colorChangeTime);
            coal_txt.color = Color.black;
            yield return new WaitForSeconds(colorChangeTime);
            coal_txt.color = Color.red;
            yield return new WaitForSeconds(colorChangeTime);
            coal_txt.color = Color.black;
            isWorkCorutine = false;
        }     
    }
    IEnumerator ChangeRedStone()
    {
        if (StaticValue.RedStone < RedStone && RedStone != 0)
        {
            redStone_txt.color = Color.red;
            yield return new WaitForSeconds(colorChangeTime);
            redStone_txt.color = Color.black;
            yield return new WaitForSeconds(colorChangeTime);
            redStone_txt.color = Color.red;
            yield return new WaitForSeconds(colorChangeTime);
            redStone_txt.color = Color.black;
            isWorkCorutine = false;
        }       
    }
    IEnumerator ChangeDiamond()
    {
        if (StaticValue.Diamond < Diamond && Diamond != 0)
        {
            diamond_txt.color = Color.red;
            yield return new WaitForSeconds(colorChangeTime);
            diamond_txt.color = Color.black;
            yield return new WaitForSeconds(colorChangeTime);
            diamond_txt.color = Color.red;
            yield return new WaitForSeconds(colorChangeTime);
            diamond_txt.color = Color.black;
            isWorkCorutine = false;
        }        
    }
    IEnumerator ChangeBread()
    {
        if (StaticValue.Bread < Bread && Bread != 0)
        {
            bread_txt.color = Color.red;
            yield return new WaitForSeconds(colorChangeTime);
            bread_txt.color = Color.black;
            yield return new WaitForSeconds(colorChangeTime);
            bread_txt.color = Color.red;
            yield return new WaitForSeconds(colorChangeTime);
            bread_txt.color = Color.black;
            isWorkCorutine = false;
        }     
    }
    IEnumerator ChangeIron()
    {
        if (StaticValue.Iron < Iron && Iron != 0)
        {
            iron_txt.color = Color.red;
            yield return new WaitForSeconds(colorChangeTime);
            iron_txt.color = Color.black;
            yield return new WaitForSeconds(colorChangeTime);
            iron_txt.color = Color.red;
            yield return new WaitForSeconds(colorChangeTime);
            iron_txt.color = Color.black;
            isWorkCorutine = false;
        }
    }
    IEnumerator ChangeGold()
    {
        if (StaticValue.Gold < Gold && Gold != 0)
        {
            gold_txt.color = Color.red;
            yield return new WaitForSeconds(colorChangeTime);
            gold_txt.color = Color.black;
            yield return new WaitForSeconds(colorChangeTime);
            gold_txt.color = Color.red;
            yield return new WaitForSeconds(colorChangeTime);
            gold_txt.color = Color.black;
            isWorkCorutine = false;
        }
    }
}


