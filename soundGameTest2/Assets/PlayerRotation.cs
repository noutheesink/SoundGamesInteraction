using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private Gyroscope m_Gyro;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0 && (Input.touchCount > 0 || Input.GetMouseButton(0))) Time.timeScale = 1;
        else
        {

            Quaternion gyroAttitude = m_Gyro.attitude * Quaternion.Euler(90, 0, 0);

            Debug.DrawRay(Vector3.zero, transform.forward * 90, Color.green);

            Quaternion gyroAttitudeTranslation = new Quaternion(gyroAttitude.x, 0, gyroAttitude.y, 0);

            transform.rotation = gyroAttitudeTranslation;
        }
    }
    
    
}
