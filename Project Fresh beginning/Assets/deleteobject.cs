using UnityEngine;

public class DestroyObjectOnCameraMove : MonoBehaviour
{
    public Camera mainCamera; 
    public float destroyThreshold = 40f; 

    void Update()
    {
        // Kiểm tra vị trí của camera trên trục X
        if (mainCamera.transform.position.x > destroyThreshold)
        {
            // Xóa vật thể 
            Destroy(gameObject);
        }
    }
}
