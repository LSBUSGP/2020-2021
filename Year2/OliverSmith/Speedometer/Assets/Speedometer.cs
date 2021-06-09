using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    Rigidbody rb;
    public float Speed;
    public Text Speedtext;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       Speed = rb.velocity.magnitude * 2.23694f;

        Speed = Mathf.Round(Speed * 100.0f) * 0.01f;
        Speedtext.text = (Speed + "MPH");
        
        


    }
}
