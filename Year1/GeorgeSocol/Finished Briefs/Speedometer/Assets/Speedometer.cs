using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    private const float max_speed_angle = -120;
    private const float min_speed_angle = 120;

    private Transform needleTransform;
    private Transform speedLabelTemplateTransform;

    private float speedMax;
    private float speed;
    private float speedMin;

    private void Awake()
    {
        needleTransform = transform.Find("needle");
        speedLabelTemplateTransform = transform.Find("speedLabelTemplate");
        speedLabelTemplateTransform.gameObject.SetActive(false);

        speed = 0f;
        speedMax = 200f;
        speedMin = 0f;

        CreateSpeedLabels();
    }

    private void Update()
    {
        HandlePlayerInput();
   
        if (speed > speedMax) speed = speedMax;
        if (speed < speedMin) speed = speedMin;

        needleTransform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());
    }

    private void HandlePlayerInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            float acceleration = 50f;
            speed += acceleration * Time.deltaTime;
        }
        else
        {
            float deceleration = 20f;
            speed -= deceleration * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            float brakeSpeed = 100f;
            speed -= brakeSpeed * Time.deltaTime;
        }
    }

    private void CreateSpeedLabels()
    {
        int labelAmount = 10;
        float totalAngleSize = min_speed_angle - max_speed_angle;

        for (int i = 0; i <= labelAmount; i++)
        {
            Transform speedLabelTransform = Instantiate(speedLabelTemplateTransform, transform);
            float labelSpeedNormalized = (float)i / labelAmount;
            float speedLabelAngle = min_speed_angle - labelSpeedNormalized * totalAngleSize;
            speedLabelTransform.eulerAngles = new Vector3(0, 0, speedLabelAngle);
            speedLabelTransform.Find("speedText").GetComponent<Text>().text = Mathf.RoundToInt(labelSpeedNormalized * speedMax).ToString();
            speedLabelTransform.Find("speedText").eulerAngles = Vector3.zero;
            speedLabelTransform.gameObject.SetActive(true);

        }
        needleTransform.SetAsLastSibling();
    }

    private float GetSpeedRotation()
    {
        float totalAngleSize = min_speed_angle - max_speed_angle;
        float speedNormalized = speed / speedMax;

        return min_speed_angle - speedNormalized * totalAngleSize;
    }
}
