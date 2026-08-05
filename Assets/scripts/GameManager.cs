using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Panels")]
    [SerializeField] private GameObject gameOverPanel;

    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Make sure game runs at normal speed and panel is hidden on start
        Time.timeScale = 1f;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void TriggerGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // Open Game Over panel
        }

        Time.timeScale = 0f; // Freeze game movement and physics
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Reset game time before reloading
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadSceneByName(string sceneName)
    {
        Time.timeScale = 1f; // Reset time back to normal before switching
        SceneManager.LoadScene(sceneName);
    }
}