using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float thrust;
    //public float slowDownSpeed;
    public float rotateSpeed;
    public Text text;
    public float mph;

    private Transform tr;
    private Rigidbody rb;
    private bool forward;
    private bool right;
    private bool left;
    // Start is called before the first frame update
    void Start()
    {
        right = false;
        left = false;
        forward = false;
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {  

        //UPDATE TEXT HERE
        text.text = "" + mph;


        //HOLDING AND RELEASING FORWARD KEY
        if (Input.GetKey(KeyCode.W))
        {
            forward = true;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            forward = false;
        }

        //LEFT AND RIGHT KEYS
        if (Input.GetKey(KeyCode.D))
        {
            right = true;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            right = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            left = true;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            left = false;
        }

    }
    private void FixedUpdate()
    {
        //MILES PER HOUR CONVERSION 
        mph = rb.velocity.magnitude * 2.23694f * Time.fixedDeltaTime;

        if (forward)
        {
            rb.AddForce(transform.forward * thrust * Time.fixedDeltaTime);
            rb.drag = 0;
        }
        if (!forward)
        {
            rb.drag = 3;
        }

        if (right && !left)
        {
            tr.Rotate(0, 1f * rotateSpeed, 0);
        }
        if (left && !right)
        {
            tr.Rotate(0, -1f * rotateSpeed, 0);
        }
    }
}

