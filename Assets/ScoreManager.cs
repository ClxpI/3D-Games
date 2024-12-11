using TMPro; // Add this at the top to use TextMeshPro
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; // TextMeshPro reference
    private int score = 0;

    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public void IncreaseScore()
    {
        score++;  // Increase score by 1
    }
}
