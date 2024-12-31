using UnityEngine;
using TMPro;
using System.Collections;

/// <summary>
/// Handles terminal interaction, code validation, and syntax feedback.
/// </summary>
public class TerminalController : MonoBehaviour
{
    [SerializeField, Tooltip("Input field for entering code.")]
    private TMP_InputField codeInputField;

    [SerializeField, Tooltip("Button to submit the code.")]
    private UnityEngine.UI.Button submitButton;

    [SerializeField, Tooltip("Feedback text for player responses.")]
    private TMP_Text feedbackText;

    [SerializeField, Tooltip("Hint text to guide the player.")]
    private TMP_Text hintText;

    [SerializeField, Tooltip("Key to interact with the terminal.")]
    private KeyCode interactKey = KeyCode.F;

    [SerializeField, Tooltip("Audio source for victory sound.")]
    private AudioSource victoryAudioSource;

    private bool isPlayerNearby = false; // Tracks if the player is near the terminal
    private const string treeBurnSyntax = "tree.burn();"; // Command for burning a tree
    private const string doorUnlockSyntax = "door.unlock();"; // Command for unlocking a door

    private void Start()
    {
        if (submitButton != null)
        {
            submitButton.onClick.AddListener(ValidateCode);
        }

        //if (feedbackText != null)
        //{
        //    feedbackText.text = "Waiting for input...";
        //}

        if (hintText != null)
        {
            hintText.text = ""; // Hide the hint by default
        }

        // Hide UI initially
        ShowUI(false);
    }

    private void Update()
    {
        // Check if player presses the interaction key near the terminal
        if (isPlayerNearby && Input.GetKeyDown(interactKey))
        {
            ShowUI(true); // Show the input field and button
            if (hintText != null)
            {
                hintText.text = "Hint: Use 'tree.burn();' to burn the tree or 'door.unlock();' to unlock the door.";
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;

            // Show the interaction prompt
            if (hintText != null)
            {
                hintText.text = "Press F to interact.";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;

            // Hide the hint and UI when player leaves
            if (hintText != null)
            {
                hintText.text = "";
            }

            ShowUI(false);
        }
    }

    private void ValidateCode()
    {
        if (codeInputField == null || feedbackText == null) return;

        string enteredCode = codeInputField.text.Trim();

        if (enteredCode == treeBurnSyntax)
        {
            HandleAction("Tree", "The tree is burning!");
        }
        else if (enteredCode == doorUnlockSyntax)
        {
            HandleAction("Door", "The door is unlocking!");
        }
        else
        {
            feedbackText.text = "Invalid command. Try again.";
            StartCoroutine(HideFeedbackTextAfterDelay(3f)); // Hide after 3 seconds
        }
    }

    private void HandleAction(string tag, string successMessage)
    {
        GameObject targetObject = GameObject.FindGameObjectWithTag(tag);
        if (targetObject != null)
        {
            feedbackText.text = $"Code Accepted! {successMessage}";
            victoryAudioSource.Play();
            StartCoroutine(HideFeedbackTextAfterDelay(3f)); // Hide after 3 seconds

            // Check if the target object has a BurnableTree or similar component
            var burnable = targetObject.GetComponent<BurnableTree>();
            if (burnable != null)
            {
                burnable.Burn();
            }
            else
            {
                // If no BurnableTree component, disable the object (e.g., for doors)
                targetObject.SetActive(false);
            }
        }
        else
        {
            feedbackText.text = $"Error: No {tag} found in the scene.";
            StartCoroutine(HideFeedbackTextAfterDelay(3f)); // Hide after 3 seconds
        }
    }

    private IEnumerator HideFeedbackTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        feedbackText.text = ""; // Clear the text
    }

    private void ShowUI(bool show)
    {
        if (codeInputField != null)
        {
            codeInputField.gameObject.SetActive(show);
        }

        if (submitButton != null)
        {
            submitButton.gameObject.SetActive(show);
        }
    }
}
