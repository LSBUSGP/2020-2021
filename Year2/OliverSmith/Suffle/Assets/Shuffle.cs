using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuffle : MonoBehaviour
{
    public AudioSource CurrentSong;
    public AudioClip LastSong;

    public AudioClip[] audioSources;

    // Use this for initialization
    private void Awake()
    {
        CurrentSong = GetComponent<AudioSource>();
    }
  
    public void OnMouseDown()
    {
        while (CurrentSong.clip == LastSong)
        {
            CurrentSong.clip = audioSources[Random.Range(0, audioSources.Length)];
        }
        LastSong = CurrentSong.clip;
        CurrentSong.Stop();
        CurrentSong.PlayOneShot(CurrentSong.clip);

    }

    


   

}
