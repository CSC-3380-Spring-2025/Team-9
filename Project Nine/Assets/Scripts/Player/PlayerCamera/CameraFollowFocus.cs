using UnityEngine;

public class CameraFollowFocus : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform Target;
    public float MaxDistance = 2f;


    void Start()
    {
        // find player so camara always follows when scene changes
        if (Target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                Target = player.transform;
            }
            else
            {
                Debug.LogError("Player not found!");
            }
        }
    }


    void Update()
    {
        if (Target == null) return;

        // Calculate the target position for the invisible object
        Vector3 targetPos = new Vector3(Target.position.x, Target.position.y, transform.position.z);

        // Move the invisible object smoothly toward the player
        transform.position = Vector3.Lerp(transform.position, targetPos, FollowSpeed * Time.deltaTime);

        // Ensure the invisible object doesn't get too far from the player
        float distance = Vector3.Distance(transform.position, Target.position);
        if (distance > MaxDistance)
        {
            // Move the invisible object closer to the player instantly if it exceeds the max distance
            Vector3 direction = (Target.position - transform.position).normalized;
            transform.position = Target.position - direction * MaxDistance;
        }
    }
}