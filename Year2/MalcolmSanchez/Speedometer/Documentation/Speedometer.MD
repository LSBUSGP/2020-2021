May 21, 2021

09:05 AM
This brief is for the Speedometer.

A script is required to measure the current speed of an object through Unity world space.
The script must take the speed from the standard Unity Rigidbody component.
The result needs to be converted from the standard Unity scale of meters per second into miles per hour.

I have used two different scripts, one which teleports the player back to its original position when the player reaches the border limit of the scene.
The other script is the Speedometer itself.
It will determine how fast the player is going.


---------------------------------------------------------------------------------------------------------------------------------------------------------------
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
---------------------------------------------------------------------------------------------------------------------------------------------------------------

This is the script that I used for the Speedometer.



------------------Player------------------
This script will only cover about the player's script, excluding the one from the needle.
I had to first get the player to move using the Rigidbody as part of my specialism.

    // Reference the player to move the player.
    [SerializeField] GameObject Player;

I created a GameObject variable so that I can reference the player's GameObject in order to access its Rigidbody component.


I then created a float variable for the speed of the player and the maximum speed that a player can achieve.

    private float speedMax;
    private float speed;

    private void Awake()
    {
        Player = GameObject.Find("Main Camera");

        speed = 0f;
        speedMax = 200f;
    }

I used this script to simulate the speed limit of how fast a player can go while starting from the speed of 0.

Starting speed is set to 0f.
Max speed is set to 200f.

For this brief, I used the Main Camera as the "player" itself.
I used `Player = GameObject.Find("Main Camera");` to automatically set the player's GameObject in the script without having to click and drag it.


I specifically used the FixedUpdate method for the player's speed, which is useful for physics.
private void FixedUpdate()
    {
        speed += 2.24f * Time.deltaTime;
        if (speed > speedMax) speed = speedMax;

        Player.GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

I used:
`speed += 2.24f * Time.deltaTime;`

What this means is that the player's speed will increase by 2.24f each second due to the constant speed of Time.deltaTime.

I have researched the basic measurement speed of Unity and it is stated that the standard speed for Unity is "Meters per Second".
So I have researched the speed for MPH (Miles Per Hour) based on Meters.

1 Meter = 2.24 Mph

However, this is rounded by the nearest thousandths.
The original 1 Meter is equivalent to 2.23694 mph.

I limited the speed of the player by using:
`if (speed > speedMax) speed = speedMax;`

Basically, what this means is that if the speed is greater than the max speed, then the speed will equal to max speed.

For the last part of the player's script, I had to make the player move.
`Player.GetComponent<Rigidbody>().velocity = transform.forward * speed;`

Since we already know that the player is the Main Camera as stated in line 96.
I then used the Player's GameObject to get the Rigidbody component and add a velocity to it.
The velocity is used commonly to set a movement for a GameObject.

What velocity really is, is the vector of the rigidbody and it represents the rate of change of Rigidbody position.
https://docs.unity3d.com/ScriptReference/Rigidbody-velocity.html

I set the velocity to `transform.forward * speed`.
Because we want to make the Player move forward for this brief.
It is then multiplied by the speed which is 2.24f (2.24 mph).



------------------Speedometer------------------
For this part, I will be covering the Speedometer's script.
I created a speedometer to calculate the speed of the player, but not exactly a good speedometer.
I did not include the text UI for the Speedometer as it caused a bug when I wrote a coding for it.


If you have already noticed my script, it does not contain:
`needleTransform = transform.Find("needle");`

The reason why I have not used that coding the same way I did with my player:
`Player = GameObject.Find("Main Camera");`

It is because the coding seems to not work when I used it (I mainly use [SerializeField] to check it in the inspector tab).
So I used the old method of clicking and dragging the needle's GameObject into the script.


I had to create a variable for the needle, because the needle needs to rotate.
Just like in cars, there is always a Speedometer needle to indicate the speed of how fast you are going.

    private const float MAX_SPEED_ANGLE = -20;
    private const float ZERO_SPEED_ANGLE = 210;

    [SerializeField] Transform needleTransform;

I set the MAX_SPEED_ANGLE and ZERO_SPEED_ANGLE for the needle's rotation.


In the `private void FixedUpdate()`
I created a new Vector3 for the needle's rotation.
`needleTransform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());`

I wanted the needle to rotate only in the "Z axis", so I set the Vector3 to "Vector3(0, 0, GetSpeedRotation());"


The last part for the Speedometer is the movement of the needle itself.
    private float GetSpeedRotation()
    {
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        float speedNormalized = speed / speedMax;

        return ZERO_SPEED_ANGLE - speedNormalized * totalAngleSize;
    }

I wanted to calculate the total Angle size, which is why I created a `float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;`

As for the `float speedNormalized = speed / speedMax;`
This is used to normalize the speed of the needle.
If the needle's speed is at max speed, we want it to be at the maximum while if the needle's speed is at 0 then we want it to be at 0.

In Unity, the Angles go counter-clockwise so I had to write it in a way that the needle will go clockwise.
`return ZERO_SPEED_ANGLE - speedNormalized * totalAngleSize;`



---------------------------------------------------------------------------------------------------------------------------------------------------------------
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
---------------------------------------------------------------------------------------------------------------------------------------------------------------

As for this script, this is teleporting the player back to its original position.
I will not cover this as this documentation is only for the Speedometer.