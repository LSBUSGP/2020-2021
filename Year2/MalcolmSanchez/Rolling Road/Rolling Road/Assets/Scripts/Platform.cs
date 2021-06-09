using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Rigidbody rb;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        speed = -2f;
    }

    private void Update()
    {
        rb.velocity = transform.right * speed;
    }
}
