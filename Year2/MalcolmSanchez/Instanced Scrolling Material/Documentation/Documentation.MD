February 16, 2021

10:00 - 10:30 AM
This documentation is about the Instanced Scrolling Material brief.

A script is required to scroll a tile-able texture to give the appearance of liquid flowing.
The speed and direction of the scrolling must be parameters and the speed must be independent of the frame rate.
(Hint: use Time.deltaTime to keep the speed consistent and independent of the frame rate.)

Refer to the script for more details about the full script.


// Speed of the scrolling, attached to the main camera.
public float Speed = 5f;


// Created two Booleans, these booleans will determine when will the scrolling of the camera change direction once it is set to true.
bool upScroll = true;
bool downScroll = false;


// I created two separate variables so that the void Update() doesn't get overcrowded.
void Update()
    {
        UpwardScroll();
        DownwardScroll();
    }


// I created a trigger point using colliders so that when the camera's collider hits any of these two colliders, it will change the direction of the scrolling.
// if(col.gameObject.tag == "UpperBorder" && upScroll) is used to determine if the camera is scrolling upwards and if the collider hits the UpperBorder.
// Once the conditions are met (Camera hits upper border + camera is moving upwards), it will initiate the following code.
// The Debug.Log is there to determine if the collision trigger is working.
// upScroll will be set to false and downScroll will be set to true.

// if(col.gameObject.tag == "BottomBorder" && downScroll) is the same method as Line 26 except the opposite.

void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "UpperBorder" && upScroll)
        {
            Debug.Log("Down");
            // Teleport the camera back to where it originated from.
            // this.transform.position = new Vector3(-344, -924, -10);

            // Initiate downward scrolling.
            upScroll = false;
            downScroll = true;
        }

        if(col.gameObject.tag == "BottomBorder" && downScroll)
        {
            Debug.Log("Up");
            // Initiate upward scrolling.
            upScroll = true;
            downScroll = false;
        }
    }


    // This script is being called by void Update() at line 23.
    // if (upScroll == true) is a statement if the upScroll is equals to true or is true then it will initiate the following code.
    // transform.Translate(Vector3.up * Speed * Time.deltaTime); is the initialisation.
    // The camera will scroll upwards or move upwards due to Vector3.up multiplied by the speed and Time.deltaTime.


    // The DownwardScroll() is the same method, but the opposite of UpwardScroll().

void UpwardScroll()
    {
        if (upScroll == true)
        {
            // Scroll the camera upwards.
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }
    }

void DownwardScroll()
{
    if (downScroll == true)
    {
        // Scroll the camera downwards.
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }
}