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
        float midAngle = player.transform.eulerAngles.y;
        
        float startAngle = midAngle - 0.5f * detectionConeSize;
        startAngle = startAngle < 0 ? startAngle + 360 : startAngle;
        // calculate endAngle
        float endAngle = midAngle + 0.5f * detectionConeSize;
        endAngle = endAngle > 360 ? endAngle - 360 : endAngle;
        
        //Debug.Log($"Start: {startAngle}, \n Mid: {midAngle}, \n End: {endAngle}");
        
        foreach (var ghost in ghostList)
        {
            if (CheckDetection(ghost, startAngle, midAngle, endAngle)) Destroy(ghost);
        }
    }
    
    private bool CheckDetection(GameObject ghost, float startAngle, float midAngle, float endAngle)
    {
        float x = ghost.transform.position.x;
        float y = ghost.transform.position.z;
        
        // Calculate polar co-ordinates
        float polarradius = Mathf.Sqrt(x * x + y * y);
                     
        float angle = Vector3.Angle(new Vector3(x, 0, y), Vector3.forward);
        angle = x < 0 ? 360 - angle : angle;
        
        // Check whether polarradius is less then
        // radius of circle or not and Angle is
        // between startAngle and endAngle or not
        if (angle >= startAngle 
            && angle <= endAngle
            && polarradius < detectionConeLength) return true;
        
        return false;
    }
}
