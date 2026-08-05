using UnityEngine;

public class spikes : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float distance = 3f;  // How far it moves left and right from starting point
    [SerializeField] private float speed = 2f;     // How fast it moves

    private Vector3 startPosition;

    void Start()
    {
        // Remember where the obstacle was initially placed in the scene
        startPosition = transform.position;
    }

    void Update()
    {
        // Mathf.PingPong calculates a value that oscillates smoothly between 0 and distance
        float offset = Mathf.PingPong(Time.time * speed, distance);

        // Calculate offset centered around starting position (-distance/2 to +distance/2)
        float xOffset = offset - (distance / 2f);

        // Update position on the X axis
        transform.position = new Vector3(startPosition.x + xOffset, startPosition.y, startPosition.z);
    }
}