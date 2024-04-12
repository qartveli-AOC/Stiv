using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicWork : MonoBehaviour
{
    public static MusicWork instance;
    public AudioSource adio;
    
    private void Awake()
    {
        adio = GetComponent<AudioSource>();
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        if(instance != this) 
        {
        Destroy(gameObject);
        }
        
    }
}
