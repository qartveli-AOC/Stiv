using UnityEngine;
using UnityEngine.UI;

public class HeathPlayer : MonoBehaviour
{
    private float heath;
    private float lerpTimer;
    public float chipSpeed = 2f;
    public float maxHeath = 100;

    public Image front;
    public Image back;
    

    private void Start()
    {
        heath = maxHeath;
    }

    private void Update()
    {
        heath = Mathf.Clamp(heath, 0, maxHeath);
        HeathCheck();
        if(Input.GetKeyDown(KeyCode.A))
        {
            TakeDamage(Random.Range(4, 12));
        }if(Input.GetKeyDown(KeyCode.D))
        {
            TakeHill(Random.Range(4, 12));
        }
    }
    public void HeathCheck()
    {
        Debug.Log(heath);
        float fillF = front.fillAmount;
        float fillB = back.fillAmount;
        float hFraction = heath / maxHeath;

        if(fillB > hFraction)
        {
            front.fillAmount = hFraction;
            back.color = Color.red;
            lerpTimer += Time.deltaTime;          
            float percentComplete = lerpTimer / chipSpeed;           
            back.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }else if (fillF < hFraction)                     
        {
            back.fillAmount = hFraction;
            back.color= Color.green;           
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            front.fillAmount = Mathf.Lerp(fillF, hFraction, percentComplete);
            
        }


    }
    public void TakeHill(float hill)
    {
        heath += hill;
        lerpTimer = 0;
    }
    public void TakeDamage(float damage)
    {
        heath -= damage;
        lerpTimer = 0;
    }
}
