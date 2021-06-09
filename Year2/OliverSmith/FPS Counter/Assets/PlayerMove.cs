using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    public Transform _camera;

    public float moveSpeed = 6f;
    public float CurrentSpeed = 6f;
    public float jumpForce = 10f;
    public float SprintSpeed = 10f;

    public LayerMask Ground;

    public bool isGrounded;

    void Start()
    {

    }

    void Update()
    {
        //grounding
        isGrounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 0.4f, Ground);


        //facing direction
        Debug.DrawLine(_camera.position, transform.forward * 2.5f);

        //moving
        float x = Input.GetAxisRaw("Horizontal") * CurrentSpeed;
        float y = Input.GetAxisRaw("Vertical") * CurrentSpeed;
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            CurrentSpeed = SprintSpeed;
        }
        else
        {
            CurrentSpeed = moveSpeed;
        }

        //jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

        //setting movement
        Vector3 move = transform.right * x + transform.forward * y;

        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
    }
}
