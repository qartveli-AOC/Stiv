using TMPro;
using UnityEngine;
using YG;

public class FontBigger : MonoBehaviour
{
    public TextMeshProUGUI[] tx;
    [SerializeField] GameObject[] gmEn;
    [SerializeField] GameObject[] gmRu;
        
    private void Start()
    {
        
       
        for (int i = 0; gmEn.Length>i;i++)
        {
            if (YandexGame.lang == "ru")
                gmEn[i].SetActive(false);
            if (YandexGame.lang == "en")
                gmRu[i].SetActive(false);
        }
        


        
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("txt");
        tx = new TextMeshProUGUI[taggedObjects.Length];
        for (int i = 0; i < taggedObjects.Length; i++)
        {
            tx[i] = taggedObjects[i].GetComponent<TextMeshProUGUI>();
        }

        
        BigS();
    }
    public void BigS()
    {
        for(int i = 0; i< tx.Length; i++) 
        {           
            tx[i].fontSize = 0.5f;
        }
        if(YandexGame.lang == "ru")
        {

            for (int i = 0; gmRu.Length > i; i++)
            {
                gmRu[i].SetActive(true);
                gmEn[i].SetActive(false);
            }
               
        }
        if(YandexGame.lang == "en")
        {
            for (int i = 0; gmEn.Length > i; i++)
            {
                gmEn[i].SetActive(true);
                gmRu[i].SetActive(false);
            }
               
        }
    }
}
