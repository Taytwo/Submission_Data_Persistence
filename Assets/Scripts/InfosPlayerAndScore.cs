using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InfosPlayerAndScore : MonoBehaviour
{
    public static InfosPlayerAndScore instance;
    public string playerName;
    public string playerNameHighScore;
    public int highScore;


    private void Awake() 
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string playerNameHighScore;
        public int highScore;
    }

        public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.playerNameHighScore = playerNameHighScore;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerNameHighScore = data.playerNameHighScore;
            highScore = data.highScore;
        }
    }
}
