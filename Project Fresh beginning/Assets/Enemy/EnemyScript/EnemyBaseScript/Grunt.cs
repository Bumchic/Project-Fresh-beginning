using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : EnemyBaseScript
{
    public PatrolState patrolState { get; set; }
    public float num = 3f;
    public LayerMask RayLayerMask;
    private void Awake()
    {

        patrolState = new PatrolState(this, stateMachine);
    }
    void Start()
    {
        stateMachine.Initialize(patrolState);
    }

    void Update()
    {
        stateMachine.enemyState.FrameUpdate();
    }

    void FixedUpdate()
    {
        stateMachine.enemyState.PhysicUpdate();
    }





}
