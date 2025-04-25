using Pathfinding;
using Unity.Hierarchy;
using UnityEngine;

// switch between states of patrolling and chasing based on proximity from player
public class StartStopChase : MonoBehaviour
{
    public Transform player;
    public float endReachedDist = 1.5f; // distance at which we consider the agent has reached its destination
    public int distanceThreshold = 8; // Distance at which to start chasing .This and the above will differ for the size of each enemy
    private Patrol patrolScript;
    private AIDestinationSetter aiDestScript;
    private bool isPatrolling;
    private bool isChasing;
    private bool isAtDestination; // used to determine if it has reached player so that it doesn't ram him into the wall
    private GameObject baseGO; // base to patrol. Later could be an array of gmaeobjects for the enemy to move to and from

    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        player = GameObject.FindWithTag("Player").transform;
        
        patrolScript =  GetComponent<Patrol>();
        aiDestScript = GetComponent<AIDestinationSetter>();

        aiDestScript.target = player;
        makeHomeBase();
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
        else if (distance > endReachedDist && isAtDestination)
        {
            StartChase();
        }
        else if (distance < endReachedDist && isChasing)
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

    void makeHomeBase()
    {
        baseGO = new GameObject();
        GameObject baseParent = GameObject.Find("Bases");
        if (baseParent == null)
        {
            baseParent = new GameObject("Bases");
        }
        baseGO.transform.SetParent(baseParent.transform);

        baseGO.transform.position = transform.position;
        patrolScript.targets[0] = baseGO.transform;
   }

    void OnDestroy()
    {
        
        Destroy(baseGO);
    }

}
