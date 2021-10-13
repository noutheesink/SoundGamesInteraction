using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mic : MonoBehaviour
{
    public AudioClip audioClip;
    public bool useMic = true;
    public string selectedMic;
    public AudioSource audioSource;

    void Start()
    {

    	if(useMic) {

    		if(Microphone.devices.Length > 0) {
    			Debug.Log("er is een mic");
    			selectedMic = Microphone.devices[0].ToString();
    			audioClip = Microphone.Start(selectedMic, true, 10, AudioSettings.outputSampleRate);
    			audioSource.clip = Microphone.Start(selectedMic, true, 10, AudioSettings.outputSampleRate);
    		} else {
    			useMic = false;
    		}
    	}
        
    }

    void Update()
    {
        
    }
}
