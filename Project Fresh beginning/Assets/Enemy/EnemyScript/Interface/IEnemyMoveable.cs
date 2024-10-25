using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMoveable
{
    public Rigidbody2D rigidbody { get; set; }
    void Move();
    void PathFind();
    void FaceDirection();

}
