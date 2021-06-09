using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextSpawner : MonoBehaviour
{

    public GameObject[] dialog;
    public GameObject[] npc;
    public float offset;

    private int index;
    private bool swapText;
    private Vector2 screenPos;

    private void Start()
    {
        swapText = false;
        Invoke("NewText", 5f);
    }
    // Update is called once per frame
    void Update()
    {
        if (!swapText)
        {
            NewText();
        }
        
    }


    void NewText()
    {
        swapText = true;
        Invoke("newSwap", 5f);
        foreach(GameObject speaker in npc)
        {
            index = Random.Range(0, dialog.Length);
            dialog[index].SetActive(true);
            screenPos = Camera.main.WorldToScreenPoint(speaker.transform.position);
            dialog[index].transform.position = new Vector2(screenPos.x, screenPos.y + offset);
            //Instantiate(dialog[index], new Vector2(speaker.transform.position.x,speaker.transform.position.y + offset), Quaternion.identity);
        }
    }
    void newSwap()
    {
        foreach (GameObject text in dialog)
        {
            text.SetActive(false);
        }
        swapText = false;
    }
}
