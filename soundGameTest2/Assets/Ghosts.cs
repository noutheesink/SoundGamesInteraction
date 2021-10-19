using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghosts : MonoBehaviour
{
    public List<GameObject> ghostList;
    public GhostType ghostTypes;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum GhostType
{
    Low = 0,
    Mid = 20,
    High = 40
}