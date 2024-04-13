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
        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat("SenceSlider", 0.5f);
    }
    
    

    private void OnEnable()
    {
      
       
        Debug.LogError("SensetyStart" +"slider.value" + slider.value  );
    }

    public void SaverSlider()
    {
        PlayerPrefs.SetFloat("SenceSlider", slider.value);
        Debug.LogError("Sensetysave" +"slider.value" + slider.value  );
    }

    
   
}
