February 23, 2021

10:00 AM - 18:00 PM
This brief is for my Non-Layout group documentation.
There is another documentation for the layout group on a separate documentation.

The Unity manual suggests you can use a combination of layout group and content size fitter. When I first asked to create this script that method didn’t work.
Apparently it works now, but for the purposes of this brief, assume that it doesn’t work on your required problem and work out your own code solution.

You must create a custom script to calculate the size of the text box required, and then re-size the parent image to fit.



I will break it down one by one.

private RectTransform m_rectTransform;

    void Awake()
    {
        m_rectTransform = gameObject.GetComponent<RectTransform>();
        
    }

What this does is allow me to gain access to the RectTransform component in the Inspector of the Text gameObject.


// Test the script that I found.
    IEnumerator Start()
    {
        // Minimum Width of the text.
        float widthMin = 300f;
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

The IENumerator script is already commented but the while (true) isn't.
`if (width > widthMax) delta = -delta` is about if the width of the text is greater than the widthMax, then the text will decrease in size.
`if (width < widthMin) delta = -delta` is about if the width of the text is smaller than the widthMin, then the text will increase in size.
`float delta = 0.3f` is the speed of the movement speed of the text as stated above.

`If it's 0.3 then delta = -delta will make it -0.3`
width += delta is where the width is constantly adding its size based on the delta (0.3f).
Meaning if the width is 300f, then it will slowly do +0.3f each second.

`m_rectTransform.sizeDelta = new Vector2(width, 100f);` is referencing and accessing the RectTransform component's size (Width, Height).


`The size of this RectTransform relative to the distances between the anchors.`
`If the anchors are together, sizeDelta is the same as size. If the anchors are in each of the four corners of the parent, the sizeDelta is how much bigger or smaller the rectangle is compared to its parent.`
https://docs.unity3d.com/ScriptReference/RectTransform-sizeDelta.html




// https://www.youtube.com/watch?v=h1Z2jcB4aaQ This is the video I used for this brief.
I have used this YouTube video as a guide to help me with the auto text generator.