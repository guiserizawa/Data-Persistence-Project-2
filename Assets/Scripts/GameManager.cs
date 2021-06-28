using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName;
    public int highScore;
    public string highScoreName;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGame();
        Debug.Log("GameManager says: Loaded player name is '" + playerName + "'");
        Debug.Log("GameManager says: Current high Score is '" + highScore + "' by '"+ highScoreName + "'");
    }

    [System.Serializable]
    class SaveData
    {
        public string SavedName;
        public int savedHighScore;
        public string highScoreName;
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.SavedName = playerName;
        data.savedHighScore = highScore;
        data.highScoreName = highScoreName;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("GameManager: Player name saved as '" + data.SavedName + "'");
    }
    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.SavedName;
            highScore = data.savedHighScore;
            highScoreName = data.highScoreName;
        }
    }
    public void EraseHighScore()
    {
        highScore = 0;
        highScoreName = "";
        SaveGame();
    }

}
