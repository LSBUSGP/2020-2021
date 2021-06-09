using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textboxify : MonoBehaviour
{
    // THIS SCRIPT GOES ON THE TEXT OBJECT
    // MID LEFT AND RIGHT ARE THE THREE UI IMAGES THAT GO BEHIND THE TEXT
    // MARGIN IS THE EXTRA SPACE TO MAKE IT LOOK LESS CRAMPED

    // LEFT'S PIVOT'S X MUST = 1
    // RIGHT'S PIVOT'S X MUST = 0

    public RectTransform mid, left, right;

    public float margin = 5;

    Text text;
    RectTransform rectTransform;

    // all aspect ratios consider HEIGHT as 1
    float leftRatio, rightRatio;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        rectTransform = GetComponent<RectTransform>();

        leftRatio = left.rect.width / left.rect.height;
        print(leftRatio);

        rightRatio = right.rect.width / right.rect.height;
        print(rightRatio);
    }

    // Update is called once per frame
    void Update()
    {
        TextGenerator textGenerator = new TextGenerator();
        TextGenerationSettings textGenerationSettings = text.GetGenerationSettings(text.rectTransform.rect.size); 
        float w = textGenerator.GetPreferredWidth(text.text, textGenerationSettings);
        float h = textGenerator.GetPreferredHeight(text.text, textGenerationSettings);

        if(w > rectTransform.rect.width) w = rectTransform.rect.width;
        if(h > rectTransform.rect.height) h = rectTransform.rect.height;

        left.sizeDelta = new Vector2(h * leftRatio + margin*2, h + margin*2);
        right.sizeDelta = new Vector2(h * rightRatio + margin*2, h + margin*2);

        mid.sizeDelta = new Vector2(w - right.rect.width - left.rect.width + margin*2, h + margin*2);

        left.anchoredPosition = new Vector2(mid.anchoredPosition.x - mid.rect.width/2, mid.anchoredPosition.y);
        right.anchoredPosition = new Vector2(mid.anchoredPosition.x + mid.rect.width/2, mid.anchoredPosition.y);
    }
}
