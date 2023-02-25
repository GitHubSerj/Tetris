using UnityEngine;
using UnityEngine.UI;

public class UiMenu : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button leaderboardButton;

    void Start() 
    {
        playButton.onClick.AddListener(UiManager.instance.StartNewGame);
        optionsButton.onClick.AddListener(UiManager.instance.OpenSettings);
        quitButton.onClick.AddListener(UiManager.instance.Quit);
        leaderboardButton.onClick.AddListener(UiManager.instance.OpenLeaderboard);
    }
}
