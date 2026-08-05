using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    [Header("UI Reference")]
    [SerializeField] private TMP_Text counter; // Drag your TextMeshPro UI text here



    private float _currentTime = 0f;
    private bool _isRunning = true; // Starts automatically when game begins

    private void Start()
    {
        _currentTime = 0f;
        _isRunning = true;
    }

    private void Update()
    {
        if (!_isRunning) return;

        // Add elapsed frame time
        _currentTime += Time.deltaTime;

        // Display updated time
        UpdateDisplay(_currentTime);
    }

    private void UpdateDisplay(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        if (counter != null)
        {

            // Format: 01:23 (Minutes:Seconds)
            counter.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        }
    }

    
}