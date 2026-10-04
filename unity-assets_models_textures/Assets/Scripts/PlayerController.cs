using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float speed = 6f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;

    private CharacterController controller;
    private float verticalVelocity = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // WASD moves relative to where the camera faces, flattened onto the ground.
        Transform cam = Camera.main.transform;
        Vector3 forward = Vector3.ProjectOnPlane(cam.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(cam.right, Vector3.up).normalized;
        Vector3 input = Vector3.ClampMagnitude(
            right * Input.GetAxis("Horizontal") + forward * Input.GetAxis("Vertical"), 1f);

        if (controller.isGrounded)
        {
            // Keep a small downward push so isGrounded stays reliable.
            verticalVelocity = -1f;
            if (Input.GetKeyDown(KeyCode.Space))
                verticalVelocity = jumpSpeed;
        }
        verticalVelocity -= gravity * Time.deltaTime;

        Vector3 velocity = input * speed + Vector3.up * verticalVelocity;
        controller.Move(velocity * Time.deltaTime);
    }
}
