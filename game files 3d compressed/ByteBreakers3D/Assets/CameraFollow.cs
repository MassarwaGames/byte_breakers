using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField, Tooltip("The player object to follow.")]
    private Transform player;

    [SerializeField, Tooltip("Offset position relative to the player.")]
    private Vector3 offset = new Vector3(0, 2, -5);

    [SerializeField, Tooltip("How smoothly the camera follows.")]
    private float smoothSpeed = 0.125f;

    private void LateUpdate()
    {
        if (player == null) return;

        // Calculate target position
        Vector3 targetPosition = player.position + offset;

        // Smoothly move the camera
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

        // Ensure the camera looks at the player
        transform.LookAt(player);
    }
}
