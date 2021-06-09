using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    int frames = 0;
    float timePassed = 0;

    public Text fpsText;
    
    void Update()
    {
        frames++;
        timePassed += Time.deltaTime;

        if(timePassed >= 1)
        {
            fpsText.text = "FPS: " + frames;

            frames = 0;
            timePassed = 0;
        }
    }
}
