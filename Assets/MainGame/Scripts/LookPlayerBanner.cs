using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayerBanner : MonoBehaviour
{
    [SerializeField] Transform player;
    private void Update()
    {
        transform.LookAt(player);
    }

}
