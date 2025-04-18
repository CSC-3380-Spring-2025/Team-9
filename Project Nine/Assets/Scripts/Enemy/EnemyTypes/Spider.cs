
using UnityEngine;



public class Spider : MortalEnemy, IDamageable<int>
{
   // private bool isBigSpider = true;
    public Transform[] childrenSpawnPoints; 

    public GameObject spiderPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // i could create an empty game object, set it as child of the gameobject that holds this script
    // create n of these, then place them in aircle around the spide. so this is the number of spiders
    int n = 4;

    int generations = 2; // how many times the original spider will spawn offspring when dying 


    int radius = 2; // distance from center of spider to spawn children
    // the radius should also depend on the new size of the spider

// i should do something different for the scaling factor


// as of now the spanwFromCode functions spawns the enemies around the circle, and i need them to spawn inside the circle and at somewhat random points so
// they don't look too repetitive.
// so i would have to make the radius(distance from center of origin enemy to child enemy smaller) and make it random and make the angle in radians random
/// as well 
/// 
///  and i should probably figure out a better scaling factor.
/// i don't think i will be using the isBigSpider variable anymore.

    void Start()
    {
        currentHealthPoints = healthPoints;


        // the following will eventually be moved to a function of its own
        //Time.timeScale = 0.2f;
        // float radians = Mathf.PI / 4;
        // while (n > 0 && generations > 0)
        // {
        // //     GameObject childEmpty = new GameObject($"SpiderSon {n}");
        // // childEmpty.transform.SetParent(transform);
        // Vector3 parentPos = transform.position;  
        // Vector3 babySpiderPos =  new Vector3(parentPos.x + (radius*Mathf.Cos(radians)), parentPos.y + radius*Mathf.Sin(radians), parentPos.z);
      
        // Debug.Log("the transform of the empty child is: " + babySpiderPos);
        // GameObject childSpider = Instantiate(spiderPrefab, babySpiderPos , Quaternion.identity);
        // Vector3 scale = childSpider.transform.localScale;
        // childSpider.transform.localScale = new Vector3(scale.x/2f, scale.y/2f, scale.z);
        // childSpider.GetComponent<Spider>().generations = generations -1; 
        // childSpider.GetComponent<Spider>().radius = radius - 1; 
        
        // n--;
        // radians += Mathf.PI / 2;
        // }
        // Destroy(gameObject, 5);
    }

    void SpawnOffspringFromCode()
    {
        float radians = Random.Range(0f, 2*Mathf.PI);
        float newradius = Random.Range(0f, radius);
        //float radians = Mathf.PI / 4;
        while (n > 0 && generations > 0)
        {
        //     GameObject childEmpty = new GameObject($"SpiderSon {n}");
        // childEmpty.transform.SetParent(transform);
        Vector3 parentPos = transform.position;  
        Vector3 babySpiderPos =  new Vector3(parentPos.x + (radius*Mathf.Cos(radians)), parentPos.y + radius*Mathf.Sin(radians), parentPos.z);
      
        Debug.Log("the transform of the empty child is: " + babySpiderPos);
        GameObject childSpider = Instantiate(spiderPrefab, babySpiderPos , Quaternion.identity);
        Vector3 scale = childSpider.transform.localScale;
        childSpider.transform.localScale = new Vector3(scale.x/2f, scale.y/2f, scale.z);
        childSpider.GetComponent<Spider>().generations = generations -1; 
        childSpider.GetComponent<Spider>().radius = radius - 1; 
        
        
        n--;
        radians += Mathf.PI / 2;
        }
        Destroy(gameObject, 5); // this should be commented out. this isjust for ease of testing right now
    }

    void SpawnOffspring() // method using transforms. this function would then be called inside the Die method. 
    {
        foreach (Transform babySpiderPos in childrenSpawnPoints) // here babySpiderPos is a transform instead of a vector3.
        {
            GameObject childSpider = Instantiate(spiderPrefab, babySpiderPos.position, Quaternion.identity);
            Vector3 scale = childSpider.transform.localScale;
            childSpider.transform.localScale = new Vector3(scale.x/2f, scale.y/2f, scale.z);
            childSpider.GetComponent<Spider>().generations = generations -1; 
            //childSpider.GetComponent<Spider>().radius = radius - 1; 
        }
    }


    override public void Die() 
    {
        if (isDead) return;
        isDead = true;
        //before destroying, cease all animations, activity, etc.
      
        SpawnOffspringFromCode();
        Destroy(gameObject);
    }
}
