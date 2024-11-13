using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseScript : MonoBehaviour
{
    public EnemyStateMachine stateMachine { get; private set; }
    public PatrolState patrolState { get; private set; }
    public ChasingPlayerState chasingPlayerState { get; private set; }

    [field: SerializeField] public Rigidbody2D rigidbody { get; private set; }
    [field: SerializeField] public BoxCollider2D WalkIntoWallCheck { get; private set; }
    [field: SerializeField] public LayerMask FloorMask { get; private set; }
    [field: SerializeField] public Transform playerTransform { get; private set; }
    [field: SerializeField] public bool WalkingIntoWall { get; set; }
    [field: SerializeField] public bool isChasingPlayer { get; set; }
    [field: SerializeField] public int isFacingRight { get;  set; }

    public float Transformx { get; private set; }
    public float maxSpeed { get; private set; } = 5f;

    private void Awake()
    {
        // Lấy Rigidbody và Player Transform
        rigidbody = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Khởi tạo State Machine
        stateMachine = new EnemyStateMachine(this, rigidbody);

        // Tạo các trạng thái
        patrolState = new PatrolState(this, stateMachine);
        chasingPlayerState = new ChasingPlayerState(this, stateMachine, playerTransform);

        // Khởi tạo các biến khác
        Transformx = transform.localScale.x;
        isFacingRight = 0;
        isChasingPlayer = false;
    }

    private void Start()
    {
        // Khởi tạo state đầu tiên
        stateMachine.Initialize(patrolState);
        FaceDirection();
    }

    private void Update()
    {
        stateMachine.enemyState.FrameUpdate();
        FaceDirection();
    }

    private void FixedUpdate()
    {
        stateMachine.enemyState.PhysicUpdate();
    }

    public void Move(float speed)
    {
        rigidbody.velocity = new Vector2(speed * NumFaceDirection(), rigidbody.velocity.y);
    }

    public void FaceDirection()
    {
        transform.localScale = new Vector3(NumFaceDirection() * Transformx, transform.localScale.y, transform.localScale.z);
    }

    public void HitWallCheck()
    {
        WalkingIntoWall = Physics2D.OverlapAreaAll(WalkIntoWallCheck.bounds.min, WalkIntoWallCheck.bounds.max, FloorMask).Length > 0;
    }

    public float NumFaceDirection()
    {
        return isFacingRight == 0 ? -1f : 1f;
    }
}