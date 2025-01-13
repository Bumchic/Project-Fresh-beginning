using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;  // Tham chiếu đến nhân vật
    public Vector3 offset;    // Khoảng cách giữa object và nhân vật
    public float speed = 10f; // Tốc độ di chuyển

    void Update()
    {
        if (player != null)
        {
            // Tính vị trí mục tiêu dựa trên vị trí nhân vật và offset
            Vector3 targetPosition = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);

            // Di chuyển object mượt mà đến vị trí mục tiêu
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
