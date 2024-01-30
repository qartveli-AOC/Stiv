using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDialog : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Camera secondCamera;
    [SerializeField] CharacterController ch;
    [SerializeField] AudioSource playerVoice;
    [HideInInspector] public static bool isManinCamera = true;


    private void Start()
    {        
        secondCamera = GetComponentInChildren<Camera>();
        secondCamera.gameObject.SetActive(false);
    }
    public void CameraOn()
        {
            mainCamera.enabled = false;
            secondCamera.enabled = true;
            ch.enabled = false;                     
            playerVoice.enabled = false;
            isManinCamera = false;
        }
       public void CameraOff()
        {
            mainCamera.enabled = true;
            secondCamera.enabled = false;
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
