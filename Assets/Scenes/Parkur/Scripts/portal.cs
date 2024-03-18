using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{

    [Header("____Events____")]
    public UnityEvent openLevels;
    public UnityEvent closeLevels;
    
    private void OnTriggerEnter(Collider other)
    {
        openLevels?.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        closeLevels?.Invoke();
    }
}


