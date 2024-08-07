using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_script : MonoBehaviour
{
    public Rigidbody2D Body;
    public float speed;
    public float drag;
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
        Body.velocity = Body.velocity * drag;
    }
}
