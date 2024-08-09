using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_script : MonoBehaviour
{
    public Rigidbody2D Body;
    public float speed;
    [Range(0.1f, 1f)]
    public float friction;
    public bool grounded;
    public BoxCollider2D FloorCheck;
    public LayerMask FloorCheckMask;
    float xinput;
    float yinput;

    void Groundcheck()
    {
        grounded = Physics2D.OverlapAreaAll(FloorCheck.bounds.min, FloorCheck.bounds.max, FloorCheckMask).Length > 0;
    }
    void GetInput()
    {
        xinput = Input.GetAxis("Horizontal");
        yinput  = Input.GetAxis("Vertical");
    }

    void MovementInput()
    {
        if (Mathf.Abs(xinput) > 0)
        {
            Body.velocity = new Vector2(xinput * speed, Body.velocity.y);
        }
        if (Mathf.Abs(yinput) > 0 && grounded)
        {
            Body.velocity = new Vector2(Body.velocity.x, yinput * speed);
        }
    }
    void ApplyGroundFriction()
    {
        if (grounded && xinput == 0 && yinput == 0)
        {
            Body.velocity = Body.velocity * friction;
        }
    }
    void Start()
    {
        
    }
  
    void Update() 
    {
        GetInput();
        MovementInput();
    }

   

    void FixedUpdate()
    {
        Groundcheck();
        ApplyGroundFriction();
       
    }
}
