using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    [Range(0f,10f)]
    public float scrollSpeed = 0.5f;
    [Range(-1, 1)]
    public int scrollDirection = 1;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = scrollSpeed * Time.time * scrollDirection;
        rend.material.mainTextureOffset = new Vector2(0, offset);
    }
}
