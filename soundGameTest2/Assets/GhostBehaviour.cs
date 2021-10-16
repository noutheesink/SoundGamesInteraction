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
    public List<GameObject> ghostList;
    
    public float speed = 1;

    [SerializeField] AudioClip[] audioClips;
    public AudioSource singingSource;
    public AudioSource dyingSource;

    private bool isDyingBool;
    
    [SerializeReference] private float Angle;

    public bool detected;
    public GameObject micInput;
    private MicLoudness MicLoudness;
    
    // Start is called before the first frame update
    void Start()
    {
        MicLoudness = micInput.GetComponent<MicLoudness>();
        singingSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        singingSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Angle = Vector3.Angle(new Vector3(transform.position.x, 0, transform.position.z), Vector3.forward);
        Angle = transform.position.x < 0 ? 360 - Angle : Angle;
        transform.position -= transform.position.normalized * (Time.deltaTime * speed);
        
        if (!isDyingBool) CheckForDeath();
    }

    private void CheckForDeath()
    {
        if (detected && MicLoudness.micLoudness > MicLoudness.killSensitivity)
        {
            isDyingBool = true;
            StartDestroy();
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
