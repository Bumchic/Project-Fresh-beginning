using UnityEngine;

public class trap1 : MonoBehaviour
{
    public float tocdoxoay = 15f; // Rotation speed
    public float tododichuyen = 5f; // Movement speed
    public Transform diemA; // Point A
    public Transform diemB; // Point B
    private Vector3 diemmuctieu; // Target position
    public float damageAmount = 10f; // Damage dealt by the trap

    void Start()
    {
        // Set initial target to diemA
        diemmuctieu = diemA.position;
    }

    void Update()
    {
        // Move towards the current target (diemmuctieu) at the specified speed
        transform.position = Vector3.MoveTowards(transform.position, diemmuctieu, tododichuyen * Time.deltaTime);

        // Check if the object is near the target, then switch target
        if (Vector3.Distance(transform.position, diemmuctieu) < 0.1f)
        {
            // Switch target between diemA and diemB
            if (diemmuctieu == diemA.position)
            {
                diemmuctieu = diemB.position;
            }
            else
            {
                diemmuctieu = diemA.position;
            }
        }
    }

    void FixedUpdate()
    {
        // Rotate the object around the Z-axis
        transform.Rotate(0, 0, tocdoxoay * Time.fixedDeltaTime);
    }

    // For 2D collisions, use OnCollisionEnter2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Access the PlayerHealth component and apply damage
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
