using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadHearts : MonoBehaviour
{
    [SerializeField] GameObject[] heartImg;
    void Start()
    {
        for(int i = 0; i <= 3; i++)
        {
            heartImg[i].gameObject.SetActive(true);
        }
    }


}
