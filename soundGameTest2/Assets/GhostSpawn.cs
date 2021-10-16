using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GhostSpawn : MonoBehaviour
{
    [SerializeField] private GameObject ghostGameObject;

    public float waitTime = 2f;
    private float timeSinceLastGhost = 0;

    public GameObject MicInput;
    
    public float spawnDistance;

    private List<GameObject> ghostList;

    private List<GhostType> ghostTypes;
    
    // Start is called before the first frame update
    void Start()
    {
        ghostList = GetComponent<Ghosts>().ghostList;
        ghostTypes = Enum.GetValues(typeof(GhostType)).OfType<GhostType>().ToList();
    }

    // Update is called once per frame
    void Update()
    { 
        List<GhostType> currentGhostTypes = new List<GhostType>();
        ghostList.ForEach(ghost => currentGhostTypes.Add((GhostType) ghost.GetComponent<GhostBehaviour>().ghostType));
        
        if (timeSinceLastGhost <= 0 && ghostList.Count < 1)
        {
            var newGhost = Instantiate(ghostGameObject, transform);

            Vector2 flatGhostPos = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 ghostPos = new Vector3(flatGhostPos.x, Random.Range(-1f, 10f), flatGhostPos.y);
            newGhost.transform.position = ghostPos;

            GhostBehaviour newGhostBehaviour = newGhost.GetComponent<GhostBehaviour>();
            
            newGhostBehaviour.ghostList = ghostList;
            newGhostBehaviour.micInput = MicInput;
            
            GhostType newGhostType = ghostTypes[Random.Range(0, ghostTypes.Count)];
            while (currentGhostTypes.Contains(newGhostType)) newGhostType = ghostTypes[Random.Range(0, ghostTypes.Count)];
            
            newGhostBehaviour.ghostType = newGhostType;
            
            ghostList.Add(newGhost);
            
            timeSinceLastGhost = waitTime;
            
            Debug.Log("new ghost type: " + newGhostBehaviour.ghostType);
        }

        timeSinceLastGhost -= Time.deltaTime;
    }
}
