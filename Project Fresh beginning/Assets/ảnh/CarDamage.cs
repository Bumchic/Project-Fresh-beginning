using UnityEngine;

public class CarDamage : MonoBehaviour
{
    public float speed = 3f; 
    public int damage = 20;  

    void Update()
    {
     
        transform.position = transform.position+ Vector3.left * speed * Time.deltaTime;
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
