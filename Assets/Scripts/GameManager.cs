using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    private float elapsedTime;
    private float score;
    [SerializeField]
    private float scoreMultiplier = 10f;

    public bool isGameActive;

    public static GameManager Instance;

    public UIManager uiManager;


    private void Awake()
    {
        // If another GameManager already exists, destroy this one
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set this as the main instance
        Instance = this;

        // Optional: persist between scenes
        DontDestroyOnLoad(gameObject);
    }


    private void Start()
    {
        isGameActive = true;
    }

    void Update()
    {
        UpdateScore();
    }
    // This handles the Scoring, Game flow and Timer

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public void GameStart()
    {
        isGameActive = true;

    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateScore()
    {
        if (isGameActive)
        {
            elapsedTime += Time.deltaTime;
            score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);
            Debug.Log("Score: " + Mathf.FloorToInt(score));
        }

        
    }

    public float GetScore()
    {
        return score;
    }

    public void GameOver()
    {
        isGameActive = false;
        uiManager.ShowRestartBtn();
    }



}
