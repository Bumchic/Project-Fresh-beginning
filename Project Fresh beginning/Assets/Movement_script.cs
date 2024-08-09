using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Movement_script : MonoBehaviour
{
    public Rigidbody2D Body;
    public float speed;
    public float JumpPower;
    [Range(0.1f, 1f)] public float friction;
    public bool grounded;
    public BoxCollider2D FloorCheck;
    public LayerMask FloorCheckMask;
    float xinput;
    float yinput;
    public float accelaration;

    void Groundcheck()
    {
        grounded = Physics2D.OverlapAreaAll(FloorCheck.bounds.min, FloorCheck.bounds.max, FloorCheckMask).Length > 0;
    }
    void GetInput()
    {
        xinput = Input.GetAxis("Horizontal");
        yinput = Input.GetAxis("Vertical");
    }

   
    void ApplyGroundFriction()
    {
        if (grounded && xinput == 0 && yinput == 0)
        {
            Body.velocity = Body.velocity * friction;
        }
    }
    void MovementInput()
    {
        if (Mathf.Abs(xinput) > 0)
        {
            float Increment = xinput * accelaration;
            float RealSpeed = Mathf.Sign(xinput + Increment, -speed, speed);
            Body.velocity = new Vector2(RealSpeed, Body.velocity.y);
            float direction = Mathf.Sign(xinput);
            transform.localScale = new Vector2(direction, 1);
        }
    }
    void JumpMovement()
    {
         if (Mathf.Abs(yinput) > 0 && grounded)
        {
            Body.velocity = new Vector2(Body.velocity.x, yinput* JumpPower);
        }
    }
    void Start()
    {
        
    }
  
    void Update() 
    {
        GetInput();
        JumpMovement();
        
    }

    void FixedUpdate()
    {
        MovementInput();
        Groundcheck();
        ApplyGroundFriction();
    }
}
