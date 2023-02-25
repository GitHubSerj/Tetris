using UnityEngine;
using UnityEngine.UI;

public class UiGameOver : MonoBehaviour
{
    [SerializeField] Image fadePlane;
    [SerializeField] Button gameOverPlayAgainButton;
    [SerializeField] Button gameOverMainMenuButton;
    [SerializeField] Button gameOverSaveScoreButton;
    [SerializeField] Text gameOverScore;

    public Image FadePlane => fadePlane;

    public void OnGameOver()
    {
        gameOverScore.text = "Score: " + ScoreKeeper.score;
    }

    void Start()
    {
        gameOverPlayAgainButton.onClick.AddListener(UiManager.instance.StartNewGame);
        gameOverMainMenuButton.onClick.AddListener(UiManager.instance.BackToMainMenu);
        gameOverSaveScoreButton.onClick.AddListener(UiManager.instance.OpenPlayerAdder);
    }
}
