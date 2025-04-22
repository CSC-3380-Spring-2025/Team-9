using UnityEngine;
using UnityEngineInternal;

public class ArrowShot : MonoBehaviour
{
    [SerializeField] private ArrowItem arrowData;

    private GameObject player;

    private Rigidbody2D rbArrow;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rbArrow = GetComponent<Rigidbody2D>();


        SetVelocity();
    }
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject type = collision.gameObject;
        switch (collision.tag)
        {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Snail":
                Destroy(gameObject);
                break;
            case "Immortal":
                Destroy(gameObject);
                break;
            case "Spider":
                Spider spider = type.GetComponent<Spider>();
                spider.TakeDamage(arrowData.damage);
                Destroy(gameObject);
                break;
            case "Boss":
                BossHealth boss = type.GetComponent<BossHealth>();
                boss.TakeDamage(arrowData.damage);
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }

    public void SetArrowData(ArrowItem data)
    {
        arrowData = data;
    }
    private void SetVelocity()
    {
        SetArrowData(arrowData);
        transform.position = player.transform.position;
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseWorldPos - (Vector2)player.transform.position).normalized;
        rbArrow.linearVelocity = direction * arrowData.maxArrowVelocity;
    }
}
