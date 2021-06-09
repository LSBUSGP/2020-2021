using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VelocityRecorder : MonoBehaviour
{
    public Text VelTextMPH;
    public Text VelTextKMPH;
    public float UpdateRate = 0.1f;

    private Rigidbody RB;
    private Vector3 PreviousPosition;
    private float VelocityMultiplier;
    private float CurrentMPH = 0;
    private float CurrentKMPH = 0;
    private float PreviousMPH = 0;

    // Start is called before the first frame update
    void Start()
    {
        VelocityMultiplier = 1 / UpdateRate;
        PreviousPosition = transform.position;
        RB = gameObject.GetComponent<Rigidbody>();
        Invoke("GetMPH", UpdateRate);
    }

    private void GetMPH()
    {
        
        float DistanceTraveledX = PreviousPosition.x - transform.position.x;
        float DistanceTraveledZ = PreviousPosition.z - transform.position.z;
        float DistanceTraveledY = PreviousPosition.y - transform.position.y;

        if(DistanceTraveledX < 0)
        {
            DistanceTraveledX *= -1;
        }

        if (DistanceTraveledY < 0)
        {
            DistanceTraveledY *= -1;
        }

        if (DistanceTraveledZ < 0)
        {
            DistanceTraveledZ *= -1;
        }


        if (DistanceTraveledX > DistanceTraveledZ && DistanceTraveledX > DistanceTraveledY && DistanceTraveledX > 0.01f)
        {
            CurrentMPH = DistanceTraveledX * 2.2369f * VelocityMultiplier;
            CurrentKMPH = DistanceTraveledX * 3.6f * VelocityMultiplier;
        }
        else if (DistanceTraveledZ > DistanceTraveledX && DistanceTraveledZ > DistanceTraveledY && DistanceTraveledZ > 0.01f)
        {
            CurrentMPH = DistanceTraveledZ * 2.2369f * VelocityMultiplier;
            CurrentKMPH = DistanceTraveledZ * 3.6f * VelocityMultiplier;
        }
        else if(DistanceTraveledY > 0.01f)
        {
            CurrentMPH = DistanceTraveledY * 2.2369f * VelocityMultiplier;
            CurrentKMPH = DistanceTraveledY * 3.6f * VelocityMultiplier;
        }
        else
        {
            CurrentMPH = 0;
            CurrentKMPH = 0;
        }

        if (CurrentMPH != PreviousMPH)
        {
            UpdateUI();
        }

        PreviousMPH = CurrentMPH;
        CurrentMPH = 0;
        PreviousPosition = transform.position;

        Invoke("GetMPH", UpdateRate);

    }

    private void UpdateUI()
    {

        VelTextMPH.text = CurrentMPH.ToString();
        VelTextKMPH.text = CurrentKMPH.ToString();

    }
}
