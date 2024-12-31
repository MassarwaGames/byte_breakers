using UnityEngine;

public class TutorialTextManager : MonoBehaviour
{
    [SerializeField, Tooltip("Duration in seconds before the text disappears.")]
    private float duration = 30f;

    private void Start()
    {
        // Start the countdown
        Invoke("HideText", duration);
    }

    private void HideText()
    {
        // Disable the text GameObject
        gameObject.SetActive(false);
    }
}
