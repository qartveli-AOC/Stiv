using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    private float xSensetivity=30f;
    private float ySensetivity=30f;


  public void LookStart(Vector2 value)
    {
      float mouseY = value.y;
      float mouseX = value.x;

        xRotation -= (mouseY * Time.deltaTime) * ySensetivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up*(mouseX *  Time.deltaTime)*xSensetivity);
    }
}
