using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScreenManager : MonoBehaviour
{
    public void StartNewResume()
    {
        // Load the scene for creating a new resume
        SceneManager.LoadScene("NewResumeScene"); // Make sure you have a scene named NewResumeScene
    }

    public void LoadExistingResume()
    {
        // Load the scene for loading an existing resume
        SceneManager.LoadScene("LoadResumeScene"); // Make sure you have a scene named LoadResumeScene
    }
}
