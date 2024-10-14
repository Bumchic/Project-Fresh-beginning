

using UnityEngine;



public class ShadowBase :MonoBehaviour, IShadowMoveable
{
    public float MoveSpeed { get; set; }
    [field:SerializeField]public Rigidbody2D rigidbody2D { get; set; }

    public int num;


    void Update()
    {
        Move(11f);     
    }

    public void Move(float Speed)
    {
        float CurSpeed = Mathf.Clamp((rigidbody2D.velocity.x + 1f), -Speed, +Speed);
        rigidbody2D.velocity = new Vector2(CurSpeed, rigidbody2D.velocity.y);
    }


}
