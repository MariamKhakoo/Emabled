using UnityEngine;
using UnityEngine.UI;

public class FormManager : MonoBehaviour
{
    public InputField schoolNameInput;
    public InputField degreeInput;
    public InputField majorInput;
    public InputField graduationYearInput;
    public Button submitButton;

    void Start()
    {
        submitButton.onClick.AddListener(OnSubmitButtonClicked);
    }

    void OnSubmitButtonClicked()
    {
        string schoolName = schoolNameInput.text;
        string degree = degreeInput.text;
        string major = majorInput.text;
        string graduationYear = graduationYearInput.text;

        // Handle form submission logic here
        Debug.Log($"School: {schoolName}, Degree: {degree}, Major: {major}, Year: {graduationYear}");
    }
}
