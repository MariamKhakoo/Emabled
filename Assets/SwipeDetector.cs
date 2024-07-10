using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;

    public float swipeRange;
    public float tapRange;

    public delegate void OnSwipeLeft();
    public static event OnSwipeLeft SwipeLeft;

    public delegate void OnSwipeRight();
    public static event OnSwipeRight SwipeRight;

    void Update()
    {
        Swipe();
    }

    public void Swipe()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startTouchPosition = Input.touches[0].position;
        }

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved)
        {
            currentTouchPosition = Input.touches[0].position;
            Vector2 distance = currentTouchPosition - startTouchPosition;

            if (!stopTouch)
            {
                if (distance.x < -swipeRange)
                {
                    stopTouch = true;
                    SwipeLeft?.Invoke();
                }
                else if (distance.x > swipeRange)
                {
                    stopTouch = true;
                    SwipeRight?.Invoke();
                }
            }
        }

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            stopTouch = false;
            endTouchPosition = Input.touches[0].position;
            Vector2 distance = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(distance.x) < tapRange && Mathf.Abs(distance.y) < tapRange)
            {
                // Tap
            }
        }
    }
}
