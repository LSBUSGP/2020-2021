February 23, 2021

10:00 AM - 18:00 PM
This brief is for my Layout group documentation.
There is another documentation for the non-layout group on a separate documentation.

The Unity manual suggests you can use a combination of layout group and content size fitter. When I first asked to create this script that method didn’t work.
Apparently it works now, but for the purposes of this brief, assume that it doesn’t work on your required problem and work out your own code solution.

You must create a custom script to calculate the size of the text box required, and then re-size the parent image to fit.


There are two scripts that I use for layout group but they both use almost the same coding except I had to rename GameObject while also using an IEnumerator for the text which is why they are both separate.
Also, another reason (Not necessarily important) why they are separate is because I needed to call the TMPro function for TextMeshPro, but it will still work regardless as one script if both scripts have `Using UnityEngine.UI` and `Using TMPro`.
For this documentation, I will be using the TMP or TextMeshPro script.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Need to call the TMP or TextMeshPro functions.
using TMPro;

`Using UnityEngine.UI` is for accessing the functions for basic Unity Text.
`Using TMPro` is for accessing the functions for TMP which is extremely important if you want to access the TMP's script.


[SerializeField] float WriteText = 3f;
[SerializeField] private GameObject basicText;
- I created a float variable of 3f with the name WriteText.
- I created a private GameObject and setting its name as basicText.


void Start()
    {
        AddComponent();
        basicText = GameObject.Find("Text (TMP)");
    }

`AddComponent();` is creating a separate void function. I mostly use this to stop overcrowding void Start() and void Update() and whichever.
`basicText = GameObject.Find("Text (TMP)"` is used to create a GameObject in the script.

GameObject's name = basicText
GameObject.Find("Text (TMP)") = Find this GameObject's name `Text (TMP)` within the Scene and implement it as the script's GameObject of reference.
- Meaning that you don't need to click and drag the GameObject from the Scene to the script. The script will auto-implement it for you as soon as the game starts which I really like doing a lot.



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

This is the void function that I created in void Start() that I didn't want to overcrowd the void Start() function.

`gameObject.AddComponent<HorizontalLayoutGroup>();`
`gameObject.AddComponent<ContentSizeFitter>();`
- gameObject.AddComponent is used to add a component to the gameObject. In this case, I am adding Horizontal Layout Group and Content Size Fitter into my gameObject (The basicText gameObject).


`gameObject.GetComponent<HorizontalLayoutGroup>().childScaleHeight = true;`
`gameObject.GetComponent<HorizontalLayoutGroup>().childScaleWidth = true;`
- gameObject.GetComponent is used to access a component from a gameObject.

The `<HorizontalLayoutGroup>().childScaleHeight = true;` is used to getting a component from the Horizontal Layout Group and accessing it.
- In this case, I am accessing the childScaleHeight component from the Horizontal Layout Group component in the Inspector tab and setting it to `true`, meaning I am enabling it. It is the same concept with childScaleWidth.


// Optimise the Content Size Fitter.
// https://forum.unity.com/threads/layout-group-and-contentsizefitter-in-child.343082/
gameObject.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;

// This is optional (Scaling the height of the Content Size Fitter to the text).
gameObject.GetComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
- This is the same concept as above, accessing a component from a component and changing it or enabling it.
- ContentSizeFitter.FitMode.PreferredSize auto scales the textbox along with the text. If the text is very small and the textbox is huge, the textbox will scale itself to fit with the text.
That is what the PreferredSize function is for the Content Size Fitter.



private void Update()
{
    TextScalingTest();
}

void TextScalingTest()
{
    StartCoroutine(WriteThisText());
}


    private IEnumerator WriteThisText()
    {
        while (true)
        {
            yield return new WaitForSeconds(WriteText);
            TMP_Text myText = basicText.GetComponent<TMP_Text>();
            myText.text = "Fate Grand Order";
        }
    }

I created another void function separately in void Update().


`StartCoroutine(WriteThisText());`
- I created a coroutine in this function. (https://docs.unity3d.com/ScriptReference/MonoBehaviour.StartCoroutine.html)
- (WriteThisText()) is just the name for the Coroutine.


private IEnumerator WriteThisText()
{
    while (true)
    {
        yield return new WaitForSeconds(WriteText);
        TMP_Text myText = basicText.GetComponent<TMP_Text>();
        myText.text = "Fate Grand Order";
    }
}

`yield return new WaitForSeconds(WriteText);`, I am using (WriteText) as the timer for how many seconds do I have to wait until it does this function. The timer for (WriteText is written around the top of this documentation, which is 3f).

`TMP_Text myText = basicText.GetComponent<TMP_Text>();`
- IMPORTANT NOTICE: TMP_Text can only be used for TMP only. This is not for basic Unity text. This is the reason why I had to separate both texts because I wanted to show that the auto-sizing works for this documentation.
- If I remove the IEnumerator and Coroutine, the script will work as one. This is proven in the Extra folder in the Scenes folder and in the Scripts folder. Please check the Scene in the Extra folder and the Script in the Extra folder if you are curious.

`myText.text = "Fate Grand Order";` is the text that will be written by the script into the game after (WriteText) timer has reached to 0.