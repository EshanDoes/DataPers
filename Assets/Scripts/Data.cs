using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Data : MonoBehaviour
{
    public static Data Instance;
    public string playerName;
    public int highScore;
    public string highName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadSave();
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string highName;
    }

    public void SaveHighScore()
    {
        SaveData saved = new SaveData();
        saved.highName = highName;
        saved.highScore = highScore;

        string json = JsonUtility.ToJson(saved);

        File.WriteAllText(Application.persistentDataPath + "/othersavefile.json", json);
    }

    public void LoadSave()
    {
        Debug.Log("LoadSave is working...");
        string path = Application.persistentDataPath + "/othersavefile.json";

        if (File.Exists(path))
        {
            Debug.Log("File.Exists is working too...");
            string json = File.ReadAllText(path);
            SaveData saved = JsonUtility.FromJson<SaveData>(json);

            highName = saved.highName;
            highScore = saved.highScore;
        }
    }
}