using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    public float speed;   // Speed of the background movement
    public GameObject background2;  // Reference to the second background
    private Vector3 startPosition1;
    private Vector3 nextPos;
    public float width;

    void Start()
    {
        startPosition1 = transform.position;
    }

    void Update()
    {
        // Move both backgrounds to the right
        transform.position += Vector3.right * speed * Time.deltaTime;
        background2.transform.position += Vector3.right * speed * Time.deltaTime;

        // If the first background moves off-screen, reset its position
        if (transform.position.x > startPosition1.x + width)  // Adjust the '10f' based on your background width
        {
            nextPos = background2.transform.position;
            nextPos.x -= width;
            transform.position = nextPos;  // Place it just to the left of the second background
        }

        // If the second background moves off-screen, reset its position
        if (background2.transform.position.x > startPosition1.x + width)  // Adjust the '10f' based on your background width
        {
            nextPos = transform.position;
            nextPos.x -= width;
            background2.transform.position = nextPos;  // Place it just to the left of the first background
        }
    }
}