using UnityEngine;

public class BurnableTree : MonoBehaviour
{
    [SerializeField, Tooltip("The fire effect to activate.")]
    private GameObject fireEffect;

    [SerializeField, Tooltip("Feedback text for player actions.")]
    private TMPro.TMP_Text feedbackText;

    public void Burn()
    {
        if (fireEffect != null)
        {
            fireEffect.SetActive(true); // Activate fire effect
        }

        if (feedbackText != null)
        {
            feedbackText.text = "The tree is burning!";
        }

        // Simulate burning by disabling the tree after 2 seconds
        Destroy(gameObject, 2f);
    }
}
