using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MassiveObject : MonoBehaviour
{
    [SerializeField] private Image[] images;
    public void TurnAll()
    {
        for(int i = 0; i < images.Length; i++) 
        {            
            images[i].gameObject.SetActive(true);                        
        }
    }
   
}
