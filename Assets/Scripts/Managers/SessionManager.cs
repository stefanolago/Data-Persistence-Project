
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    public static SessionManager Instance;

    // Current player name
    public string playerName;

    // Best score data
    [System.Serializable]
    public class SavedHighScore
    {
        public string playerName;
        public int score;
    }

    public SavedHighScore highestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SavePlayername(string name)
    {
        playerName = name;
        return;
    }

    public void SaveHighScore()
    {
        Debug.Log("Save High Score");



    }

    public void LoadHighScore()
    {
        Debug.Log("Load High Score");

    }
}
