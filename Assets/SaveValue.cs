using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveValue : MonoBehaviour
{
    
    [SerializeField] Slider slider;

  
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat("value", 0.2f);
        MusicWork.instance.adio.volume = slider.value;
        slider.onValueChanged.AddListener(SearchAudio);
        
        
    }
    public void save()
    {
        PlayerPrefs.SetFloat("value",slider.value);
    }
    public void SearchAudio(float f)
    {
        
        MusicWork.instance.adio.volume = slider.value;
    }
    
}
