using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensety : MonoBehaviour
{
  
    public  Slider slider;
    


    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.minValue = 1f;
        slider.maxValue = 25f;
        slider.value = PlayerPrefs.GetFloat("SenceSlider", slider.maxValue);
        PlayerLook.GiveSensety = slider.value;
    }



    public void SaverSlider()
    {      
        PlayerPrefs.SetFloat("SenceSlider", slider.value); 
        PlayerLook.GiveSensety = slider.value;
    }
    



}
