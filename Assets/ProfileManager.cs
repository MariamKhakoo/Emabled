using UnityEngine;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{
    public Text quizText;
    public Button[] optionButtons;

    private int currentQuizIndex = 0;
    private string[] quizzes = {
        "What is your personality type?",
        "What are your career goals?",
        "What motivates you?"
    };

    private string[,] options = {
        { "Option A", "Option B", "Option C", "Option D" },
        { "Option A", "Option B", "Option C", "Option D" },
        { "Option A", "Option B", "Option C", "Option D" }
    };

    void Start()
    {
        LoadQuiz();
        foreach (Button button in optionButtons)
        {
            button.onClick.AddListener(() => OnOptionSelected(button));
        }
    }

    void LoadQuiz()
    {
        if (currentQuizIndex < quizzes.Length)
        {
            quizText.text = quizzes[currentQuizIndex];
            for (int i = 0; i < optionButtons.Length; i++)
            {
                optionButtons[i].GetComponentInChildren<Text>().text = options[currentQuizIndex, i];
            }
        }
        else
        {
            // End of the profile development
            quizText.text = "Profile Development Completed!";
            foreach (Button button in optionButtons)
            {
                button.gameObject.SetActive(false);
            }
        }
    }

    void OnOptionSelected(Button selectedButton)
    {
        // Handle option selection logic here
        currentQuizIndex++;
        LoadQuiz();
    }
}
