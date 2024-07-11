using UnityEngine;
using UnityEngine.UI;

public class QuizupManager : MonoBehaviour
{
    public Text questionText;
    public Button[] optionButtons;

    private int currentQuestionIndex = 0;
    private string[] questions = {
        "What was your previous job role?",
        "Which company did you work for?",
        "What was your main responsibility?"
    };

    private string[,] options = {
        { "Developer", "Designer", "Manager", "Tester" },
        { "Company A", "Company B", "Company C", "Company D" },
        { "Coding", "Designing", "Managing", "Testing" }
    };

    private int[] correctAnswers = { 0, 1, 2 };

    void Start()
    {
        LoadQuestion();
        foreach (Button button in optionButtons)
        {
            button.onClick.AddListener(() => OnOptionSelected(button));
        }
    }

    void LoadQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            questionText.text = questions[currentQuestionIndex];
            for (int i = 0; i < optionButtons.Length; i++)
            {
                optionButtons[i].GetComponentInChildren<Text>().text = options[currentQuestionIndex, i];
            }
        }
        else
        {
            // End of the quiz
            questionText.text = "Quiz Completed!";
            foreach (Button button in optionButtons)
            {
                button.gameObject.SetActive(false);
            }
        }
    }

    void OnOptionSelected(Button selectedButton)
    {
        int selectedIndex = System.Array.IndexOf(optionButtons, selectedButton);
        if (selectedIndex == correctAnswers[currentQuestionIndex])
        {
            Debug.Log("Correct Answer");
        }
        else
        {
            Debug.Log("Wrong Answer");
        }

        currentQuestionIndex++;
        LoadQuestion();
    }
}
