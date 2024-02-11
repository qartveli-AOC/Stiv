using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoHome : MonoBehaviour
{
     private int homeScene = 0;
    [SerializeField] GameObject Crystal;
    [SerializeField] Transform player;
    [SerializeField] float distance;    
    [SerializeField] GameObject goldUI;
    [SerializeField] AudioSource audio;
    


    public void MissionStart()
    {
        float playerDistance = Vector3.Distance(player.position, transform.position);
        if (playerDistance < distance)
        {
            Crystal.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {

                StartCoroutine(showGold());
               
                
            }

        }
        else
            Crystal.SetActive(false);

    }
    IEnumerator showGold()
    {
        Crystal.SetActive(false); 
        audio.Play();
        goldUI.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(homeScene);
    }
    private void Update()
    {
        MissionStart();
    }
    

}


