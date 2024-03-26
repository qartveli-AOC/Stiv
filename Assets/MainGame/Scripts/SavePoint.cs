using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static System.Net.WebRequestMethods;

public class SavePoint : MonoBehaviour
{

    [SerializeField] private Transform TP;
    [SerializeField] private CharacterController playerController;
    [SerializeField] private float[] values = new float[3];
    
       
    private void Start()
    {
        Debug.Log("  heart left  " + StaticValue.Heart);
        if (StaticValue.Heart <= 0)
            Reset2();

                for (int i = 0; i < values.Length; i++)
            {
                values[i] = PlayerPrefs.GetFloat("value" + i);
                Debug.Log(values[i] + "  value" + i);
            }
        
        playerController = FindAnyObjectByType<CharacterController>();
        Vector3 temp = new Vector3(values[0], values[1], values[2]);

        
        if (values[0] != 0 && values[1] != 0)
        {
            playerController.Move(temp - playerController.transform.position);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        
            values[0] = gameObject.transform.position.x;
            values[1] = gameObject.transform.position.y;
            values[2] = gameObject.transform.position.z;

            for (int i = 0; i < values.Length; i++)
                PlayerPrefs.SetFloat("value"+i, values[i]);
                gameObject.SetActive(false);
        }
    [ContextMenu("Reset2")]
    public void Reset2()
    {
        for (int i = 0; i < values.Length; i++)
        {
            values[i] = 0;
            PlayerPrefs.SetFloat("value" + i, values[i]);
        }
            
    }
}
    

