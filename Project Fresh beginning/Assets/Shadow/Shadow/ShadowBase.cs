using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class ShadowBase :MonoBehaviour, IShadowMoveable, IShadowContactable
{
    public float MoveSpeed { get; set; }
    [field:SerializeField]public Rigidbody2D rigidbody2D { get; set; }
    [field: SerializeField] public BoxCollider2D boxCollider { get; set; }
    [field: SerializeField] public LayerMask ShadowlayerMask { get; set;}
    public bool shadowContacted { get; set; }

    void Update()
    {
        Move(10f);
    }

    public void Move(float Speed)
    {
        rigidbody2D.velocity = new Vector2(Speed, rigidbody2D.velocity.y);
    }

    public void ShadowContactCheck()
    {
        shadowContacted = Physics2D.OverlapAreaAll(boxCollider.bounds.min, boxCollider.bounds.max, ShadowlayerMask).Length > 0;
    }
}
