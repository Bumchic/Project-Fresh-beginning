
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
    public BoxCollider2D ColliderHitBoxCheck;
    public bool HeadCollision;
    public LayerMask HeadCollisionMask;
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
        float RealSpeed = Mathf.Clamp(Body.velocity.x + Increment, -(speed+SprintSpeed), speed + SprintSpeed);
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
 
        SprintModifier();
        if (Mathf.Abs(xinput) > 0)
        {
            Move();
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

    bool CrouchButtonPressed()
    {
        return Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
    }
    void Crouch()
    {
        BodyHitBox.size = new Vector2(BodyHitBox.size.x, 0.3710684f);
        BodyHitBox.offset = new Vector2(BodyHitBox.offset.x, -0.4061485f);
        CrouchState = true;
    }
    void Stand()
    {
        BodyHitBox.size = StandColliderSize;
        BodyHitBox.offset = StandColliderOffSet;
        CrouchState = false;      
    }
    void CrouchMovement()
    {    
              HeadCollisionCheck();
        if (CrouchButtonPressed())
        {
            Crouch();
        } else if(!CrouchButtonPressed() && !HeadCollision)
        {
            Stand();
        }       
    }
    void HeadCollisionCheck()
    {
        HeadCollision = Physics2D.OverlapAreaAll(ColliderHitBoxCheck.bounds.min, ColliderHitBoxCheck.bounds.max, HeadCollisionMask).Length > 0;
    }

    void AirDrag()
    {

    }
    void Start()
    {
        CrouchState = false;
        StandColliderSize = BodyHitBox.size;
        StandColliderOffSet = BodyHitBox.offset;


    }
  
    void Update() 
    {
        GetInput();
        JumpMovement();
        MovementInput();
        CrouchMovement();
    }

    void FixedUpdate()
    {      
        Groundcheck();
        ApplyGroundFriction();

    }
}
