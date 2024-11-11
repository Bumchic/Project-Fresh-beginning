using UnityEngine;

public class MoveBackAndForth : MonoBehaviour
{
    public float speed = 2.0f; // Tốc độ di chuyển
    public Transform characterTransform; // Transform của nhân vật

    private Vector3 startPosition;
    private Vector3 lastCharacterPosition;

    void Start()
    {
        lastCharacterPosition = characterTransform.position;
    }

    void Update()
    {
        if (characterTransform.position.x != lastCharacterPosition.x)
        {
            // Kiểm tra xem nhân vật có di chuyển không
            if (characterTransform.position.x - lastCharacterPosition.x>0.01f)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else if (characterTransform.position.x - lastCharacterPosition.x < -0.01f)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            lastCharacterPosition = characterTransform.position;
        }
    }
}