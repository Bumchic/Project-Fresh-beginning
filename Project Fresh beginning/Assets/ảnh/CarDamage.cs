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

            GameManager.gameManager.PlayerHealth.TakeDamage(10);
            Destroy(gameObject);
        }
    }
}
