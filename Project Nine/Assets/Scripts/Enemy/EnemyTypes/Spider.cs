
using System.Linq;
using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;



public class Spider : MortalEnemy, IDamageable<int>
{
   // public Transform[] childrenSpawnPoints; 

    public GameObject spiderPrefab;
    public GameObject MediumSpiderPrefab;
    public GameObject SmallSpiderPrefab;
    private SpiderSize spiderSize = SpiderSize.BigSpider;
    private GameObject childSpider;
    public AILerp aiLerpScript;
    

    int n = 4; // number of children to spaawn
   // int generations = 2; // how many times the original spider will spawn offspring when dying. not needed anymore
    int radius = 2; // distance from center of spider to spawn children at the beginning

    void Awake()
    {
        
        aiLerpScript = GetComponent<AILerp>();
    }
    void Start()
    {
        currentHealthPoints = healthPoints;
    }

    void SpawnOffspringFromCode()
    {
        float radians = Random.Range(0f, 2*Mathf.PI); // maybe it would look better if these were inside the while loop
        float newradius = Random.Range(0f, radius);
     
        while (n > 0 && spiderSize > SpiderSize.SmallSpider)
        {
            Vector3 parentPos = transform.position;  
            Vector3 babySpiderPos =  new Vector3(parentPos.x + (radius*Mathf.Cos(radians)), parentPos.y + radius*Mathf.Sin(radians), parentPos.z);
            //GameObject childSpider = Instantiate(spiderPrefab, babySpiderPos , Quaternion.identity);
            //Vector3 scale = childSpider.transform.localScale;
            // childSpider.transform.localScale = new Vector3(scale.x/2f, scale.y/2f, scale.z);

            // if size of current spider is BigSpider, set children to be medium spider, if size is medium spider then set chilren to be small spider
            if (spiderSize == SpiderSize.BigSpider)
            {
                
                childSpider = Instantiate(MediumSpiderPrefab, babySpiderPos , Quaternion.identity);
                childSpider.GetComponent<Spider>().spiderSize = SpiderSize.MediumSpider;
            }
            else if (spiderSize == SpiderSize.MediumSpider)
            {
                childSpider = Instantiate(SmallSpiderPrefab, babySpiderPos , Quaternion.identity);
                childSpider.GetComponent<Spider>().spiderSize = SpiderSize.SmallSpider;
            }
            
            if (childSpider != null)
            {
                //childSpider.GetComponent<Spider>().generations = generations -1; 
                childSpider.GetComponent<Spider>().radius = radius - 1; 
                childSpider.GetComponent<Spider>().enemyAttackRange = enemyAttackRange - 1;  // i need this radius to be something more accurate
                childSpider.GetComponent<Spider>().SetSpeed(); // set a random speed to each child instance
            }
            else
            {
                Debug.LogWarning("childSpider is null. Did you set assign the prefabs?");
                Debug.Log("Spider size is set to : " + spiderSize.ToString());
            }
            
            n--;
            radians += Mathf.PI / 2;
        }
    }

    // void SpawnOffspring() // method using transforms. this function would then be called inside the Die method. 
    // {
    //     foreach (Transform babySpiderPos in childrenSpawnPoints) // here babySpiderPos is a transform instead of a vector3.
    //     {
    //         GameObject childSpider = Instantiate(spiderPrefab, babySpiderPos.position, Quaternion.identity);
    //         Vector3 scale = childSpider.transform.localScale;
    //         childSpider.transform.localScale = new Vector3(scale.x/2f, scale.y/2f, scale.z);
    //         childSpider.GetComponent<Spider>().generations = generations -1; 
    //     }
    // }


    override public void Die() 
    {
        if (isDead) return;
        isDead = true;
        //before destroying, cease all animations, activity, etc.
      
        SpawnOffspringFromCode();
        Destroy(gameObject);
    }

    void SetSpeed()
    {
        float speedAI = Random.Range(20, 30) / 10;
        aiLerpScript.speed = speedAI;
    }


}

public  enum SpiderSize
{
    SmallSpider,
    MediumSpider,
    BigSpider,


}
