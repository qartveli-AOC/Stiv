using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensety : MonoBehaviour
{
  
    public static Slider slider;
    private void Awake()
    {
        slider = transform.GetChild(0).GetChild(4).GetChild(3).GetChild(1).GetComponent<Slider>();
        slider.minValue = 10;
        slider.maxValue = 100;
        
        slider.value = PlayerPrefs.GetFloat("SensentivitySavere123", 45);
    }
    
    

    private void OnEnable()
    {
      
       
        Debug.LogError("SensetyStart" +"slider.value" + slider.value  );
    }

    public void SaverSlider()
    {
        PlayerPrefs.SetFloat("SensentivitySavere123", slider.value);
        Debug.LogError("Sensetysave" +"slider.value" + slider.value  );
    }

    
   
}
