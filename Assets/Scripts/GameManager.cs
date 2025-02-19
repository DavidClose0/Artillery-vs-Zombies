using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance
    public TextMeshProUGUI scoreText;
    public GameObject gameOverUI;
    public int score = 0;
    public bool gameHasEnded = false;

    void Awake()
    {
        // Singleton initialization
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }
    
    void Update()
    {
        scoreText.text = "Score: " + score;
        if (gameHasEnded && Input.GetKey("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameOverUI.SetActive(true);
            gameHasEnded = true;
        }
    }
}