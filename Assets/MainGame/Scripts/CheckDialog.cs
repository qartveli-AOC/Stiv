using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDialog : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] CharacterController ch;
    [SerializeField] AudioSource playerVoice;
    [HideInInspector] public static bool isManinCamera = true;


    private void Start()
    {        
        
        
    }
    public void CameraOn()
        {
            mainCamera.enabled = false;
       
            ch.enabled = false;                     
            playerVoice.enabled = false;
            isManinCamera = false;
        }
       public void CameraOff()
        {
            mainCamera.enabled = true;
           
            ch.enabled= true;            
            playerVoice.enabled = true;
            isManinCamera = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        ch = other.gameObject.GetComponent<CharacterController>();
        playerVoice = other.gameObject.GetComponent<AudioSource>();
        mainCamera = other.gameObject.GetComponentInChildren<Camera>();
       
    }



}
