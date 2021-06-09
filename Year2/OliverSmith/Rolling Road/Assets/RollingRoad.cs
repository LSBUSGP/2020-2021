using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingRoad : MonoBehaviour
{
    
    public int movespeed = 1; //Road speed of movement
    public Vector3 userDirection = Vector3.forward; // Direction road will move

    public GameObject[] road; // Array of road objects
    int randomInt; // Random Int to choose from array
    public Transform SpawnPos; // Spawn location to instantiate
    // Start is called before the first frame update
    void Start()
    {
        SpawnPos = GameObject.FindGameObjectWithTag("Spawn").transform; // Find spawn location
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(userDirection * movespeed * Time.deltaTime); // Move road towards camera
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Hit")
        {
            randomInt = Random.Range(0, road.Length); // Choose a random number from road
            Instantiate(road[randomInt], SpawnPos.position, SpawnPos.rotation); // Instantiate road prefab at spawn location

        }
        if(other.gameObject.tag == "Destroy")
        {
            Destroy(gameObject); // Destroy the object the script is on
        }
    }
}