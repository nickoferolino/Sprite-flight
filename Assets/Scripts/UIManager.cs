using UnityEngine;
using UnityEngine.UIElements;
// this handles the UI such as score display and button display
public class UIManager : MonoBehaviour
{
    public UIDocument uiDucoment;
    private VisualElement root;

    private VisualElement startScreen;

    private VisualElement gameplayScreen;

    private VisualElement resultScreen;

    private Label scoreText;
    private Button startBtn;
    private Button restartBtn;

    private void Start()
    {

        root = uiDucoment.rootVisualElement;

        startScreen = root.Q("StartScreenContainer");
        gameplayScreen = root.Q("GamePlayScreenContainer");
        resultScreen = root.Q("ResultScreenContainer");

        startBtn = root.Q<Button>("StartBtn");
        restartBtn = root.Q<Button>("RestartBtn");
        scoreText = root.Q<Label>("ScoreText");


        scoreText.text = "Score: 0";


        startScreen.style.display = DisplayStyle.None;
        gameplayScreen.style.display = DisplayStyle.None;
        resultScreen.style.display = DisplayStyle.None;


        ShowScreen(startScreen);

        startBtn.clicked += GameManager.Instance.GameStart;
        restartBtn.clicked += GameManager.Instance.ResetGame;

    }
    private void Update()
    {
        UpdateScoreText();
    }
    void ShowScreen(VisualElement screenToShow)
    {
        startScreen.style.display = DisplayStyle.None;
        gameplayScreen.style.display = DisplayStyle.None;
        resultScreen.style.display = DisplayStyle.None;

        screenToShow.style.display = DisplayStyle.Flex;
    }


    public void ShowRestartBtn()
    {
        restartBtn.style.display = DisplayStyle.Flex;
    }



    public void UpdateScoreText()
    {
        int score = Mathf.FloorToInt(GameManager.Instance.GetScore());

        scoreText.text = "Score: " + score;


    }


 


    public void ShowGamePlayScreen()
    {
        //Show the Counting Score
        // Show the HighScore on top right side

    }

    public void ShowEndScreen()
    {
        // Show score
        // High score
        // Restart btn
    }

}
