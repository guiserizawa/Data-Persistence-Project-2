using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string PlayerName;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadName();
        Debug.Log("GameManager says: Loaded player name is '" + PlayerName + "'");
    }

    [System.Serializable]
    class SaveData
    {
        public string SavedName;
    }

    public void SaveName()
    {
        SaveData data = new SaveData();
        data.SavedName = PlayerName;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("GameManager: Player name saved as '" + data.SavedName + "'");
    }
    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.SavedName;
        }
    }

}
