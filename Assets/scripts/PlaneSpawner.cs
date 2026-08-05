using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    public GameObject movingPlane;
    public float spawnRate = 2;
    private float timer = 0;
    public float widthOffset = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnFloor();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnFloor();
            timer = 0;

        }
    }

    void spawnFloor()
    {
        float lowestPoint = transform.position.x - widthOffset;
        float highestPoint = transform.position.x + widthOffset;


        Instantiate(movingPlane, new Vector3(Random.Range(lowestPoint, highestPoint), transform.position.y, 0), transform.rotation);

    }
}
