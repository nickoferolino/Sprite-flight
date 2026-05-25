using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public float minSize = 0.5f;
    public float maxSize = 2f;
    public float minSpeed = 50f;
    public float maxSpeed = 100f;
    public float rotationSpeed = 5f;
    private float randomSize;
    private Rigidbody2D rb;

    // set random size and random rotation
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        SetRandomSize();
        Move();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetRandomSize()
    {
        randomSize = Random.Range(minSize, maxSize);
        transform.localScale = Vector2.one * randomSize;
    }

    void Move()
    {
        float randomRotation = Random.Range(-rotationSpeed, rotationSpeed);
        rb.AddTorque(randomRotation);

        float forceValue = Random.Range(minSpeed, maxSpeed) / randomSize;

        Vector2 direction = Random.insideUnitCircle.normalized;

        rb.AddForce(direction * forceValue, ForceMode2D.Impulse);
    }
}
