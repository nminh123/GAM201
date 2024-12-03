using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Mục tiêu để theo dõi (nhân vật)
    public Vector3 offset;          // Khoảng cách giữa camera và mục tiêu
    public float smoothSpeed = 0.125f;  // Tốc độ di chuyển camera mượt

    void LateUpdate()
    {
        if (target == null) return;

        // Xác định vị trí mới cho camera
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Cập nhật vị trí camera
        transform.position = smoothedPosition;

        // Giữ hướng nhìn của camera
        transform.LookAt(target);
    }
}
