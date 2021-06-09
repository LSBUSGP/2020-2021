using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AutoScaling : MonoBehaviour
{
    public RectTransform left, middle, right;
    public float height, width;
    private Text text;
    private RectTransform rect;
    //TextGenerator textGen = new TextGenerator();
   
    // Start is called before the first frame update
    void Start()
    {

        text = GetComponent<Text>();
        rect = GetComponent<RectTransform>();
        width = rect.sizeDelta.x;
        height = rect.sizeDelta.y;

    }

    // Update is called once per frame
    void Update()
    {
        rect.sizeDelta = new Vector2(text.preferredWidth, text.preferredHeight);
        width = rect.sizeDelta.x;
        height = rect.sizeDelta.y;
        middle.sizeDelta = new Vector2(width, height);
        left.sizeDelta = new Vector2(left.sizeDelta.x, height);
        right.sizeDelta = new Vector2(right.sizeDelta.x, height);
        middle.localPosition = new Vector2(rect.localPosition.x, rect.localPosition.y);
        left.localPosition = new Vector2(middle.localPosition.x - width /2, middle.localPosition.y);
        right.localPosition = new Vector2(middle.localPosition.x + width / 2, middle.localPosition.y);
    }
}
