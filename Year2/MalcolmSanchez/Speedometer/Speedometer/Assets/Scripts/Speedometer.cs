using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    // Since Unity uses meters as default, if you get the distance traveled every second, you will get meters/second. 1 m/s = 3.6 km/h. 1km/h = 0,621371 Mph 
    // https://answers.unity.com/questions/1367635/how-can-display-an-object-movement-speed-in-kmh-or.html

    // Reference the player to move the player.
    [SerializeField] GameObject Player;

    private const float MAX_SPEED_ANGLE = -20;
    private const float ZERO_SPEED_ANGLE = 210;

    [SerializeField] Transform needleTransform;

    private float speedMax;
    private float speed;

    private void Awake()
    {
        Player = GameObject.Find("Main Camera");

        speed = 0f;
        speedMax = 200f;
    }

    private void FixedUpdate()
    {
        speed += 2.24f * Time.deltaTime;
        if (speed > speedMax) speed = speedMax;

        needleTransform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());

        Player.GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private float GetSpeedRotation()
    {
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        float speedNormalized = speed / speedMax;

        return ZERO_SPEED_ANGLE - speedNormalized * totalAngleSize;
    }
}