using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resset : MonoBehaviour
{
    
    void Start()
    {
        StaticValue.Heart = PlayerPrefs.GetInt("Heart", 2);
        PlayerPrefs.SetInt("thisHeart",StaticValue.Heart );
        
    }

}
