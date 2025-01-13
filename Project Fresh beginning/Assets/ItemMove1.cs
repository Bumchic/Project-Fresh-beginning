using UnityEngine;

public class itemMove1 : MonoBehaviour
{
    public float floatAmplitude = 0.2f; // Biên độ của chuyển động lên xuống
    public float floatSpeed = 1f;     // Tốc độ chuyển động lên xuống

    private Vector3 startPosition;      // Vị trí ban đầu của đối tượng

    void Start()
    {
        // Lưu vị trí ban đầu của item
        startPosition = transform.position;
    }

    void Update()
    {
        // Tạo chuyển động lên xuống bằng cách sử dụng hàm sin
        transform.position = startPosition + new Vector3(0, Mathf.Sin(Time.time * floatSpeed) * floatAmplitude, 0);
    }
}
