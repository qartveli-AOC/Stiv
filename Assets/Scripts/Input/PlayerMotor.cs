using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    [SerializeField] float Speed = 5.0f;
    [SerializeField] float Gravity = -9.8f;
    [SerializeField] float JumpHight = 3f;
    [SerializeField] AudioSource movesSound;      
    [SerializeField] AudioClip[] leg;
    [SerializeField] AudioClip[] jump;
    [SerializeField] Camera cam;
    
    
    


    private void Start()
    {
        
        controller = GetComponent<CharacterController>();       
    }
    private void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = 8;        
            
             float Camspeed = Mathf.Lerp(cam.fieldOfView,80,Time.deltaTime*2);
             cam.fieldOfView = Camspeed;
        }
        else
        {
            Speed = 5;
            float Camspeed = Mathf.Lerp(cam.fieldOfView, 60, Time.deltaTime * 2);
            cam.fieldOfView = Camspeed;
            
        }
        
        

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            movesSound.PlayOneShot(jump[Random.Range(0,3)]);      
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            
            movesSound.pitch = Random.Range(0.9f, 1.6f);
            if (!movesSound.isPlaying)              
                movesSound.PlayOneShot(leg[Random.Range(0,3)]);          
        }
        
            
        isGrounded = controller.isGrounded;

    }
    public void MoveStart(Vector2 value)
    {   
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = value.x;
        moveDirection.z = value.y;        
        controller.Move(transform.TransformDirection(moveDirection) * Speed * Time.deltaTime);
        playerVelocity.y += Gravity * Time.deltaTime;      
        if (isGrounded && playerVelocity.y < 0 )
        {           
            playerVelocity.y = -2f;            
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }
    public void Jump()
    {
        
        if (isGrounded)  
        {
            playerVelocity.y = Mathf.Sqrt(JumpHight * -3.0f * Gravity);
        }
    }
}
