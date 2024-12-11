using UnityEngine;
using TMPro;  // Add this for TextMeshPro

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float horizontalSpeed = 10f;
    public TMP_Text gameOverText;  // Reference to the TMP text to show "Game Over"

    void Update()
    {
        // Forward movement
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * horizontalSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if player hit an obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Time.timeScale = 0;  // Pauses the game
        gameOverText.text = "Crashed\r\nGame Over!";  // Display "Game Over" message
        gameOverText.gameObject.SetActive(true);  // Make sure the text is visible
    }
}
