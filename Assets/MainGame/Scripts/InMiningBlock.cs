using UnityEngine;




public class InMiningBlock : MonoBehaviour
{
    
    [SerializeField] private int resNum;
    [SerializeField] private Res chooseRes;
    [SerializeField] private float xTimeMining;
                     private float thisTime;

    [HideInInspector] public float timeNeed;
    [HideInInspector] public string kesRes;
    [HideInInspector] public Animator crackAnimator;
    
   
    

    void Start()
    {
        

        thisTime = 1 * xTimeMining ;
        timeNeed = 1 / xTimeMining ;

        
        crackAnimator = GetComponentInChildren<Animator>();
        kesRes = gameObject.name;
        
        crackAnimator.speed = thisTime;
    }

    public void DestroyBlock()
    {
        GiveResurses();
        gameObject.SetActive(false);

    }
    
    private void GiveResurses()
    {
        switch (chooseRes)
        {
            case Res.Bread:
                StaticValue.CHBread += resNum;
                PlayerPrefs.SetInt("CHBread", StaticValue.CHBread);              
                break;
            case Res.Coal:
                StaticValue.CHCoal += resNum;
                PlayerPrefs.SetInt("CHCoal", StaticValue.CHCoal);
                break;
            case Res.RedStone:
                StaticValue.CHRedStone += resNum;
                PlayerPrefs.SetInt("CHRedStone", StaticValue.CHRedStone);
                break;
            case Res.Iron:
                StaticValue.CHIron += resNum;
                PlayerPrefs.SetInt("CHIron", StaticValue.CHIron);
                break;
            case Res.Gold:
                StaticValue.CHGold += resNum;
                PlayerPrefs.SetInt("CHGold", StaticValue.CHGold);
                break;
            case Res.Emerald:
                StaticValue.CHEmerald += resNum;
                PlayerPrefs.SetInt("CHEmerald", StaticValue.CHEmerald);
                break;
            case Res.Diamond:
                StaticValue.CHDiamond += resNum;
                PlayerPrefs.SetInt("CHDiamond", StaticValue.CHDiamond);
                break;

        }

    }
    
}
public enum Res
{
    Bread, Coal, RedStone, Iron, Gold, Emerald, Diamond
}
