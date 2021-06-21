using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public static MenuHandler Instance;

    public string currentName;
    public int bestScore;
    public string bestName;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScoreAndName();
    }

    [System.Serializable]
    class SaveData
    {
        public string bestName;
        public int bestScore;
    }

    public void SaveBestScoreAndName()
    {
        SaveData data = new SaveData();
        data.bestName = bestName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadBestScoreAndName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestName = data.bestName;
            bestScore = data.bestScore;
        }
    }
}
