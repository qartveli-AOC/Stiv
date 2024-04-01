using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BlockCrack : MonoBehaviour
{   
   [SerializeField] private LayerMask layerMask;
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
    }

    // Update is called once per frame
    void Update()
    {
       
        

        Vector3 centerCamera = new Vector3(Screen.width/2,Screen.height/2,0);
        Ray rayOrigin = mainCamera.ScreenPointToRay(centerCamera);
        Vector3 rayDirection = transform.forward;
        Debug.DrawRay(rayOrigin.origin, rayDirection * maxDistance, Color.red);
        
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
            if(firstBlock != null)
                firstBlock.crackAnimator.SetBool("isCrack", false);
                mineAnimation.SetBool("isMining", false);
        }



    }

   


    /*IEnumerator Icrack()
    {
       
        mineAnimation.SetBool("isMinig",true);
     
        if(pastTime > timeNeed)
        {
            yield return null;
            hit.rigidbody.gameObject.SetActive(false);
            GiveResurses();
        }else
            mineAnimation.SetBool("isMinig", false);


    }*/
    
}
