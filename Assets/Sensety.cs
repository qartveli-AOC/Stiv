using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensety : MonoBehaviour
{
   [SerializeField] Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat("ForMenuSensty", 25f);
        PlayerLook.ForMenuSensty = slider.value;
        slider.onValueChanged.AddListener(SensetyChange);
    }
    public void saveSensety()
    {
        PlayerPrefs.SetFloat("ForMenuSensty", slider.value);
    }
    public void SensetyChange(float f)
    {

        PlayerLook.ForMenuSensty = slider.value;
    }
}
