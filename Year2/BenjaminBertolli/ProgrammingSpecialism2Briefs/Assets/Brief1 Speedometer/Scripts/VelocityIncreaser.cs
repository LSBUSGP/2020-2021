using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityIncreaser : MonoBehaviour
{
    public float MaxSpeed = 25;
    public float SpeedCooldownMax = 4;

    private Rigidbody RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody>();
        Invoke("AddSpeed", SpeedCooldownMax);
    }

    private void AddSpeed()
    {
        RB.AddForce(new Vector3(Random.Range(-MaxSpeed, MaxSpeed), 0, Random.Range(-MaxSpeed, MaxSpeed)));
        Invoke("AddSpeed", SpeedCooldownMax);
    }


}
