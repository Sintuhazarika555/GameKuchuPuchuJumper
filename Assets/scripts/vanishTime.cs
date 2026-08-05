using TMPro;
using UnityEngine;

public class vanishTime : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float countdownTime = 5f;
    [SerializeField] private bool destroyObject = false; // Set true to destroy entirely, false to just hide

    [Header("UI Reference")]
    [SerializeField] private TMP_Text countdownText; // Drag your TextMeshPro component here

    private float _timeRemaining;
    private bool _isCounting = true;

    private void Start()
    {
        _timeRemaining = countdownTime;
    }

    private void Update()
    {
        if (!_isCounting) return;

        if (_timeRemaining > 0)
        {
            _timeRemaining -= Time.deltaTime;
            UpdateDisplay(_timeRemaining);
        }
        else
        {
            _timeRemaining = 0;
            _isCounting = false;
            UpdateDisplay(0);
            Vanish();
        }
    }

    private void UpdateDisplay(float timeToDisplay)
    {
        if (countdownText != null)
        {
            // Displays whole seconds: "5", "4", "3", etc.
            int seconds = Mathf.CeilToInt(timeToDisplay);
            countdownText.text = seconds.ToString();
        }
    }

    private void Vanish()
    {
        if (destroyObject)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
