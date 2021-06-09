using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    // End of the road, teleport player back to StartX when they reach the endZ.
    [SerializeField] float endZ;
    // Starting position.
    [SerializeField] float StartX;
    [SerializeField] float StartY;
    [SerializeField] float StartZ;

    private void FixedUpdate()
    {
        if (transform.position.z >= endZ)
        {
            Vector3 pos = new Vector3(StartX, StartY, StartZ);
            this.transform.localPosition = pos;
        }
    }
}