
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsCounter : MonoBehaviour
{
   
    private int framesCounted = 0;
    float timeCounter = 0.0f;
    private float refreshTimer = 0.1f;
    public Text framerateText;
    public float Framerate2;
  
    void Update()
    {
        if(timeCounter < refreshTimer)
        {
            timeCounter += Time.deltaTime;
            framesCounted += 1;
        }
        else
        {
            float Framerate = framesCounted / timeCounter;
            // Divide how many frames via the timecounter
            framesCounted = 0;
            timeCounter = 0.0f;
            // Set both frame counter and time counter back to 0
            Framerate2 = Mathf.Round(Framerate * 100.0f) * 0.01f;
            // Round to 2 decimal points for better display on UI
            framerateText.text = ("Framerate" + Framerate2);
            //Display this on a ui text - 
        }
    }
}
