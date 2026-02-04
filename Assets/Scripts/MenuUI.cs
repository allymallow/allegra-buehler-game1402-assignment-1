using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        if (playButton != null) playButton.onClick.AddListener(OnPlayPressed);
        if (restartButton != null) restartButton.onClick.AddListener(OnRestartPressed);
        if (quitButton != null) quitButton.onClick.AddListener(OnQuitPressed);
    }

    //when pressing the start button, switch to the main game scene
    private void OnPlayPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    //switch back to the main menu when player presses "Restart"
    private void OnRestartPressed()
    {
        SceneManager.LoadScene("Main Menu");
    }
    
    //Close the game when pressing quit
    private void OnQuitPressed()
    {
        Application.Quit();
    }
}