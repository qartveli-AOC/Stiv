using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DisableNull : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public int number;
    

    private void Start()
    {
        txt = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Update()
    {
        
        number = int.Parse(txt.text);
        if(number == 0)
        {
            gameObject.SetActive(false);
            Debug.Log(number);
        }
           
        
    }
    
}
