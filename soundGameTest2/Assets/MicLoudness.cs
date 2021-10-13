using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicLoudness : MonoBehaviour
{
    public float micLoudness;
	public float killSensitivity;
	
    void Start()
    {
        killSensitivity = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (micLoudness > killSensitivity) {
        	Debug.Log("kill ghost");
        }
    }
}
