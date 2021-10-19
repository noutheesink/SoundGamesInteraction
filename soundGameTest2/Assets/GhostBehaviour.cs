using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml;
using UnityEditor.UIElements;
using UnityEngine;
using Random = UnityEngine.Random;

public class GhostBehaviour : MonoBehaviour
{
    public bool destroy;
    public Enum ghostType = GhostType.Mid;
    public List<GameObject> ghostList;
    
    public float speed = 1;

    [SerializeField] AudioClip[] audioClips;
    public AudioSource singingSource;
    public AudioSource dyingSource;

    private bool isDyingBool;
    
    [SerializeReference] private float Angle;

    public bool detected;
    public GameObject micInput;
    private InputSpectrumData inputSpectrumData;
    public float killSensitivity = 7;
    
    // Start is called before the first frame update
    void Start()
    {
        inputSpectrumData = micInput.GetComponent<InputSpectrumData>();
        switch (ghostType)
        {
            case GhostType.Low:
                singingSource.clip = audioClips[0];
                break;
            case GhostType.Mid:
                singingSource.clip = audioClips[1];
                break;
            case GhostType.High:
                singingSource.clip = audioClips[2];
                break;
        }
        
        singingSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Angle = Vector3.Angle(new Vector3(transform.position.x, 0, transform.position.z), Vector3.forward);
        Angle = transform.position.x < 0 ? 360 - Angle : Angle;
        transform.position -= transform.position.normalized * (Time.deltaTime * speed);
        
        if (!isDyingBool) CheckForDeath();
        
        if (destroy) Destroy(gameObject);
    }

    private void CheckForDeath()
    {
        if (detected)
        {
            switch (ghostType)
            {
                case GhostType.Low:
                    for (int i = (int) GhostType.Low; i < (int) GhostType.Mid; i++)
                    {
                        if (inputSpectrumData.spectrumData[i] > killSensitivity)
                        {
                            isDyingBool = true;
                            StartDestroy();
                            break;
                        }
                    }
                    break;
                case GhostType.Mid:
                    for (int i = (int) GhostType.Mid; i < (int) GhostType.High; i++)
                    {
                        if (inputSpectrumData.spectrumData[i] > killSensitivity)
                        {
                            isDyingBool = true;
                            StartDestroy();
                            break;
                        }
                    }
                    break;
                case GhostType.High:
                    for (int i = (int) GhostType.High; i < inputSpectrumData.spectrumData.Length; i++)
                    {
                        if (inputSpectrumData.spectrumData[i] > killSensitivity)
                        {
                            isDyingBool = true;
                            StartDestroy();
                            break;
                        }
                    }
                    break;
            }
        }
    }

    private void StartDestroy()
    {
        singingSource.Stop();
        dyingSource.Play();
        speed *= -1;
        StartCoroutine(isDying());
    }

    IEnumerator isDying()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        ghostList.Remove(gameObject);
    }
}