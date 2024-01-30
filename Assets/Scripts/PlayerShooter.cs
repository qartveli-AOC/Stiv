using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public  int magazine = 30;
    public  int FullAmo = 90;
    private  int stack;
    private void Start()
    {
        stack = magazine;
    }
    private void Update()
    {
        Mathf.Clamp(magazine, 0, 30);
        Debug.Log($"stack: {stack} Magazine: {magazine} FullAmo: {FullAmo}");
        if ( Input.GetKey(KeyCode.R) && magazine<30 && FullAmo >0)
        {
            Reload();
        }
       if(Input.GetKeyUp(KeyCode.W) && magazine > 0)
        {
            Shoot();
        }

    }
    public void Reload()
    {
        stack -= magazine;
        magazine += stack;
        FullAmo -= stack;
        stack = magazine;               
    }
    public void Shoot()
    {
        magazine -= 1;
    }

}
