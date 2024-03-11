using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
     [SerializeField] private GameObject MenuBackground;
     [SerializeField] private AudioSource audioSource;
     void Start()
    {
        
        MenuBackground.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Tab))
        { 
            MenuBackground.SetActive(true); 
            audioSource.mute=true;
            Time.timeScale = 0.000001f; 
        }
        
    }

    public void TurnGame()
    {
        audioSource.mute = false;
        Time.timeScale = 1f;
    }
}
