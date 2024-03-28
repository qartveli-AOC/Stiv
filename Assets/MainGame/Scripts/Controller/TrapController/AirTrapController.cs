using System.Collections;
using UnityEngine;

public class AirTrapController : MonoBehaviour
{
    [SerializeField] private Vector3 airFlowDirection = Vector3.up; 
    [SerializeField] private float airFlowSpeed = 5f; 
    
    private float liftDuration = 1f;
    private bool isLifting = false; 
    private CharacterController _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player = other.GetComponent<CharacterController>();
            StartCoroutine(LiftPlayer(other.transform));
           
        }
    }

    private IEnumerator LiftPlayer(Transform playerTransform)
    {
        isLifting = true;
        float elapsedTime = 0f;
        Destroy(GetComponent<BoxCollider>());
        
        while (elapsedTime < liftDuration)
        {
            Vector3 currentPosition = playerTransform.position;
            Vector3 targetPosition = currentPosition + airFlowDirection * airFlowSpeed * Time.deltaTime;

            _player.Move(targetPosition - currentPosition);
            Debug.Log("Working");
            elapsedTime += Time.deltaTime;
            
            yield return null;
        }
        yield return new WaitForSeconds(1);
        
        gameObject.AddComponent<BoxCollider>().size = new Vector3(1,7.4f,1);
        gameObject.GetComponent<BoxCollider>().center = new Vector3(0,3.2f,0);
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
        isLifting = false;
    }
}