using UnityEngine;

public class LarryAI : MonoBehaviour
{
    public GameObject bonePrefab; 
    PlayerController player;
    BossHealth bossHealth;

    public float boneSpawnOffset = 1f;

    public float speedStage1 = 2f; 
    public float speedStage2 = 3.5f; 
    public float wiggleAmplitude = 1.8f; 
    public float wiggleFrequency = 2.5f; 

    public float fireIntervalStage1 = 2f; 
    public float fireIntervalStage2 = 1f; 
    public int bonesPerVolley1 = 6; 
    public int bonesPerVolley2 = 12; 
    public float boneSpeed = 6f;
    public float stopDuration = 0.5f; 

    float fireTimer;
    float stopTimer;
    bool  isStopping;
    Vector2 noiseSeed;

    void Awake()
    {
        bossHealth = GetComponent<BossHealth>();
        bossHealth.OnDeath += HandleBossDeath;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); 
        noiseSeed = Random.insideUnitCircle * 100f; 
    }

    void Update()
    {
        if (player == null) return;

        float interval = bossHealth.IsStageTwo ? fireIntervalStage2 : fireIntervalStage1;
        int   boneCount = bossHealth.IsStageTwo ? bonesPerVolley2 : bonesPerVolley1;
        float speed = bossHealth.IsStageTwo ? speedStage2 : speedStage1; 

        if (isStopping)
        {
            stopTimer += Time.deltaTime;
            if (stopTimer >= stopDuration)
            {
                stopTimer = 0f;
                isStopping = false;
                Fire(boneCount);
            }
            return;
        }

        float t = Time.time;
        Vector2 noisy = new Vector2(Mathf.PerlinNoise(noiseSeed.x, t * wiggleFrequency) - 0.5f, Mathf.PerlinNoise(noiseSeed.y, t * wiggleFrequency) - 0.5f) * wiggleAmplitude;
        Vector2 toPLayer = ((Vector2)player.transform.position - (Vector2)transform.position).normalized; 
        Vector2 dir = (toPLayer + noisy).normalized;

        transform.Translate(dir * speed * Time.deltaTime); 

        fireTimer += Time.deltaTime;
        if (fireTimer >= interval)
        {
            fireTimer = 0f;
            isStopping = true;
        }
    }
    
    void Fire(int count)
    {
        if (bonePrefab == null) return;

        float step = 360f / count;
        for (int i = 0; i < count; i++)
        {
            float angle = i * step;
            Vector2 dir = new Vector2(
                Mathf.Cos(angle * Mathf.Deg2Rad),
                Mathf.Sin(angle * Mathf.Deg2Rad));

            Vector3 spawnPos = transform.position + (Vector3)(dir * boneSpawnOffset);
            GameObject bone  = Instantiate(bonePrefab, spawnPos, Quaternion.identity);

            Collider2D bossCol = GetComponent<Collider2D>();
            Collider2D boneCol = bone.GetComponent<Collider2D>();
            if (bossCol && boneCol) Physics2D.IgnoreCollision(boneCol, bossCol, true);

            Rigidbody2D rb = bone.GetComponent<Rigidbody2D>();
            if (rb) rb.linearVelocity = dir * boneSpeed;            
        }
    }

    void HandleBossDeath()
    {
        FindFirstObjectByType<AugmentSelectionManager>(FindObjectsInactive.Include).ShowAugmentCards(player);
    }
}
