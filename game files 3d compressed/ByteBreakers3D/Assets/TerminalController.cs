using UnityEngine;
using TMPro;
using System.Collections;

public class TerminalController : MonoBehaviour
{
    [SerializeField, Tooltip("Input field for entering code.")]
    private TMP_InputField codeInputField;

    [SerializeField, Tooltip("Submit button for the terminal.")]
    private UnityEngine.UI.Button submitButton;

    [SerializeField, Tooltip("Feedback text for terminal interaction.")]
    private TMP_Text feedbackText;

    [SerializeField, Tooltip("Key to interact with the terminal.")]
    private KeyCode interactKey = KeyCode.F;

    [SerializeField, Tooltip("The house object to raise.")]
    private GameObject house;

    private bool isPlayerNearby = false;
    [SerializeField, Tooltip("Audio source for success sound.")]
    private AudioSource successAudioSource;

    [SerializeField, Tooltip("Audio source for failure sound.")]
    private AudioSource failureAudioSource;


    [SerializeField, Tooltip("Text object displaying the player's objective.")]
    private TMP_Text objectiveText;



    private void Start()
    {
        // Ensure UI elements are hidden at the start
        ShowTerminalUI(false);

        if (submitButton != null)
        {
            submitButton.onClick.AddListener(ValidateCode);
        }

        if (feedbackText != null)
        {
            feedbackText.text = ""; // Clear any feedback at the start
        }
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(interactKey))
        {
            ShowTerminalUI(true); // Show the terminal UI
            if (feedbackText != null)
            {
                feedbackText.text = ""; // Clear the feedback text
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;

            if (feedbackText != null)
            {
                feedbackText.gameObject.SetActive(true); // Ensure the text is visible
                feedbackText.text = "Press F to interact with the terminal.";
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;

            if (feedbackText != null)
            {
                feedbackText.text = "";
            }

            ShowTerminalUI(false); // Hide the terminal UI when the player leaves
        }
    }

    private void ValidateCode()
    {
        if (codeInputField == null || feedbackText == null) return;

        string enteredCode = codeInputField.text.Trim();

        if (enteredCode == "house.raise();")
        {
            feedbackText.text = "Code accepted! Raising the house.";
            feedbackText.color = new Color32(50, 205, 50, 255); // Bright Green (#32CD32)
            successAudioSource.Play();
            RaiseHouse();

            // Hide the objective panel if applicable
            Transform objectivePanel = objectiveText.transform.parent; // Get the parent panel
            if (objectivePanel != null)
            {
                objectivePanel.gameObject.SetActive(false);
            }
        }
        else
        {
            feedbackText.text = "Invalid command. Try again.";
            feedbackText.color = new Color32(255, 69, 0, 255); // Bright Red (#FF4500)
            failureAudioSource.Play();
        }
    }





    private void RaiseHouse()
    {
        if (house != null)
        {
            StartCoroutine(SmoothRaise());
        }
    }

    private IEnumerator SmoothRaise()
    {
        float targetHeight = house.transform.position.y + 5f;
        float speed = 2f;

        while (house.transform.position.y < targetHeight)
        {
            house.transform.position += Vector3.up * speed * Time.deltaTime;
            yield return null;
        }

        house.transform.position = new Vector3(house.transform.position.x, targetHeight, house.transform.position.z);
    }


    private void ShowTerminalUI(bool show)
    {
        if (codeInputField != null)
        {
            codeInputField.gameObject.SetActive(show);
        }

        if (submitButton != null)
        {
            submitButton.gameObject.SetActive(show);
        }

        if (feedbackText != null)
        {
            feedbackText.gameObject.SetActive(show);
        }
    }
}
