using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap1 : MonoBehaviour
{
    public float tocdoxoay = 15f;
    public float tododichuyen = 5f; 
    public Transform diemA;
    public Transform diemB; 
    private Vector3 diemmuctieu; 

    void Start()
    {
        
        diemmuctieu = diemA.position;
    }

    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, diemmuctieu, tododichuyen * Time.deltaTime);

        if (Vector3.Distance(transform.position, diemmuctieu) < 0.1f)
        {
           
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
       
        transform.Rotate(0, 0, tocdoxoay * Time.fixedDeltaTime);
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
           
            playerHealth.TakeDamage(10);
        }
    }
}
