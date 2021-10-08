using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private Gyroscope m_Gyro;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion gyroAttitude = m_Gyro.attitude * Quaternion.Euler(90,0,0);
        
        Debug.DrawRay(Vector3.zero, transform.forward * 90, Color.green);
        
        Quaternion gyroAttitudeTranslation = new Quaternion(gyroAttitude.x, 0, gyroAttitude.y,0);

        transform.rotation = gyroAttitudeTranslation;
    }
    
    
}
