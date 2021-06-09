using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resize : MonoBehaviour
{
    float width;
    SizeCalculator SC;
    public Image image;
    void Start()
    {
        SC = GameObject.FindObjectOfType<SizeCalculator>();
    }

    // Update is called once per frame
    void Update()
    {
        width = SC.TextWidth;
        RectTransform rt = image.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector3(width, 40);
    }
}
