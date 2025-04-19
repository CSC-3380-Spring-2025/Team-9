using Pathfinding;
using UnityEngine;

// switch between states of patrolling and chasing based on proximity from player
public class StartStopChase : MonoBehaviour
{
    public Transform player;
    public float destinationDist = 1.5f;
    private int distanceThreshold = 8;
    private Patrol patrolScript;
    private AIDestinationSetter aiDestScript;
    private bool isPatrolling;
    private bool isChasing;
    private bool isAtDestination; // used to determine if it has reached player so that it doesn't ram him into the wall
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        player = GameObject.FindWithTag("Player").transform;
        
        patrolScript =  GetComponent<Patrol>();
        aiDestScript = GetComponent<AIDestinationSetter>();

        aiDestScript.target = player;
        StartPatrol();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= distanceThreshold && isPatrolling)
        {
            StartChase();
            
        }
        else if (distance >= distanceThreshold + 1  && isChasing) 
        {
            StartPatrol(); 
        }
        else if (distance > 2 && isAtDestination)
        {
            StartChase();
        }
        else if (distance < 2 && isChasing)
        {
            StopChase();
        }

    
    }

    void StartChase()
    {
        gameObject.GetComponent<Patrol>().enabled = false;
        gameObject.GetComponent<AIDestinationSetter>().enabled = true;
        isChasing = true;
        isPatrolling = false;
        isAtDestination = false;
    }

    void StartPatrol()
    {       
        gameObject.GetComponent<AIDestinationSetter>().enabled = false;
        gameObject.GetComponent<Patrol>().enabled = true;
        isPatrolling = true;
        isChasing = false;
        isAtDestination = false;
    }

    // stop chase momentarily when agent has reached target so it doesn't keep pushing into wall
    void StopChase()
    {
        aiDestScript.enabled = false;
        isChasing = false;
        isPatrolling = false;
        isAtDestination = true;
    }

}
