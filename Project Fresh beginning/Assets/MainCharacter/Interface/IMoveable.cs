using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
   Rigidbody2D Rigidbody2d { get; set; }
    float xinput { get; set; }
    float yinput { get; set; }
    float Transformx { get; set; }
    BoxCollider2D FloorCheckOuter { get; set; }
    LayerMask FloorCheckMask { get; set; }
    BoxCollider2D ColliderStandUpCheck { get; set; }
    LayerMask HeadCollisionMask { get; set; }

    void GetInput();
    void WalkMovement(float speed);
    void FaceDirection();
    


}
