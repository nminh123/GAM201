using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;         // Tốc độ di chuyển
    public float rotationSpeed = 0.1f;  // Tốc độ xoay
    public float jumpForce = 5f;        // Lực nhảy
    public Transform cameraTransform;   // Transform của camera
    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float gravity = -9.81f;     // Trọng lực
    private float velocityY = 0f;       // Tốc độ rơi

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (cameraTransform == null)
        {
            Debug.LogError("Camera Transform is not assigned!");
        }
    }

    void Update()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {
        // Lấy input từ bàn phím
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Hướng di chuyển dựa trên input
        Vector3 inputDirection = new Vector3(horizontal, 0, vertical).normalized;

        if (inputDirection.magnitude >= 0.1f)
        {
            // Xác định góc quay theo hướng camera
            float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float smoothedAngle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, rotationSpeed);

            // Xoay nhân vật
            transform.rotation = Quaternion.Euler(0, smoothedAngle, 0);

            // Hướng di chuyển theo góc đã xoay
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            moveDirection = moveDir * moveSpeed;
        }
        else
        {
            moveDirection.x = 0;
            moveDirection.z = 0;
        }

        // Áp dụng trọng lực
        if (characterController.isGrounded)
        {
            velocityY = 0;
            if (Input.GetButtonDown("Jump"))
            {
                velocityY = jumpForce;
            }
        }
        velocityY += gravity * Time.deltaTime;
        moveDirection.y = velocityY;

        // Di chuyển nhân vật
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
