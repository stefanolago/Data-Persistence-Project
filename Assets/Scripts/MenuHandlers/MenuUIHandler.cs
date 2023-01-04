using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerNameInputField;

    // Start is called before the first frame update
    void Start()
    {
        
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
