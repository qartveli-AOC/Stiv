using System.Collections;
using Commponents;
using Unity.VisualScripting;
using UnityEngine;

public class BlockCrack : MonoBehaviour
{   
   [SerializeField] private LayerMask layerMask;
   [SerializeField] private LayerMask skilletonLayer;
   [SerializeField] private Animator mineAnimation;
    private InMiningBlock firstBlock;
    private InMiningBlock secondBlock;
    public Camera mainCamera;   
    [Header("Parametr")]
    [SerializeField] private float maxDistance = 5f;
    


    float startTime=0;
    

    RaycastHit hit;
    
    private void Start()
    {
      

        mineAnimation = transform.GetChild(0).GetComponent<Animator>();        
        mainCamera = transform.GetChild(2).GetComponent<Camera>();


        Cursor.visible = false;
    }


    void Update()
    {
     
        
        

        Vector3 centerCamera = new Vector3(Screen.width/2,Screen.height/2,0);
        Ray rayOrigin = mainCamera.ScreenPointToRay(centerCamera);
        Vector3 rayDirection = transform.forward;
        Debug.DrawRay(rayOrigin.origin, rayDirection * maxDistance, Color.red);
        
        
        
        if (Physics.Raycast(rayOrigin, out hit, maxDistance, skilletonLayer))
        {
            if (Input.GetMouseButtonDown(0))
            {
                hit.transform.GetComponent<HealthComponent>().ModifyHealth(1+StaticValue.Attack);
                
              
                AttackAnimStart();
                Debug.Log("IaPOPAL PO SKILLETON ");   
            }
            
        }

        
        

        if (Physics.Raycast(rayOrigin, out hit, maxDistance, layerMask))
        {          
            secondBlock = hit.transform.GetComponent<InMiningBlock>();
            Debug.Log(secondBlock.timeNeed + " time Need");

            if (firstBlock == null )
            {
                    firstBlock = hit.transform.GetComponent<InMiningBlock>();
                    
            }
            else
            {

                if(firstBlock.kesRes!=secondBlock.kesRes)
                {
                    startTime = 0;
                    firstBlock.crackAnimator.SetBool("isCrack", false);
                    mineAnimation.SetBool("isMining", false);
                    firstBlock = hit.transform.GetComponent<InMiningBlock>();
                    
                }
                
            }
            
            if (Input.GetMouseButton(0)) 
            {
                
                    startTime += Time.deltaTime;                                 
                    Debug.Log(startTime);
                    mineAnimation.SetBool("isMining", true);
                    firstBlock.crackAnimator.SetBool("isCrack", true);
                    if (firstBlock.timeNeed <= startTime)
                    {
                       
                        firstBlock.DestroyBlock();
                        startTime = 0;
                    }                          
            }
            if(!Input.GetMouseButton(0)) 
            {

                startTime = 0;
                
                mineAnimation.SetBool("isMining", false);
                firstBlock.crackAnimator.SetBool("isCrack", false);
            }
            

            


        }
        else 
        {
            startTime = 0;

            if (firstBlock != null)
                firstBlock.crackAnimator.SetBool("isCrack", false);
                mineAnimation.SetBool("isMining", false);
        }

        


    }


    private void AttackAnimStart()
    {
        mineAnimation.SetTrigger("Attack");
    }
        

}
