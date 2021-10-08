using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDetection : MonoBehaviour
{
    private List<GameObject> ghostList;

    public float detectionConeLength = 10;
    public float detectionConeSize = 25;

    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        ghostList = GetComponent<Ghosts>().ghostList;
    }

    // Update is called once per frame
    void Update()
    {
        float midAngle = Vector3.Angle(Vector3.forward, player.transform.forward);
        
        float startAngle = 360 / (0.5f * detectionConeSize) - midAngle;
        // calculate endAngle
        float endAngle = 360 / (0.5f * detectionConeSize) + midAngle;
        
        Debug.Log(midAngle);
        
        foreach (var ghost in ghostList)
        {
            if (checkDetection(ghost, startAngle, endAngle)) Destroy(ghost);
        }
    }
    
    private bool checkDetection(GameObject ghost, float startAngle, float endAngle)
    {
        float x = ghost.transform.position.x;
        float y = ghost.transform.position.z;
        
        // Calculate polar co-ordinates
        float polarradius = Mathf.Sqrt(x * x + y * y);
                     
        float Angle = Vector3.Angle(Vector3.forward, new Vector3(x,0,y));
            //Mathf.Atan(y / x);
     
        // Check whether polarradius is less then
        // radius of circle or not and Angle is
        // between startAngle and endAngle or not
        if (Angle >= startAngle 
            && Angle <= endAngle
            && polarradius < detectionConeLength) return true;
        
        return false;
    }
}
