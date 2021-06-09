using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    [SerializeField] GameObject platform;

    private void Update()
    {
        platform = GameObject.FindGameObjectWithTag("Platform");
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Platform")
        {
            Destroy(platform);
        }
    }
}
