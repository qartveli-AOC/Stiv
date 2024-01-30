using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public static  int infoScene=1;
  [SerializeField] GameObject doorText;
  [SerializeField] Transform player;
  [SerializeField] float distance;
   
  
    public void MissionStart()
    {
      float playerDistance = Vector3.Distance(player.position, transform.position);
      if(playerDistance < distance)
        {
            doorText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                doorText.SetActive(false);
                SceneManager.LoadScene(infoScene);
            }
           
        }
        else
            doorText.SetActive(false);

    }
    private void Update()
    {
        MissionStart();
    }


}
