using TMPro;
using UnityEngine;
using YG;

public class LanSetter : MonoBehaviour
{
    //public TextMeshProUGUI[] tx;
    [SerializeField] GameObject[] gmEn;
    [SerializeField] GameObject[] gmRu;
    [SerializeField] GameObject[] gmTr;
        
    private void Start()
    {
        
       
       /* for (int i = 0; gmEn.Length>i;i++)
        {
            if (YandexGame.lang == "ru")
                gmEn[i].SetActive(false);
            if (YandexGame.lang == "en")
                gmRu[i].SetActive(false);
            if (YandexGame.lang == "tr")
                gmTr[i].SetActive(false);
        }*/

         ChangeLan();
     }
     public void ChangeLan()
     {
        
        if (YandexGame.lang == "ru")
         {

             for (int i = 0; gmRu.Length > i; i++)
             {
                 gmRu[i].SetActive(true);
                 gmEn[i].SetActive(false);
                 gmTr[i].SetActive(false);
             }

         }
         if(YandexGame.lang == "en")
         {
             for (int i = 0; gmEn.Length > i; i++)
             {
                 gmEn[i].SetActive(true);
                 gmRu[i].SetActive(false);
                 gmTr[i].SetActive(false);
             }

         }
         if(YandexGame.lang == "tr")
         {
            for (int i = 0; gmTr.Length > i; i++)
            {
                gmTr[i].SetActive(true);
                gmEn[i].SetActive(false);
                gmRu[i].SetActive(false);                
            }
         }

     
    }
}
