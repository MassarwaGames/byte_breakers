using UnityEngine;
using TMPro;

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

    [SerializeField, Tooltip("The door object to unlock.")]
    private GameObject door;

    [SerializeField, Tooltip("Key to interact with the terminal.")]
    private KeyCode interactKey = KeyCode.F;

    private bool isPlayerNearby = false; // Tracks if the player is near the terminal
    private const string correctSyntax = "door.unlock();"; // The correct code syntax

    private void Start()
    {
        if (submitButton != null)
        {
            submitButton.onClick.AddListener(ValidateCode);
        }

        if (feedbackText != null)
        {
            feedbackText.text = "Waiting for input...";
        }

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
                hintText.text = "Hint: Use 'door.unlock();' to open the door.";
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
        if (codeInputField == null || feedbackText == null || door == null) return;

        string enteredCode = codeInputField.text.Trim();

        if (enteredCode == correctSyntax) // Validate proper syntax
        {
            feedbackText.text = "Code Accepted! Door Unlocked.";
            UnlockDoor();
        }
        else
        {
            feedbackText.text = "Syntax Error: Check your code and try again.";
        }
    }

    private void UnlockDoor()
    {
        // Disable the door object to simulate unlocking
        door.SetActive(false);
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
