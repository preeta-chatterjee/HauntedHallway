using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI messageText;
    public GameObject restartButton;
    private bool gameOver = false;

    void Awake()
    {
        Instance = this;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void WinGame()
    {
        if (gameOver) return;
        gameOver = true;
        if (messageText != null)
        {
            messageText.text = "You Escaped!";
            messageText.color = Color.green;
        }
        if (restartButton != null)
            restartButton.SetActive(true);
    }

    public void LoseGame()
    {
        if (gameOver) return;
        gameOver = true;
        if (messageText != null)
        {
            messageText.text = "The zombie got you...";
            messageText.color = Color.red;
        }
        if (restartButton != null)
            restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}