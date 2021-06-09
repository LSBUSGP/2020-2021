May 24, 2021

21:01 PM
This documentation is about the Rolling Road brief.

A system is required for building an infinite road in an endless runner style of game.
As the current end of the road is about to enter the camera’s viewport, the system should spawn in a new section of road.
Sections behind the camera’s viewport should be removed.
The camera should remain stationary and the road should move towards it to give the appearance of motion.
The speeds and distances should customisable through the inspector.

I haven't fully completed the brief as the coding for the Endless Runner seems to be complicated when it comes to instantiating prefabs.
The issue I had with the coding is the fact that the platform keeps instantiating higher and higher at a certain distance which became complicated for me to fix considering the time I have left.

The code I used for destroying the platforms behind the camera's viewpoint is through using a new gameobject and a collider along with it:

--------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    [SerializeField] GameObject platform;

    private void Update()
    {
        platform = GameObject.FindGameObjectWithTag("Platform");
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Platform")
        {
            Destroy(platform);
        }
    }
}
--------------------------------------------------------------------------------------------

I used the Update method to find the instantiated prefab with the tag of "Platform".
This allows the collider to destroy any platform including instantiated platforms.

There was a major bug when I tried making the platform move instead of the camera and collider behind it.
The instantiated platforms could pass through the box collider without being destroyed which caused me to revert back to using the camera and collider moving instead.



As for the Endless Runner generator, the coding I used is:
--------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 50f;

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private Player player;

    private Vector3 lastEndPosition;

    private void Awake()
    {

        lastEndPosition = levelPart_Start.Find("EndPosition").position;

        int startingSpawnLevelParts = 5;
        for(int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    private void Update()
    {
        if(Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
         {
             SpawnLevelPart();
         }
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
--------------------------------------------------------------------------------------------

I created a prefab for each multiple platforms to instantiate.
I then created this script to have a "List" which allows me to add those prefabs that I created to be instantiated.

I also created an "EndPosition" which is the end point of each prefab/platform.
Having this "EndPosition" will allow me to instantiate prefabs after it.
I have created a Random.Range to select between the prefabs to instantiate randomly.

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }


I had to use the Player Distance as a means to instantiate the prefab each time the player moves.
 private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 50f;

 I then used the void Update so that it will consistently spawn the prefabs once the player reaches a certain distance.

    private void Update()
    if(Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
         {
             SpawnLevelPart();
         }


In order for me to be able to instantiate the prefabs:
 private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }

What this coding does is allow me to instantiate the prefabs within the list.
 [SerializeField] private List<Transform> levelPartList;

