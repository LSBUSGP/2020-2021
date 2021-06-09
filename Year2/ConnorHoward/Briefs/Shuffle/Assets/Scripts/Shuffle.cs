using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Shuffle : MonoBehaviour
{
    public List<string> availableTracks = new List<string>();
    public List<string> usedTracks = new List<string>();

    private bool cycleThroughList;
    private string chosenTrack;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        cycleThroughList = false;
    }

    // Update is called once per frame
    void Update()
    {
        //set the value to equal the length of the list
        count = availableTracks.Count;


        //Start the shuffle process
        if (cycleThroughList)
        {
            //repeat this process until all tracks in the list have been moved
            while (count > 0)
            {
                //chosen track = randomly chosen out of list
                chosenTrack = availableTracks[Random.Range(0, availableTracks.Count)];

                //remove from 1st list and add to 2nd
                usedTracks.Add(chosenTrack);
                availableTracks.Remove(chosenTrack);

                // Minus one from the count
                count--;
            }

            //cycle through the used track list and print them in the console
            foreach (string track in usedTracks)
            {
                print(track);
            }

            //disable the shuffle process
            cycleThroughList = false;
        }
    }

    public void ShuffleSongs()
    {
        //Clear the console window
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);



        //If there are tracks in the used tracks list, send them back and clear the list
        if (usedTracks.Count > 0)
        {
            availableTracks = new List<string>(usedTracks);
            foreach (string track in usedTracks.ToArray())
            {
                usedTracks.Remove(track);
            }
        }
        //turn on bool to start shuffle process
        cycleThroughList = true;

    }
}
