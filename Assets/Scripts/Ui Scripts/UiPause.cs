using UnityEngine;
using UnityEngine.UI;

public class UiPause : MonoBehaviour
{
    [SerializeField] Button pausePlayAgainButton;
    [SerializeField] Button pauseSettingsButton;
    [SerializeField] Button pauseMainMenuButton;

    private void Start() 
    {
        pausePlayAgainButton.onClick.AddListener(UiManager.instance.StartNewGame);
        pauseSettingsButton.onClick.AddListener(UiManager.instance.OpenSettings);
        pauseMainMenuButton.onClick.AddListener(UiManager.instance.BackToMainMenu);
    }
}
