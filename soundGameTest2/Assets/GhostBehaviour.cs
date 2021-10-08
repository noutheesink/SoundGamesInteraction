using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using Random = UnityEngine.Random;

public class GhostBehaviour : MonoBehaviour
{
    public List<GameObject> ghostList;
    
    public float speed = 1;

    [SerializeField] AudioClip[] audioClips;

    [SerializeReference] private float Angle;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = audioClips[Random.Range(0, audioClips.Length)];
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        Angle = Vector3.Angle(Vector3.forward, new Vector3(transform.position.x,0,transform.position.z));
        
        transform.position -= transform.position.normalized * (Time.deltaTime * speed);
    }

    private void OnDestroy()
    {
        ghostList.Remove(gameObject);
    }
}
