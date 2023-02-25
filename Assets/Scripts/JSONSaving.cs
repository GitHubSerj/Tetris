using UnityEngine;
using System.IO;

[System.Serializable]
public class JSONSaving : MonoBehaviour
{
    Leaderboard leaderboard = new Leaderboard();

    public Leaderboard Leaderboard => leaderboard;
    
    string path;
    string persistentPath;

    public static JSONSaving instance;


    void Awake() 
    {
        instance = this;
        SetPath();
        LoadData();
        EventController.PlayerAdded += AddPlayerToBoard;
    }
    
    void SetPath()
    {
        //path = Application.dataPath + Path.DirectorySeparatorChar + "SaveData.json";
        persistentPath = Application.persistentDataPath + Path.DirectorySeparatorChar + "SaveData.json";
    }

    void LoadData()
    {
        if (!File.Exists(persistentPath))
        {
            File.WriteAllText(persistentPath, JsonUtility.ToJson(leaderboard));
        }

        string json = File.ReadAllText(persistentPath);
        leaderboard = JsonUtility.FromJson<Leaderboard>(json);
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(leaderboard);

        File.WriteAllText(persistentPath, json);
    }

    void AddPlayerToBoard(string name, int score)
    {
        leaderboard.playersInLeaderboard.Add(new PlayerInLeaderboard(name, score));
        SaveData();
        LoadData();
    }
}
 