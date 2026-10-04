using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 12f;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Text winLoseText;
    public Image winLoseBG;
    private int score = 0;

    private Rigidbody rb;
    // Stops the reload coroutine from starting again every frame.
    private bool reloading = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetScoreText();
        SetHealthText();
    }

    void Update()
    {
        if (health == 0 && !reloading)
        {
            // Debug.Log("Game Over!");
            winLoseText.text = "Game Over!";
            winLoseText.color = Color.white;
            winLoseBG.color = Color.red;
            winLoseBG.gameObject.SetActive(true);
            reloading = true;
            StartCoroutine(LoadScene(3));
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        // Reloading the scene also resets health and score.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Touch controls: hold a finger on the screen to roll toward it,
        // relative to the screen center. Screen up is forward in the maze.
        if (Input.touchCount > 0)
        {
            Vector2 center = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Vector2 direction = Input.GetTouch(0).position - center;
            // Full strength once the finger is a quarter screen away from the center.
            direction /= Screen.height / 4f;
            direction = Vector2.ClampMagnitude(direction, 1f);
            moveHorizontal = direction.x;
            moveVertical = direction.y;
        }

        // Only X and Z, so the Player can't jump.
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score++;
            // Debug.Log("Score: " + score);
            SetScoreText();
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Trap"))
        {
            health--;
            // Debug.Log("Health: " + health);
            SetHealthText();
        }

        if (other.CompareTag("Goal"))
        {
            // Debug.Log("You win!");
            winLoseText.text = "You Win!";
            winLoseText.color = Color.black;
            winLoseBG.color = Color.green;
            winLoseBG.gameObject.SetActive(true);
            if (!reloading)
            {
                reloading = true;
                StartCoroutine(LoadScene(3));
            }
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }
}
