
using System;
using System.Drawing;
using UnityEngine;

public class Movement_script : MonoBehaviour
{
    public Rigidbody2D Body;
    public float Speed;
    public float JumpPower;
    [Range(0.1f, 1f)]
    public float friction;
    public bool grounded;
    public BoxCollider2D FloorCheck;
    public LayerMask FloorCheckMask;
    private float xinput;
    private float yinput;
    public float accelaration;
    public float SprintAccModifier;
    public float SprintSpeedModifier;
    private float SprintAccelaration;
    private float SprintSpeed;
    public int JumpCounter;
    public BoxCollider2D BodyHitBox;
    public bool CrouchState;
    private float CrouchColliderSize;
    private Vector2 StandColliderSize;
    private float CrouchColliderOffSet;
    private Vector2 StandColliderOffSet;
    public BoxCollider2D ColliderStandUpCheck;
    public bool HeadCollision;
    public LayerMask HeadCollisionMask;
    public float CrouchSpeed;
    private float StandSpeed;
    public BoxCollider2D ClimbBoxCheck;
    public bool Climbing;
    public LayerMask ClimbingMask;
    public float BodyTransformX;
    public Animator animator;

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
    void Move()
    {
        float Increment = xinput * (accelaration + SprintAccelaration);
        float RealSpeed = Mathf.Clamp(Body.velocity.x + Increment, -(Speed+SprintSpeed), Speed + SprintSpeed);
        Body.velocity = new Vector2(RealSpeed, Body.velocity.y);
        
        FaceDirection();
    }
    
    void SprintModifier()
    {
        if (Input.GetKey(KeyCode.LeftShift) && grounded && !CrouchState)
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
        
        //SprintModifier();
        if (Mathf.Abs(xinput) > 0)
        {
           Move();
           animator.SetBool("IsRunning", true);
        }else
        {
            animator.SetBool("IsRunning", false);
        }
        
    }
    void FaceDirection()
    {
        float direction = Mathf.Sign(xinput);
        transform.localScale = new Vector3(direction * Mathf.Abs(BodyTransformX), Body.transform.localScale.y, Body.transform.localScale.z);
    }
    bool JumpButton()
    {
        return Input.GetKeyDown(KeyCode.W);
    }
    void Jump()
    {
            Body.velocity = new Vector2(Body.velocity.x, JumpPower);
    }
    void JumpMovement()
    { 
      /*  if (grounded)
        {
            JumpCounter = 1; //This is the code for double jump :/
        }*/
        if ((JumpButton()) && grounded)
        {
            Jump();

            //JumpCounter--;
        }

    }
    
    bool CrouchButtonPressed()
    {
        return Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
    }
    void Crouch()
    {
        BodyHitBox.size = new Vector2(BodyHitBox.size.x, 0.4782845f);
        BodyHitBox.offset = new Vector2(BodyHitBox.offset.x, - 1.333374f);
        Speed = CrouchSpeed;
        CrouchState = true;
        
    }
    void Stand()
    {
        BodyHitBox.size = StandColliderSize;
        BodyHitBox.offset = StandColliderOffSet;
        Speed = StandSpeed;
        CrouchState = false;      
    }
    void CrouchMovement()
    {    
          HeadCollisionCheck();
        if (CrouchButtonPressed() && grounded)
        {
            Crouch();
            animator.SetBool("IsCrouching", true);
           
        } else if(!CrouchButtonPressed() && !HeadCollision)
        {
            Stand();
            animator.SetBool("IsCrouching", false);
        }
    }
    void HeadCollisionCheck()
    {
        HeadCollision = Physics2D.OverlapAreaAll(ColliderStandUpCheck.bounds.min, ColliderStandUpCheck.bounds.max, HeadCollisionMask).Length > 0;
    }
    void ClimbingCheck()
    {
        Climbing = Physics2D.OverlapAreaAll(ClimbBoxCheck.bounds.min, ClimbBoxCheck.bounds.max, ClimbingMask).Length > 0;
    }

    void ClimbingMovement()
    {
        ClimbingCheck();
        if(!grounded && Climbing && Input.GetKeyDown(KeyCode.Space))
        {
           
        }
    }

   
    void Start()
    {
        CrouchState = false;
        StandColliderSize = BodyHitBox.size;
        StandColliderOffSet = BodyHitBox.offset;
        StandSpeed = Speed;
        BodyTransformX = Body.transform.localScale.x;
    }
  
    void Update() 
    {
        GetInput();
        JumpMovement();
        MovementInput();
        CrouchMovement();
        ClimbingMovement();

    }

    void FixedUpdate()
    {      
        Groundcheck();
        ApplyGroundFriction();
    }
}
