using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class PauseGame : MonoBehaviour
{
    private Button pauseButton;

    private void OnEnable()
    {
        pauseButton = GetComponent<Button>();
        if (pauseButton != null)
        {
            pauseButton.onClick.AddListener(GoToMainMenu);
        }
        else
        {
            Debug.LogError("PauseGame: No Button component found.");
        }
    }

    private void OnDisable()
    {
        if (pauseButton != null)
        {
            pauseButton.onClick.RemoveListener(GoToMainMenu);
        }
    }

    private void GoToMainMenu()
    {
        Debug.Log("Returning to Main Menu...");
        Time.timeScale = 1f; // Make sure the game is not paused
        SceneManager.LoadScene("MainMenu"); // Use your exact scene name here
    }
}
