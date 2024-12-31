using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneManager : MonoBehaviour
{
    [SerializeField, Tooltip("Duration of the intro in seconds.")]
    private float introDuration = 30f;

    private float timer;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buttonClickSound;
    [SerializeField] private AudioClip transitionSound;

    public void SkipIntro()
    {
        audioSource.PlayOneShot(buttonClickSound);
        LoadMainScene();
    }

    private void LoadMainScene()
    {
        audioSource.PlayOneShot(transitionSound);
        SceneManager.LoadScene("ByteBreakersScene");
    }


    private void Start()
    {
        timer = introDuration;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            LoadMainScene();
        }
    }
}
