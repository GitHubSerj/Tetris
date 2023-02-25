using UnityEngine;
using DG.Tweening;

public class UiManager : MonoBehaviour
{
    [SerializeField] UiMenu uiMenu;
    [SerializeField] UiGameplay uiGameplay;
    [SerializeField] UiSettings uiSettings;
    [SerializeField] UiPause uiPause;
    [SerializeField] UiGameOver uiGameOver;
    [SerializeField] UiLeaderboard uiLeaderboard;
    [SerializeField] UiPlayerAdder uiPlayerAdder;

    public Ui currentUi {get; private set; }
    public Ui lastUi {get; private set; }
    
    public static UiManager instance;

    public void StartNewGame()
    {
        SetTimeMove();

        ActivateUi(uiGameplay.gameObject);
        currentUi = Ui.uiGameplay;

        if (lastUi == Ui.uiMenu)
        {
            EventController.GameStart?.Invoke();
        }
        else if(lastUi == Ui.uiGameOver || lastUi == Ui.uiPause)
        {
            EventController.GameRestart?.Invoke();
        }
    }
    public void BackToMainMenu()
    {
        SetTimeMove();

        ActivateUi(uiMenu.gameObject);
        currentUi = Ui.uiMenu;
        if (AudioManager.instance.CurrentAudioClip != MusicManager.instance.MenuTheme)
        {
            EventController.SwitchMusicInBackMenu?.Invoke();
        }
        EventController.BackToMenuFromGameplay?.Invoke();
    }
    public void PauseGame()
    {
        ActivateUi(uiGameplay.gameObject, uiPause.gameObject);
        currentUi = Ui.uiPause;
        SetTimeStop();
    }
    public void UnpauseGame()
    {
        SetTimeMove();

        ActivateUi(uiGameplay.gameObject);
        currentUi = Ui.uiGameplay;
    }
    public void BackOfSettings()
    {
        if (lastUi == Ui.uiPause)
        {
            ActivateUi( uiPause.gameObject, uiGameplay.gameObject);
            currentUi = Ui.uiPause;
        }
        else if(lastUi == Ui.uiMenu)
        {
            ActivateUi(uiMenu.gameObject);
            currentUi = Ui.uiMenu;
        }
    }
    public void OpenPlayerAdder()
    {
        ActivateUi(uiPlayerAdder.gameObject);
        currentUi = Ui.uiPlayerAdder;
    }
    public void OpenLeaderboard()
    {
        ActivateUi(uiLeaderboard.gameObject);
        currentUi = Ui.uiLeaderboard;
        EventController.LeaderboardOpening?.Invoke();
    }
    public void BackGameOver()
    {
        ActivateUi(uiGameOver.gameObject);
        currentUi = Ui.uiGameOver;
    }
    public void OpenSettings()
    {
        
        if (currentUi == Ui.uiPause)
        {
            ActivateUi(uiSettings.gameObject, uiGameplay.gameObject);
            uiSettings.Fade.SetActive(true);
            uiSettings.MenuBackground.SetActive(false);
            currentUi = Ui.uiSettings;
        }
        else if (currentUi == Ui.uiMenu)
        {
            ActivateUi(uiSettings.gameObject);
            uiSettings.Fade.SetActive(false);
            uiSettings.MenuBackground.SetActive(true);
            currentUi = Ui.uiSettings;
        }
    }
    public void Quit()
    {
        Application.Quit();
    }

    void Start()
    {
        instance = this;

        currentUi = Ui.uiMenu;
        ActivateUi(uiMenu.gameObject);
        
        EventController.gameOver += GameOver;

        EventController.LeaderboardOpening += uiLeaderboard.ShowPlayers;

        EventController.GameStart += uiGameplay.UpdateScore;
        EventController.GameRestart += uiGameplay.UpdateScore;
        EventController.lineDestroing += uiGameplay.UpdateScore;
        EventController.GameStart += uiGameplay.TimeReset;
        EventController.GameRestart += uiGameplay.TimeReset;
    }
    void Update() 
    {
        if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && currentUi == Ui.uiGameplay)
        {
            PauseGame();
        }
        else if((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && currentUi == Ui.uiPause)
        {
            UnpauseGame();
        }

        if (currentUi == Ui.uiSettings && Input.GetKeyDown(KeyCode.Escape))
        {
            BackOfSettings();
        }
        else if (currentUi == Ui.uiMenu && Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }

        if (currentUi == Ui.uiGameplay)
        {
            uiGameplay.UpdateGameplayTime();
            uiGameplay.SetGameplayTime();
            uiGameplay.UpdateScore();
        }
    }

    void GameOver()
    {
        ActivateUi(uiGameOver.gameObject);
        currentUi = Ui.uiGameOver;
        uiGameOver.FadePlane.DOFade(0.6f, 2f);
        uiGameOver.OnGameOver();
    }

    void ActivateUi(GameObject uiToActivate)
    {
        lastUi = currentUi;

        uiMenu.gameObject.SetActive(false);
        uiGameplay.gameObject.SetActive(false);
        uiSettings.gameObject.SetActive(false);
        uiPause.gameObject.SetActive(false);
        uiGameOver.gameObject.SetActive(false);
        uiLeaderboard.gameObject.SetActive(false);
        uiPlayerAdder.gameObject.SetActive(false);

        uiToActivate.SetActive(true);
    }
    void ActivateUi(GameObject uiToActivateFirst, GameObject uiToActivateSecond)
    {
        ActivateUi(uiToActivateFirst);

        uiToActivateSecond.SetActive(true);
    }

    void SetTimeMove()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
    void SetTimeStop()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
    }
}
