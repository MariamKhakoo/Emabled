using UnityEngine;
using UnityEngine.UI;

public class JobCardManager : MonoBehaviour
{
    public GameObject jobCardPrefab;
    public Transform jobCardContainer;
    public PopUpManager popUpManager; // Add this line to reference the PopUpManager

    private void OnEnable()
    {
        SwipeDetector.SwipeLeft += OnSwipeLeft;
        SwipeDetector.SwipeRight += OnSwipeRight;
    }

    private void OnDisable()
    {
        SwipeDetector.SwipeLeft -= OnSwipeLeft;
        SwipeDetector.SwipeRight -= OnSwipeRight;
    }

    void Start()
    {
        if (jobCardPrefab == null)
        {
            Debug.LogError("JobCardPrefab is not assigned in the Inspector.");
        }

        if (jobCardContainer == null)
        {
            Debug.LogError("JobCardContainer is not assigned in the Inspector.");
        }

        if (popUpManager == null)
        {
            Debug.LogError("PopUpManager is not assigned in the Inspector.");
        }

        LoadJobCards();
    }

    void LoadJobCards()
    {
        string[] jobTitles = { "Software Engineer", "Product Manager", "Data Analyst" };
        string[] companies = { "Company A", "Company B", "Company C" };
        string[] locations = { "Location A", "Location B", "Location C" };
        string[] descriptions = { "Job Description A", "Job Description B", "Job Description C" };

        for (int i = 0; i < jobTitles.Length; i++)
        {
            GameObject jobCard = Instantiate(jobCardPrefab, jobCardContainer);

            Text jobTitleText = jobCard.transform.Find("JobTitle")?.GetComponent<Text>();
            Text companyText = jobCard.transform.Find("Company")?.GetComponent<Text>();
            Text locationText = jobCard.transform.Find("Location")?.GetComponent<Text>();
            Text descriptionText = jobCard.transform.Find("Description")?.GetComponent<Text>();

            if (jobTitleText != null) jobTitleText.text = jobTitles[i];
            if (companyText != null) companyText.text = companies[i];
            if (locationText != null) locationText.text = locations[i];
            if (descriptionText != null) descriptionText.text = descriptions[i];
        }
    }

    void OnSwipeLeft()
    {
        Debug.Log("Swiped left - Job not suitable");
        // Implement logic for left swipe (not suitable)
    }

    void OnSwipeRight()
    {
        Debug.Log("Swiped right - Job suitable, trigger mini-games");
        popUpManager.ShowPopUp(); // Trigger the pop-up when swiping right
    }
}
