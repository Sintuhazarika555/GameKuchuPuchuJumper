using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class sound : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private AudioClip clickSound;

    private AudioSource audioSource;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();

        // Find or create an AudioSource on the camera or locally
        audioSource = Camera.main != null ? Camera.main.GetComponent<AudioSource>() : null;

        if (audioSource == null)
        {
            // Fallback: create a temporary AudioSource
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }

        // Automatically listen to button click without manually wiring OnClick in Inspector!
        button.onClick.AddListener(PlaySound);
    }

    public void PlaySound()
    {
        if (clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}