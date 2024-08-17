
using System.Drawing;
using UnityEngine;

public class Movement_script : MonoBehaviour
{
    public Rigidbody2D Body;
    public float speed;
    public float JumpPower;
    [Range(0.1f, 1f)]
    public float friction;
    public bool grounded;
    public BoxCollider2D FloorCheck;
    public LayerMask FloorCheckMask;
    float xinput;
    float yinput;
    public float accelaration;
    public float SprintAccModifier;
    public float SprintSpeedModifier;
    float SprintAccelaration;
    float SprintSpeed;
    public int JumpCounter;
    public BoxCollider2D BodyHitbox;
    float StandHeight;
    float CrouchHeight;
    bool CrouchState;
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
        if (grounded && xinput == 0 && Body.velocity.y <= 0)
        {
            Body.velocity = Body.velocity * friction;
        }
    }
    void Sprint()
    {
        float Increment = xinput * (accelaration + SprintAccelaration);
        float RealSpeed = Mathf.Clamp(Body.velocity.x + Increment, -(speed+SprintSpeed), speed + SprintSpeed);
        Body.velocity = new Vector2(RealSpeed, Body.velocity.y);
        FaceDirection();
    }
    
    void SprintModifier()
    {
        if (Input.GetKey(KeyCode.LeftShift) && grounded)
        {
           
            SprintAccelaration = SprintAccModifier;
            SprintSpeed = SprintSpeedModifier;
        } else if(grounded)
        {
     
            SprintAccelaration = 0;
            SprintSpeed = 0;
        }
    }
    void MovementInput()
    {
        CrouchMovement();
        SprintModifier();
        if (Mathf.Abs(xinput) > 0)
        {
            Sprint();
        }  
    }
    void FaceDirection()
    {
        float direction = Mathf.Sign(xinput);
        transform.localScale = new Vector3(direction, 1, 1);
    }
    bool JumpButton()
    {
        return Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W);
    }
    void Jump()
    {
            Body.velocity = new Vector2(Body.velocity.x, JumpPower);
    }

    void JumpMovement()
    { 
        if (grounded)
        {
            JumpCounter = 1;
        }
        if ((JumpButton()) && JumpCounter > 0)
        {
            Jump();
            JumpCounter--;
        }
    }
    void Crouch(bool CrouchState)
    {
        BodyHitbox.size = new Vector2(BodyHitbox.size.x, CrouchHeight);
    }
    void Stand(bool CrouchState)
    {
      

        if(CrouchState == true)
        {
            BodyHitbox.size = new Vector2(BodyHitbox.size.x, StandHeight);
            CrouchState = false;
        }
        
    }
    void CrouchMovement()
    {    
        if (Input.GetKey(KeyCode.DownArrow)|| Input.GetKey(KeyCode.S))
        {
            CrouchState = true;
            Crouch(CrouchState);
        } else
        {
            Stand(CrouchState);
        }
        
    }
    void Start()
    {     
        CrouchHeight = BodyHitbox.size.y / 2;
        StandHeight = CrouchHeight * 2;
        CrouchState = false;
    }
  
    void Update() 
    {
        GetInput();
        JumpMovement();
        MovementInput();
    }

    void FixedUpdate()
    {      
        Groundcheck();
        ApplyGroundFriction();
    }
}
