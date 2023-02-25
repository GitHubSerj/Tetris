using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioClip menuTheme;
    [SerializeField] AudioClip gameTheme;
    [SerializeField] float delayBetweenThemes = 1f;
    
    public AudioClip MenuTheme => menuTheme;
    public AudioClip GameTheme => gameTheme;

    public static MusicManager instance;

    private void Start() 
    {
        instance = this;
        
        EventController.GameStart += OnMenuGameplaySwitch;
        EventController.SwitchMusicInBackMenu += OnMenuGameplaySwitch;
        PlayMusic();
    }
    
    void OnMenuGameplaySwitch()
    {
        if (UiManager.instance.currentUi != UiManager.instance.lastUi)
        {
            PlayMusic();
        }
    }
    
    void PlayMusic()
    {
        AudioClip clipToPlay = null;

        if(UiManager.instance.currentUi == Ui.uiMenu)
        {
            clipToPlay = menuTheme;
        }
        else if(UiManager.instance.currentUi == Ui.uiGameplay)
        {
            clipToPlay = gameTheme;
        }


        if(clipToPlay != null)
        {
            AudioManager.instance.PlayMusic(clipToPlay, delayBetweenThemes);
        }
    }
}
