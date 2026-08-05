using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseManager : MonoBehaviour
{
    [Header("UI Reference")]
    [SerializeField] private GameObject pausePanel;

    private bool isPaused = false;

    private void Start()
    {
        // Ensure panel is hidden and time is running when scene starts
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
        Time.timeScale = 1f;
    }

    // 1. Pause the Game (Called by top PAUSE button)
    public void PauseGame()
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(true);
        }
        Time.timeScale = 0f; // Freeze game physics and timers
        isPaused = true;
    }

    // 2. Resume the Game (Called by RESUME button)
    public void ResumeGame()
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
        Time.timeScale = 1f; // Unfreeze game
        isPaused = false;
    }

    // 3. Replay / Restart Current Level (Called by REPLAY button)
    public void ReplayGame()
    {
        Time.timeScale = 1f; // Always unfreeze before reloading
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // 4. Go Back to Main Menu (Called by EXIT GAME button)
    public void GoToMainMenu(string mainMenuSceneName)
    {
        Time.timeScale = 1f; // Always unfreeze before leaving scene
        SceneManager.LoadScene(mainMenuSceneName);
    }
}