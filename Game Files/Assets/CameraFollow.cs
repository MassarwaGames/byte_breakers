using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField, Tooltip("The player object to follow.")]
    private Transform player;

    [SerializeField, Tooltip("How quickly the camera follows the player.")]
    private float smoothSpeed = 0.125f;

    [SerializeField, Tooltip("Offset from the player's position.")]
    private Vector3 offset;

    private void LateUpdate()
    {
        if (player == null) return;

        // Target position for the camera
        Vector3 targetPosition = player.position + offset;

        // Smoothly move the camera to the target position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
