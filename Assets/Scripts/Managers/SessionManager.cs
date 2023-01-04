
using System.IO;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    public static SessionManager Instance;

    // Score data
    [System.Serializable]
    public class PlayerScore
    {
        public string playerName;
        public int points;
    }

    // Current session score
    public PlayerScore currentScore;

    // Highest score
    public PlayerScore highestScore;
    private string HIGHSCORE_SAVEPATH;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        HIGHSCORE_SAVEPATH = Application.persistentDataPath + "/highScore.json";
        LoadHighScore();
    }

    public void SavePlayername(string name)
    {
        currentScore.playerName = name;
        return;
    }

    public void SaveHighScore()
    {
        Debug.Log("Save High Score");
        PlayerScore data = highestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(HIGHSCORE_SAVEPATH, json);
    }

    public void LoadHighScore()
    {
        Debug.Log("Load High Score");
        if(File.Exists(HIGHSCORE_SAVEPATH))
        {
            string json = File.ReadAllText(HIGHSCORE_SAVEPATH);
            PlayerScore data = JsonUtility.FromJson<PlayerScore>(json);

            highestScore = data;
        } else
        {
            highestScore.playerName = "";
            highestScore.points = 0;
        }
    }

    public void UpdateHighScore()
    {
        if (currentScore.points > highestScore.points)
        {
            highestScore.playerName = currentScore.playerName;
            highestScore.points = currentScore.points;
        }
    }

    public void ResetScore()
    {
        currentScore.points = 0;
    }
}
