using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distance = 5f;
    [SerializeField] private LayerMask mask;
    private PlayerUi ui;
    private PlayerInput input;

    private void Awake()
    {
        cam = GetComponent<PlayerLook>().cam;
        ui = GetComponent<PlayerUi>();
        input = GetComponent<PlayerInput>(); 
    }
    private void Update()
    {
        ui.TextUpdate(string.Empty);
        Color red = Color.red;
        Ray ray  =  new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction*distance, red);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, distance, mask))
        {
            if(hit.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                ui.TextUpdate(interactable.Messege);
                if(input.onMove.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
