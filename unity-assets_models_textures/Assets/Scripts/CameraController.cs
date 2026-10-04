using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 3f;

    private Vector3 offset;
    private Quaternion startRotation;
    private float yaw = 0f;
    private float pitch = 0f;
    private PlayerController playerController;

    void Start()
    {
        offset = transform.position - player.position;
        startRotation = transform.rotation;
        playerController = player.GetComponent<PlayerController>();
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

        // While the Player drops back onto the start, hold the camera at the start's
        // height so the Player falls in from the top of the screen.
        Vector3 target = player.position;
        if (playerController != null && playerController.respawning)
            target.y = playerController.startPosition.y;

        Quaternion orbit = Quaternion.Euler(pitch, yaw, 0f);
        transform.position = target + orbit * offset;
        transform.rotation = orbit * startRotation;
    }
}
