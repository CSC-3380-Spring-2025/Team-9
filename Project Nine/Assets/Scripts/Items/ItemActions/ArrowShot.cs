using UnityEngine;
using UnityEngineInternal;

public class ArrowShot : MonoBehaviour
{
    [SerializeField] private ArrowItem arrow;

    private GameObject player;

    private Rigidbody2D rbArrow;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rbArrow = GetComponent<Rigidbody2D>();

        transform.position = player.transform.position;

        Vector2 mousePos = Input.mousePosition;
        Vector2 playerPos = player.transform.position;

        Vector2 mouseDistance = mousePos - playerPos;
        float angle = Mathf.Atan2(mouseDistance.y, mouseDistance.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Vector3 eulerAngles = transform.rotation.eulerAngles;
        //float angle = eulerAngles.z;

        /*
        Vector2 mousePos = Input.mousePosition;
        Vector2 playerPos = player.transform.position;

        Vector2 mouseDistance = mousePos - playerPos;
        float angle = Mathf.Atan2(mouseDistance.y, mouseDistance.x) * Mathf.Rad2Deg;

        float x = Mathf.Cos(angle) * arrow.maxArrowVelocity;
        float y = Mathf.Sin(angle) * arrow.maxArrowVelocity;

        rbArrow.linearVelocity = new Vector2(x,y);
        */
        /*
        transform.localEulerAngles = new Vector3(player.transform.localEulerAngles.x, player.transform.localEulerAngles.y);

        float theta = transform.localEulerAngles.z + 90;
        float newDirX = Mathf.Cos(theta * Mathf.Deg2Rad);
        float newDirY = Mathf.Sin(theta * Mathf.Deg2Rad);

        rbArrow.linearVelocity = new Vector2(newDirX, newDirY) * arrow.maxArrowVelocity;
        */
    }
    void Update()
    {
        if (player == null) {Debug.Log("");}
    }
}
