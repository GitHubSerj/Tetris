using System.Collections.Generic;
using UnityEngine;

public class SoundLibrary : MonoBehaviour
{
    [System.Serializable]
    public class SoundGroup
    {
        public string groupID;
        public AudioClip[] group;
    }

    [SerializeField] SoundGroup[] soundGroups;

    Dictionary<string, AudioClip[]> groupDictionary = new Dictionary<string, AudioClip[]>();


    public AudioClip GetClipFromName(string name)
    {
        if (groupDictionary.ContainsKey(name))
        {
            AudioClip[] sounds = groupDictionary [name];
            return sounds[Random.Range(0, sounds.Length)];
        }
        return null;

    }
    public AudioClip GetClipFromName(string name, int clipNumber)
    {
        if (groupDictionary.ContainsKey(name))
        {
            AudioClip[] sounds = groupDictionary [name];
            return sounds[clipNumber - 1];
        }
        return null;

    }

    void Awake()
    {
        foreach (SoundGroup soundGroup in soundGroups)
        {
            groupDictionary.Add(soundGroup.groupID, soundGroup.group);
        }
    }
}
