using UnityEngine;

public class DestroyOnCameraMove : MonoBehaviour
{
    public Camera mainCamera; // Reference to the main camera
    private float initialCameraPositionX; // Initial X position of the camera
    private const float moveThreshold = 40f; // Distance after which objects are destroyed

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main; // Get the main camera if not assigned
        }
        initialCameraPositionX = mainCamera.transform.position.x; // Store the initial camera position
    }

    void Update()
    {
        // Calculate the distance the camera has moved to the right
        float cameraDistanceMoved = mainCamera.transform.position.x - initialCameraPositionX;

        // Check if the camera has moved more than the threshold
        if (cameraDistanceMoved > moveThreshold)
        {
            Destroy(gameObject); // Destroy this object
        }
    }
}
