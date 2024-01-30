using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PInput input;
    private PlayerMotor motor;
    private PlayerLook look;

    public PInput.OnMoveActions onMove;

    private void Awake()
    {
        input = new PInput();
        onMove = input.OnMove;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        onMove.Jump.performed += jjj => motor.Jump();
    }

    private void FixedUpdate()
    {
        motor.MoveStart(onMove.move.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        if(CheckDialog.isManinCamera)
        look.LookStart(onMove.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        onMove.Enable();
    }
    private void OnDisable()
    {
        onMove.Disable();
    }

}
