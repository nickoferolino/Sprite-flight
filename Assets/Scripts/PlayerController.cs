using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class PlayerController : MonoBehaviour
{


    public float thrustStrength = 1f;
    public float maxSpeed = 5f; 
    private Rigidbody2D rb;


    public GameObject thruster;
    public GameObject explosionParticle;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {


        Move();


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collided with Obstacle!");

            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, transform.rotation);
            GameManager.Instance.GameOver();
            // Destroy the player object on collision with an obstacle.
            // You can add additional logic here, such as reducing health or playing a sound effect.
        }
    }

    void Move()
    {

        if (GameManager.Instance.isGameActive)
        {
            if (Mouse.current.leftButton.isPressed)
            {
                //it gets the mouse position in the world
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
                Vector2 direction = (mouseWorldPos - transform.position).normalized;

                //Moves player toward the mouse position when clicked
                transform.up = direction;

                rb.AddForce(direction * thrustStrength, ForceMode2D.Impulse);

                if (rb.linearVelocity.magnitude > maxSpeed)
                {
                    rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
                }

            }

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Debug.Log("Mouse button pressed!");
                thruster.SetActive(true);
            }
            else if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                Debug.Log("Mouse button released!");
                thruster.SetActive(false);
            }
        }
        
    }




}
