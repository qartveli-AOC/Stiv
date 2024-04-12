using System;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;
     
    public float xSensetivity = 30;
    public float ySensetivity = 30;

    private void OnEnable()
    {
        xSensetivity = Sensety.slider.value;
        ySensetivity =Sensety.slider.value;
        Debug.LogError("PlayerLookStart" +"XSens YSens" +xSensetivity + "///" + ySensetivity );
    }

    private void Update()
    {
        Debug.LogError("PlayerLookUpdate" +"XSens YSens" +xSensetivity + "///" + ySensetivity );
    }


    public void LookStart(Vector2 value)
    {
      float mouseY = value.y;
      float mouseX = value.x;

        xRotation -= (mouseY * Time.deltaTime) * ySensetivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up*(mouseX *  Time.deltaTime)*xSensetivity);
    }



    public void SensitivityChanger(float sensitivity)
    {
        xSensetivity = sensitivity;
        ySensetivity = sensitivity;
        Debug.LogError("FAFAFAFAFAFAFAF");
    }
    
}
