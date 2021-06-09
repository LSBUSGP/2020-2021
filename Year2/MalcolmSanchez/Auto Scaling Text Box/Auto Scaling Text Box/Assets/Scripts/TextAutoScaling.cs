using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAutoScaling : MonoBehaviour
{
    private RectTransform m_rectTransform;

    void Awake()
    {
        m_rectTransform = gameObject.GetComponent<RectTransform>();
        
    }


    // Test the script that I found.
    IEnumerator Start()
    {
        // Minimum Width of the text.
        float widthMin = 250f;
        // Maximum width of the text.
        float widthMax = 500f;
        // Implement the width to calculate between max and min width.
        float width = widthMin;
        // Movement speed of the text.
        float delta = 0.3f;

        while (true)
        {
            if (width > widthMax) delta = -delta;
            if (width < widthMin) delta = -delta;

            width += delta;

            m_rectTransform.sizeDelta = new Vector2(width, 100f);

            yield return null;
        }
    }

    // https://www.youtube.com/watch?v=h1Z2jcB4aaQ This is the video I used for this brief.
}
