using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject noticePanel;

    // 1. Open Notice/Rules Panel
    public void OpenPanel()
    {
        if (noticePanel != null)
        {
            noticePanel.SetActive(true);
        }
    }

    // 2. Close Notice/Rules Panel
    public void ClosePanel()
    {
        if (noticePanel != null)
        {
            noticePanel.SetActive(false);
        }
    }

    // 3. Switch Scene
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f; // Ensure time is unpaused
        SceneManager.LoadScene(sceneName);
    }

    // 4. Quit Game
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}