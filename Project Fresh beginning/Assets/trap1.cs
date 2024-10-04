using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap1 : MonoBehaviour
{
    public float tocdoxoay = 15f; // Rotation speed
    public float tododichuyen = 5f; // Movement speed
    public Transform diemA; // Point A
    public Transform diemB; // Point B
    private Vector3 diemmuctieu; // Target position

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
        // Check if the collided object has a PlayerHealth script
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            // Reduce health by 30
            playerHealth.TakeDamage(30);
        }
    }
}
