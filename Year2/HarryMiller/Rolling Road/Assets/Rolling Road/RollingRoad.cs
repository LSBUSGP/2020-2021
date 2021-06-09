using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingRoad : MonoBehaviour
{
    public GameObject roadPiece;
    public float speed;

    public List<GameObject> roadPieces;

    float roadLength;
    float distanceTraveled = 0;

    // Start is called before the first frame update
    void Start()
    {
        roadLength = roadPiece.transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        float s = speed * Time.deltaTime;
        distanceTraveled += s;

        foreach(GameObject g in roadPieces)
        {
            g.transform.position -= new Vector3(0,0,s);
        }

        if(distanceTraveled >= roadLength)
        {
            distanceTraveled = 0;
            roadPieces.Add(Instantiate(roadPiece, roadPieces[roadPieces.Count-1].transform.position + new Vector3(0,0,roadLength), Quaternion.identity));

            GameObject t = roadPieces[0];
            roadPieces.Remove(roadPieces[0]);
            Destroy(t);
        }
    }
}
