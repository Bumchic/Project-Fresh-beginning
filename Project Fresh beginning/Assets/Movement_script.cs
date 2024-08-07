using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_script : MonoBehaviour
{
    public Rigidbody2D Body;
    public float speed;
    public float drag;
    bool grounded;
    public BoxCollider2D FloorCheck;
    public LayerMask FloorCheckMask;
    void Groundcheck()
    {
      //  grounded = Physics2D.OverlapAreaAll(FloorCheck.)
    }
    void Start()
    {
        
    }

  
    void Update() 
    {
        float xinput = Input.GetAxis("Horizontal");
        float yinput = Input.GetAxis("Vertical");

        if(Mathf.Abs(xinput)>0)
        {
            Body.velocity = new Vector2(xinput * speed, Body.velocity.y);
        }
        if (Mathf.Abs(xinput) > 0)
        {
            Body.velocity = new Vector2(Body.velocity.x, yinput * speed );
        }
    }

   

    void FixedUpdate()
    {
        if (grounded)
        {
            
        }
        Body.velocity = Body.velocity * drag;
    }
}
