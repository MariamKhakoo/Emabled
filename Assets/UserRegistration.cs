using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserRegistration : MonoBehaviour
{
    public InputField nameInput;
    public InputField emailInput;
    public InputField addressInput;
    public InputField jobLocationInput;
    public Dropdown jobPreferencesDropdown;
    public Dropdown disabilityTypeDropdown;
    public Button nextButton;
    public Text errorMessage;

    void Start()
    {
        // Debug logs
        Debug.Log(nameInput != null ? "NameInput assigned" : "NameInput not assigned");
        Debug.Log(emailInput != null ? "EmailInput assigned" : "EmailInput not assigned");
        Debug.Log(addressInput != null ? "AddressInput assigned" : "AddressInput not assigned");
        Debug.Log(jobLocationInput != null ? "JobLocationInput assigned" : "JobLocationInput not assigned");
        Debug.Log(jobPreferencesDropdown != null ? "JobPreferencesDropdown assigned" : "JobPreferencesDropdown not assigned");
        Debug.Log(disabilityTypeDropdown != null ? "DisabilityTypeDropdown assigned" : "DisabilityTypeDropdown not assigned");
        Debug.Log(nextButton != null ? "NextButton assigned" : "NextButton not assigned");
        Debug.Log(errorMessage != null ? "ErrorMessage assigned" : "ErrorMessage not assigned");

        // Add listener for "Next" button
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(OnNextButtonClicked);
        }
    }

    void OnNextButtonClicked()
    {
        // Validate inputs
        if (ValidateInputs())
        {
            // Save user data
            SaveUserData();

            // Load the Job Matching Screen
            SceneManager.LoadScene("JobMatchingScreen");
        }
        else
        {
            if (errorMessage != null)
            {
                // Show error message
                errorMessage.text = "Please fill in all fields correctly.";
            }
        }
    }

    bool ValidateInputs()
    {
        // Check if any input field is empty
        if (string.IsNullOrEmpty(nameInput.text) || string.IsNullOrEmpty(emailInput.text) ||
            string.IsNullOrEmpty(addressInput.text) || string.IsNullOrEmpty(jobLocationInput.text) ||
            jobPreferencesDropdown.value == 0 || disabilityTypeDropdown.value == 0)
        {
            return false;
        }

        // Additional validation for email format can be added here

        return true;
    }

    void SaveUserData()
    {
        // Save user data to PlayerPrefs or a backend database
        PlayerPrefs.SetString("Name", nameInput.text);
        PlayerPrefs.SetString("Email", emailInput.text);
        PlayerPrefs.SetString("Address", addressInput.text);
        PlayerPrefs.SetString("JobLocation", jobLocationInput.text);
        PlayerPrefs.SetString("JobPreferences", jobPreferencesDropdown.options[jobPreferencesDropdown.value].text);
        PlayerPrefs.SetString("DisabilityType", disabilityTypeDropdown.options[disabilityTypeDropdown.value].text);
    }
}
