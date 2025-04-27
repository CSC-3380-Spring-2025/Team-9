using Pathfinding;
using UnityEngine;

public class DestinationSetter : MonoBehaviour
{
    
    AIDestinationSetter destinationSetter;
    void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
       destinationSetter = GetComponent<AIDestinationSetter>();
       destinationSetter.target =  player.transform;
    }

 
}
