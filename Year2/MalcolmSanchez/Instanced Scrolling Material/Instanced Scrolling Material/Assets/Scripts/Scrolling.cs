using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float Speed = 5f;
    bool upScroll = true;
    bool downScroll = false;

    void Update()
    {
        UpwardScroll();
        DownwardScroll();
    }

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
}
