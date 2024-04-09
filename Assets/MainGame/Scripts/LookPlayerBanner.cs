using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayerBanner : MonoBehaviour
{
    [SerializeField] GameObject player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        transform.LookAt(player.transform);
    }

}
