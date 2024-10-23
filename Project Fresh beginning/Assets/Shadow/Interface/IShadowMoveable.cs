using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShadowMoveable
{
    float MoveSpeed { get; set; }
    Rigidbody2D rigidbody2D { get; set; }
    
    void Move(float Speed);


}
