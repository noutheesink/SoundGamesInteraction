using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSpectrumData : MonoBehaviour
{
    public float[] spectrumData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        for (int i = 0; i < spectrumData.Length; i++)
        {
            spectrumData[i] = spectrumData[i] < 10 ? 0 : spectrumData[i];
        }
    }
}
