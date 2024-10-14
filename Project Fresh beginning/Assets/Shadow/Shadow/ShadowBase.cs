

using UnityEngine;



public class ShadowBase :MonoBehaviour, IShadowMoveable
{
    public float MoveSpeed { get; set; }
    [field:SerializeField]public Rigidbody2D rigidbody2D { get; set; }


    void Update()
    {
        Move(9f);
    }

    public void Move(float Speed)
    {
        rigidbody2D.velocity = new Vector2(Speed, rigidbody2D.velocity.y);
    }


}
