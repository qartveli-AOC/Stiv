using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string Messege;
    public bool UseEvents_B;

    public void BaseInteract()
    {
        if(UseEvents_B)
        {
            GetComponent<InteractionEvents>().OnInteract.Invoke();
        }
        Interact();
    }
    protected virtual void Interact()
    {

    }
}
