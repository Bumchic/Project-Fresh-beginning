using UnityEngine;

public class DestroyObjectOnCameraMove : MonoBehaviour
{
    public Camera mainCamera;
    public float destroyThreshold = 40f;

    void Update()
    {
        // Kiểm tra vị trí của camera trên trục X
        if (mainCamera.transform.position.x - transform.position.x > destroyThreshold)
        {
            // Kiểm tra tên của đối tượng
            if (gameObject.name.Contains("(Clone)"))
            {
                Destroy(gameObject);
            }
        }
    }
}
