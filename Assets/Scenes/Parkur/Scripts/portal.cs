using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    [SerializeField] private  int portalId;
    
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(portalId);
    }
    
}


