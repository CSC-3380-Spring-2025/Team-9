using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class Spider : MortalEnemy, IDamageable<int>
{
    private bool isBigSpider = true;
    public Transform[] childrenSpawnPoints; 

    public GameObject spiderPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // i could create an empty game object, set it as child of the gameobject that holds this script
    // create n of these, then place them in aircle around the spide. so this is the number of spiders
    int n = 4;

    int generations = 2; // how many times the original spider will spawn offspring when dying 


    int radius = 4; // distance from center of spider to spawn children
    // the radius should also depend on the new size of the spider

// i should do something different for the scaling factor
    

    void Start()
    {
        currentHealthPoints = healthPoints;


        // the following will eventually be moved to a function of its own
        Time.timeScale = 0.2f;
        float radians = Mathf.PI / 4;
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
        Destroy(gameObject, 5);
    }


    override public void Die() 
    {


        if (isDead) return;
        isDead = true;
        //before destroying, cease all animations, activity, etc.
        

        Destroy(gameObject, 20); // this might be able to go in the beginning

    }
}
