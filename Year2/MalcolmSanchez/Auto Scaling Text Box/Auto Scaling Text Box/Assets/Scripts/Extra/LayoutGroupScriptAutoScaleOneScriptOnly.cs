using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Need to call the TMP or TextMeshPro functions.
using TMPro;

public class LayoutGroupScriptAutoScaleOneScriptOnly : MonoBehaviour
{
    [SerializeField] float WriteText = 3f;
    [SerializeField] private GameObject basicText;
    [SerializeField] private GameObject TMPText;

    void Start()
    {
        AddComponent();
        basicText = GameObject.Find("mybasicText");
        TMPText = GameObject.Find("Text (TMP)");
    }

    void AddComponent()
    {
        gameObject.AddComponent<HorizontalLayoutGroup>();
        gameObject.AddComponent<ContentSizeFitter>();

        // Optimise the Horizontal Layout Group.
        gameObject.GetComponent<HorizontalLayoutGroup>().childScaleHeight = true;
        gameObject.GetComponent<HorizontalLayoutGroup>().childScaleWidth = true;


        // Optimise the Content Size Fitter.
        // https://forum.unity.com/threads/layout-group-and-contentsizefitter-in-child.343082/
        gameObject.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;

        // This is optional (Scaling the height of the Content Size Fitter to the text).
        gameObject.GetComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
    }
}
