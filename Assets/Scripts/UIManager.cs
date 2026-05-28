using UnityEngine;
using UnityEngine.UIElements;
// this handles the UI such as score display and button display
public class UIManager : MonoBehaviour
{
    public UIDocument uiDucoment;

    

    private Label scoreText;
    private Button restartBtn;

    

    private void Start()
    {

       
        scoreText = uiDucoment.rootVisualElement.Q<Label>("ScoreLabel");
        restartBtn = uiDucoment.rootVisualElement.Q<Button>("RestartBtn");
        scoreText.text = "Score: 0"; 
        restartBtn.style.display = DisplayStyle.None;

        //restartBtn.style.display = DisplayStyle.Flex;
        restartBtn.clicked += RestartGame;

    }
    private void Update()
    {
        UpdateScoreText();
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


    public void RestartGame()
    {
        GameManager.Instance.ResetGame();
    }
 


}
