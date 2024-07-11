using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopUpManager : MonoBehaviour
{
    public GameObject popUpPanel;
    public Button startGameButton;

    void Start()
    {
        // Ensure the pop-up panel is hidden at the start
        popUpPanel.SetActive(false);

        // Add listener to the start game button
        startGameButton.onClick.AddListener(OnStartGameButtonClicked);
    }

    public void ShowPopUp()
    {
        // Show the pop-up panel
        popUpPanel.SetActive(true);
    }

    void OnStartGameButtonClicked()
    {
        // Load the mini-game scene (replace "MiniGameScene" with your actual mini-game scene name)
        SceneManager.LoadScene("MiniGameScene");
    }
}
