using UnityEngine;
using UnityEngine.UI;

public class UiSettings : MonoBehaviour
{
    [SerializeField] Slider[] volumeSliders;
    [SerializeField] Toggle[] resolutionToggles;
    [SerializeField] int[] screenWidth;
    [SerializeField] Button backButton;
    [SerializeField] Toggle fullScreen;
    [SerializeField] GameObject fade;
    [SerializeField] GameObject menuBackground;
    
    public GameObject Fade
    {
        get { return fade; }
        set { fade = value; }
    }

    public GameObject MenuBackground
    {
        get { return menuBackground; }
        set { menuBackground = value; }
    }

    int activeScreenResIndex;

    void Start()
    {
        Fade = fade;
        MenuBackground = menuBackground;

        activeScreenResIndex = PlayerPrefs.GetInt("Screen Resolution Index");
        bool isFullScreen = (PlayerPrefs.GetInt("Fullscreen") == 1) ? true : false;

        backButton.onClick.AddListener(UiManager.instance.BackOfSettings);
        
        for (int i = 0; i < resolutionToggles.Length; i++)
        {
            int j = i;
            resolutionToggles[j].onValueChanged.AddListener ( (value) => SetScreenResolution(j)); 
        }
        fullScreen.onValueChanged.AddListener(SetFullScreen);

        volumeSliders[0].value = AudioManager.instance.masterVolumePercent;
        volumeSliders[0].onValueChanged.AddListener (SetMasterVolume);
        volumeSliders[1].value = AudioManager.instance.musicVolumePercent;
        volumeSliders[1].onValueChanged.AddListener (SetMusicVolume); 
        volumeSliders[2].value = AudioManager.instance.sfxVolumePercent;
        volumeSliders[2].onValueChanged.AddListener (SetSfxVolume); 

        for (int i = 0; i < resolutionToggles.Length; i++)
        {
            resolutionToggles[i].isOn = i == activeScreenResIndex;
        }
        SetFullScreen(isFullScreen);
        fullScreen.isOn = isFullScreen;
    }

    void SetScreenResolution(int i)
    {
        if (resolutionToggles[i].isOn)
        {
            activeScreenResIndex = i;
            float aspectRatio = 16f / 9f;
            Screen.SetResolution(screenWidth[i], (int)(screenWidth[i] / aspectRatio) + 1, false);

            PlayerPrefs.SetInt("Screen Resolution Index", activeScreenResIndex);
            PlayerPrefs.Save();
        }
    }

    void SetFullScreen(bool isFullScreen)
    {
        for(int i = 0; i < resolutionToggles.Length; i++)
        {
            resolutionToggles[i].interactable = !isFullScreen;
        }

        if(isFullScreen)
        {
            Resolution[] allResolutions = Screen.resolutions;
            Resolution maxResolution = allResolutions[allResolutions.Length - 1];
            Screen.SetResolution(maxResolution.width, maxResolution.height, true);
        }
        else
        {
            SetScreenResolution(activeScreenResIndex);
        }

        PlayerPrefs.SetInt("Fullscreen", ((isFullScreen) ? 1 : 0));
        PlayerPrefs.Save();
    }

    void SetMasterVolume(float value) 
    {
        AudioManager.instance.SetVolume(value, AudioChannel.Master);
    }
    public void SetMusicVolume(float value) 
    {
        AudioManager.instance.SetVolume(value, AudioChannel.Music);
    }
    public void SetSfxVolume(float value) 
    {
        AudioManager.instance.SetVolume(value, AudioChannel.Sfx);
    }
}
