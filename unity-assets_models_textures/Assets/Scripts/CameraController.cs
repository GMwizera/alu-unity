using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 3f;

    private Vector3 offset;
    private Quaternion startRotation;
    private float yaw = 0f;
    private float pitch = 0f;

    void Start()
    {
        offset = transform.position - player.position;
        startRotation = transform.rotation;
    }

    void LateUpdate()
    {
        // Hold right-click and drag the mouse to orbit the camera around the Player.
        if (Input.GetMouseButton(1))
        {
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            pitch = Mathf.Clamp(pitch, -20f, 40f);
        }

        Quaternion orbit = Quaternion.Euler(pitch, yaw, 0f);
        transform.position = player.position + orbit * offset;
        transform.rotation = orbit * startRotation;
    }
}
