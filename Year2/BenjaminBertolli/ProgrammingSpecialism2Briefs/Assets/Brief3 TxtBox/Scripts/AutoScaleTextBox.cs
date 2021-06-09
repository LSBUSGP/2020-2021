using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AutoScaleTextBox : MonoBehaviour
{
    public float SizeScalePerLetter = 1;
    public float SizeScalePerLine = 1;
    public float WordsUntilLineChange = 20;
    public RectTransform Art;

    private int LetterCount = 0;
    private Text TextObject;
    private TextMeshPro TextObjectPro;
    private Vector2 ScalePerLetter;
    private int StoredXGrowth = 1;

    private void Start()
    {
        TextObject = gameObject.GetComponent<Text>();
        TextObjectPro = gameObject.GetComponent<TextMeshPro>();

        LetterCount = TextObject.text.Length;
        int temp_LetterCount;

        if(LetterCount == 0)
        {
            temp_LetterCount = 1;
        }
        else
        {
            temp_LetterCount = LetterCount;
        }

        if (TextObject != null)
        {
            ScalePerLetter = new Vector2(TextObject.rectTransform.sizeDelta[0] / temp_LetterCount, TextObject.rectTransform.sizeDelta[1] / temp_LetterCount);
        }
        else
        {
            ScalePerLetter = new Vector2(TextObjectPro.rectTransform.sizeDelta[0] / temp_LetterCount, TextObjectPro.rectTransform.sizeDelta[1] / temp_LetterCount);
        }
    }

    private void Update()
    {
        if (TextObject != null)
        {
            if (LetterCount != TextObject.text.Length)
            {
                RunUpdateSize();
            }
        }
        else
        {
            if (LetterCount != TextObjectPro.text.Length)
            {
                RunUpdateSize();
            }
        }

        if(LetterCount != TextObject.text.Length)
        {
            if (TextObject != null)
            {
                UpdateSize();
            }else if(TextObjectPro != null)
            {
                UpdateSizeTMPro();
            }
        }
    }

    private void RunUpdateSize()
    {

        if (TextObject != null)
        {
            UpdateSize();
        }
        else if (TextObjectPro != null)
        {
            UpdateSizeTMPro();
        }

    }
    private void UpdateSize()
    {
        LetterCount = TextObject.text.Length;
        int[] temp_size = CalculateLetters();

        TextObject.rectTransform.sizeDelta = new Vector2(temp_size[0], temp_size[1] * ScalePerLetter[1] * SizeScalePerLine);
        Art.sizeDelta = TextObject.rectTransform.sizeDelta;
    }
    private void UpdateSizeTMPro()
    {
        LetterCount = TextObjectPro.text.Length;
        int[] temp_size = CalculateLetters();

        TextObjectPro.rectTransform.sizeDelta = new Vector2(temp_size[0], temp_size[1] * ScalePerLetter[1] * SizeScalePerLine);
        Art.sizeDelta = TextObjectPro.rectTransform.sizeDelta;
    }

    private int[] CalculateLetters()
    {
        int temp_Y_growth = (int)(LetterCount / WordsUntilLineChange) + 1;
        int temp_X_Growth = StoredXGrowth;

        if (temp_Y_growth == 1)
        {
            temp_X_Growth = (int)(SizeScalePerLetter * LetterCount * ScalePerLetter[0]);
            StoredXGrowth = temp_X_Growth;
        }

        int[] temp_size = new int[] { temp_X_Growth, temp_Y_growth };
        return temp_size;
    }
}
