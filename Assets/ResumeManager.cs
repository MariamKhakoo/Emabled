using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class ResumeManager : MonoBehaviour
{
    public Text resumeText;
    public InputField editResumeInput;
    public Button editResumeButton;
    public Button saveResumeButton;
    public ResumeData resumeData; // Reference to the ScriptableObject

    private StringBuilder compiledResume;

    void Start()
    {
        compiledResume = new StringBuilder();

        // Retrieve data from the ScriptableObject
        compiledResume.AppendLine("Name: " + resumeData.name);
        compiledResume.AppendLine("Education: " + resumeData.education);
        compiledResume.AppendLine("Experience: " + resumeData.experience);
        compiledResume.AppendLine("Skills: " + resumeData.skills);
        compiledResume.AppendLine("Languages: " + resumeData.languages);
        compiledResume.AppendLine("Profile: " + resumeData.profile);

        resumeText.text = compiledResume.ToString();

        editResumeButton.onClick.AddListener(OnEditResumeButtonClicked);
        saveResumeButton.onClick.AddListener(OnSaveResumeButtonClicked);
    }

    void OnEditResumeButtonClicked()
    {
        editResumeInput.gameObject.SetActive(true);
        editResumeInput.text = resumeText.text;
        resumeText.gameObject.SetActive(false);
        editResumeButton.gameObject.SetActive(false);
    }

    void OnSaveResumeButtonClicked()
    {
        compiledResume.Clear();
        compiledResume.Append(editResumeInput.text);

        resumeText.text = compiledResume.ToString();
        resumeText.gameObject.SetActive(true);
        editResumeInput.gameObject.SetActive(false);
        editResumeButton.gameObject.SetActive(true);

        // Save the resume (this example just logs it, but you could save to a file or database)
        Debug.Log("Resume saved: " + compiledResume.ToString());
    }
}
