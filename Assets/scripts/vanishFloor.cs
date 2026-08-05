using UnityEngine;

public class vanishFloor : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float vanishDelay = 5f; // Set to 5 seconds
    [SerializeField] private bool destroyObject = false; // Set true to destroy entirely, false to just hide

    private void Start()
    {
        // Start the timer as soon as the game object initializes
        Invoke(nameof(Vanish), vanishDelay);
    }

    private void Vanish()
    {
        if (destroyObject)
        {
            Destroy(gameObject); // Permanently destroys the platform
        }
        else
        {
            gameObject.SetActive(false); // Disables the object (can be re-enabled later)
        }
    }
}