using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    [SerializeField] private GameObject NoticePanel;

    private void Awake()
    {
        // Singleton Pattern: Ensures only one instance exists across scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Keeps EventManager alive across scene changes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // --- SCENE SWITCHING METHODS --

    public void LoadSceneByName(string sceneName)
    {
        Time.timeScale = 1f; // Reset time in case the game was paused
        SceneManager.LoadScene(sceneName);
    }

    //NOTICEPANEL
    public void TriggerNotice()
    {
        if (NoticePanel != null)
        {
            NoticePanel.SetActive(true); // Open Game Over panel
        }

        Time.timeScale = 0f; // Freeze game movement and physics
    }


    // --- APPLICATION QUIT METHOD ---

    public void GameOver()
    {
        Debug.Log("Game Over button clicked!");

        // 1. Quits the built application (.exe, .apk, etc.)
        Application.Quit();

        // 2. Stops Play Mode if you are running inside the Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
