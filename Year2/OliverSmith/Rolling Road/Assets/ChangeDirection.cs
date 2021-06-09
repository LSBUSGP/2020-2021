using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : MonoBehaviour
{
    public bool TurnLeft;
    public bool TurnRight;
    public GameObject[] TurnleftObject;
    public GameObject LeftTurn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //TurnleftObject = GameObject.FindGameObjectsWithTag("TurnLeft");

        if(TurnLeft == true)
        {
            //foreach (GameObject L in TurnleftObject)
            LeftTurn.transform.Rotate(new Vector3(0, -90, 0));
            Debug.Log("Turnleft");
            //foreach (GameObject L in TurnleftObject)
            //L.transform.position = new Vector3(-10.44f, 0, -12.5f);
            TurnLeft = false;

        }
        else if (TurnRight == true)
        {
            
            transform.Rotate(new Vector3(0, 90, 0));
            TurnRight = false;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LeftTurn")
        {
            other.transform.Rotate(new Vector3(0, -90, 0));
        }
        else if (other.tag == "RightTurn")
        {
            TurnRight = true;
        }
    }


    
}