using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 20;

    public float jumpForce;

    public bool Grounded = true;

    public TMP_Text coinsText;
    
    public int coinsCollected = 0;

    public int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Grounded)
        {
            rb.AddForce(Vector2.up * jumpForce);
            Grounded = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * speed);
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        Grounded = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Collectable>())
        {
            coinsCollected--;    
            coinsText.text = coinsCollected.ToString();
        }
        
        else if (other.GetComponent<Hazard>())
        {
            currentHealth--;
            healthText.text = currentHealth.ToString();
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    
    
}
