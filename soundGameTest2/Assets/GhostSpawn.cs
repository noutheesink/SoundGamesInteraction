using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawn : MonoBehaviour
{
    [SerializeField] private GameObject ghostGameObject;

    public float waitTime = 2f;
    private float timeSinceLastGhost = 0;

    public float spawnDistance;

    private List<GameObject> ghostList;
    
    // Start is called before the first frame update
    void Start()
    {
        ghostList = GetComponent<Ghosts>().ghostList;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceLastGhost <= 0)
        {
            var newGhost = Instantiate(ghostGameObject, transform);

            Vector3 ghostPos = Random.onUnitSphere;
            ghostPos.y = Mathf.Abs(ghostPos.y);
            ghostPos *= spawnDistance;
            newGhost.transform.position = ghostPos;

            newGhost.GetComponent<GhostBehaviour>().ghostList = ghostList;
            ghostList.Add(newGhost);
            
            timeSinceLastGhost = waitTime;
        }

        timeSinceLastGhost -= Time.deltaTime;
    }
}
