using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerNameInputField;
    public TMP_Text BestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        BestScoreText.text = "Best Score: " +
            SessionManager.Instance.highestScore.playerName +
            " " +
            SessionManager.Instance.highestScore.points;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SessionManager.Instance.SavePlayername(playerNameInputField.text);
        SceneManager.LoadScene(1);
    }

    public void QuitApplication()
    {
        #if UNITY_EDITOR 
            EditorApplication.ExitPlaymode();
        #else 
            Application.Quit();
        #endif
    }
}
