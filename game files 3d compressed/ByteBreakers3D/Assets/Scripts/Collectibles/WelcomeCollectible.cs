using UnityEngine;

public class WelcomeCollectible : MonoBehaviour
{
    [SerializeField, Tooltip("Sound to play when the collectible is picked up.")]
    private AudioClip collectSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Play the collect sound
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            // Display the welcome message
            UIManager.Instance.DisplayMessage("Welcome to the game!");

            // Destroy the collectible
            Destroy(gameObject);
        }
    }
}
