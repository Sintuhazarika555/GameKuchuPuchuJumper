using UnityEngine;

public class Prefab : MonoBehaviour
{
    public float moveSpeed = 1;
    public float deadZone = -7;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.down * moveSpeed) * Time.deltaTime;
        if (transform.position.y < deadZone)
        {
            Debug.Log("floorDeleted");
            Destroy(gameObject);
        }
    }
}
