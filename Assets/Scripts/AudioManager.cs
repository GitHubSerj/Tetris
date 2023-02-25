using UnityEngine;
using DG.Tweening;

public class AudioManager : MonoBehaviour
{
    public float masterVolumePercent {get; private set; }
    public float sfxVolumePercent {get; private set; }
    public float musicVolumePercent {get; private set; }
    
    int activeMusicSourceIndex;
    AudioSource sfx2DSource;
    AudioSource[] musicSources;
    Transform playerT;
    SoundLibrary library;
    AudioClip currentAudioClip;
    bool musicPlayFirstTime = true;
    
    public AudioClip CurrentAudioClip => currentAudioClip;

    public static AudioManager instance;

    

    public void SetVolume(float volumPercent, AudioChannel channel)
    {
        switch (channel)
        {
            case AudioChannel.Master:
                masterVolumePercent = volumPercent;
                break;
            case AudioChannel.Sfx:
                sfxVolumePercent = volumPercent;
                break;
            case AudioChannel.Music:
                musicVolumePercent = volumPercent;
                break;
        }

        musicSources[activeMusicSourceIndex].volume = musicVolumePercent * masterVolumePercent;

        PlayerPrefs.SetFloat("Master volume", masterVolumePercent);
        PlayerPrefs.SetFloat("Sfx volume", sfxVolumePercent);
        PlayerPrefs.SetFloat("Music volume", musicVolumePercent);
        PlayerPrefs.Save();
    }

    public void PlaySound(AudioClip clip, Vector3 pos)
    {
        if(clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, pos, sfxVolumePercent * masterVolumePercent);
        }
    }

    public void PlaySound2D(string soundName)
    {
        sfx2DSource.PlayOneShot(library.GetClipFromName(soundName), sfxVolumePercent * masterVolumePercent);
    }

    public void PlayMusic(AudioClip clip, float fade)
    {
        activeMusicSourceIndex = 1 - activeMusicSourceIndex;
        musicSources[activeMusicSourceIndex].clip = clip;
        musicSources[activeMusicSourceIndex].Play();
        currentAudioClip = musicSources[activeMusicSourceIndex].clip;

        if (musicPlayFirstTime)
        {
            musicSources[activeMusicSourceIndex].DOFade(musicVolumePercent * masterVolumePercent,  0).SetEase(Ease.Linear);
            musicSources[1 - activeMusicSourceIndex].DOFade(0, 0).SetEase(Ease.Linear);
            musicPlayFirstTime = false;
        }
        else
        {
            musicSources[activeMusicSourceIndex].DOFade(musicVolumePercent * masterVolumePercent,  fade).SetEase(Ease.Linear);
            musicSources[1 - activeMusicSourceIndex].DOFade(0, fade).SetEase(Ease.Linear);
        }
    }

    void Awake() 
    {
        instance = this;

        library = GetComponent<SoundLibrary>();

        musicSources = new AudioSource[2];
        for (int i = 0; i < 2; i++)
        {
            GameObject newMusicSource = new GameObject("Music source " + (i+1));
            musicSources[i] = newMusicSource.AddComponent<AudioSource>();
            newMusicSource.transform.parent = transform;
            musicSources[i].loop = true;
        }

        GameObject newSfx2DSource = new GameObject("2D Sound Sfx Source");
        sfx2DSource = newSfx2DSource.AddComponent<AudioSource>();
        newSfx2DSource.transform.parent =  transform;

        masterVolumePercent = PlayerPrefs.GetFloat("Master volume", defaultValue: 1);
        sfxVolumePercent = PlayerPrefs.GetFloat("Sfx volume", defaultValue: 1);
        musicVolumePercent = PlayerPrefs.GetFloat("Music volume", defaultValue: 1);
    }
}
