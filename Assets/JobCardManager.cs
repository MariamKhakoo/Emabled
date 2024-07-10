using UnityEngine;
using UnityEngine.UI;

public class JobCardManager : MonoBehaviour
{
    public GameObject jobCardPrefab;
    public Transform jobCardContainer;

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
            return;
        }

        if (jobCardContainer == null)
        {
            Debug.LogError("JobCardContainer is not assigned in the Inspector.");
            return;
        }

        LoadJobCards();
    }

    void LoadJobCards()
    {
        // Example job data - replace with your actual job data source
        string[] jobTitles = { "Software Engineer", "Product Manager", "Data Analyst" };
        string[] companies = { "Company A", "Company B", "Company C" };
        string[] locations = { "Location A", "Location B", "Location C" };
        string[] descriptions = { "Job Description A", "Job Description B", "Job Description C" };

        for (int i = 0; i < jobTitles.Length; i++)
        {
            Debug.Log("Instantiating job card for: " + jobTitles[i]);
            GameObject jobCard = Instantiate(jobCardPrefab, jobCardContainer);
            if (jobCard == null)
            {
                Debug.LogError("Failed to instantiate job card.");
                continue;
            }
            Debug.Log("Job card instantiated");

            Transform jobTitleTransform = jobCard.transform.Find("JobTitle");
            Transform companyTransform = jobCard.transform.Find("Company");
            Transform locationTransform = jobCard.transform.Find("Location");
            Transform descriptionTransform = jobCard.transform.Find("Description");

            if (jobTitleTransform == null || companyTransform == null || locationTransform == null || descriptionTransform == null)
            {
                Debug.LogError("One or more text components are missing in the job card prefab.");
                continue;
            }

            Text jobTitleText = jobTitleTransform.GetComponent<Text>();
            Text companyText = companyTransform.GetComponent<Text>();
            Text locationText = locationTransform.GetComponent<Text>();
            Text descriptionText = descriptionTransform.GetComponent<Text>();

            if (jobTitleText != null) jobTitleText.text = jobTitles[i];
            if (companyText != null) companyText.text = companies[i];
            if (locationText != null) locationText.text = locations[i];
            if (descriptionText != null) descriptionText.text = descriptions[i];

            Debug.Log("Job card details set for: " + jobTitles[i]);
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
        // Implement logic for right swipe (suitable), e.g., trigger a pop-up for mini-games
    }
}
