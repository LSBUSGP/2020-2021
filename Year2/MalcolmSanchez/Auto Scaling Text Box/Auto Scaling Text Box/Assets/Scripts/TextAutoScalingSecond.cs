using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAutoScalingSecond : MonoBehaviour
{

    // https://forum.unity.com/threads/textmeshpro-precull-dorebuilds-performance.762968/#post-5083490
    // Another scale to text box script that I found.
    // This script is NOT used in Unity, please ignore this script as I added and kept this as an extra script.
    public TMP_Text[] TextObjects;

    private void Awake()
    {

        if (TextObjects == null || TextObjects.Length == 0)
            return;

        // Iterate over each of the text objects in the array to find a good test candidate
        // There are different ways to figure out the best candidate
        // Preferred width works fine for single line text objects
        int candidateIndex = 0;
        float maxPreferredWidth = 0;

        for (int i = 0; i < TextObjects.Length; i++)
        {
            float preferredWidth = TextObjects[i].preferredWidth;
            if (preferredWidth > maxPreferredWidth)
            {
                maxPreferredWidth = preferredWidth;
                candidateIndex = i;
            }
        }

        // Force an update of the candidate text object so we can retrieve its optimum point size.
        TextObjects[candidateIndex].enableAutoSizing = true;
        TextObjects[candidateIndex].ForceMeshUpdate();
        float optimumPointSize = TextObjects[candidateIndex].fontSize;

        // Disable auto size on our test candidate
        TextObjects[candidateIndex].enableAutoSizing = false;

        // Iterate over all other text objects to set the point size
        for (int i = 0; i < TextObjects.Length; i++)
            TextObjects[i].fontSize = optimumPointSize;
    }
}