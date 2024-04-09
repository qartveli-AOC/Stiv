using UnityEngine;

public class DisableObject : MonoBehaviour
{
    public void DisableItem()
    {
        gameObject.SetActive(false);
    }

    public void EnableItem()
    {
        gameObject.SetActive(true);
    }
    
}
