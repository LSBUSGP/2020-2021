using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObj : MonoBehaviour
{
    public GameObject Object;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Object.transform);
    }
}
