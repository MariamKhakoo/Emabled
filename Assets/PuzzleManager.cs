using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public Text instructionsText;
    public Button[] puzzleButtons;
    private Button firstSelectedButton;
    private Button secondSelectedButton;

    private string[] puzzlePairs = { "Skill A", "Skill B", "Skill C", "Role A", "Role B", "Role C" };

    void Start()
    {
        ShufflePairs();
        for (int i = 0; i < puzzleButtons.Length; i++)
        {
            puzzleButtons[i].GetComponentInChildren<Text>().text = puzzlePairs[i];
            puzzleButtons[i].onClick.AddListener(() => OnButtonClicked(puzzleButtons[i]));
        }
    }

    void ShufflePairs()
    {
        for (int i = 0; i < puzzlePairs.Length; i++)
        {
            string temp = puzzlePairs[i];
            int randomIndex = Random.Range(0, puzzlePairs.Length);
            puzzlePairs[i] = puzzlePairs[randomIndex];
            puzzlePairs[randomIndex] = temp;
        }
    }

    void OnButtonClicked(Button clickedButton)
    {
        if (firstSelectedButton == null)
        {
            firstSelectedButton = clickedButton;
        }
        else if (secondSelectedButton == null && clickedButton != firstSelectedButton)
        {
            secondSelectedButton = clickedButton;
            CheckMatch();
        }
    }

    void CheckMatch()
    {
        if (firstSelectedButton.GetComponentInChildren<Text>().text == secondSelectedButton.GetComponentInChildren<Text>().text)
        {
            Debug.Log("Match Found!");
            firstSelectedButton.interactable = false;
            secondSelectedButton.interactable = false;
        }
        else
        {
            Debug.Log("No Match.");
        }

        firstSelectedButton = null;
        secondSelectedButton = null;
    }
}
