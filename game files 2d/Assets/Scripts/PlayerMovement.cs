using UnityEngine;

/// <summary>
/// Handles player movement.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Tooltip("Movement speed of the player.")]
    private float moveSpeed = 5f;

    private void Update()
    {
        // Get input for movement
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector2 movement = new Vector2(moveX, moveY) * moveSpeed * Time.deltaTime;

        // Move the player
        transform.Translate(movement);
    }
}
