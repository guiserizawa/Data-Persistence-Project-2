using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{   
    public GameObject canvas;
    public string playerName;
    
    void Start()
    {
        playerName = GameManager.Instance.PlayerName;
    }
    public void StartNew()
    {
        playerName = canvas.transform.Find("Player Name").GetComponent<InputField>().text;
        Debug.Log("MenuUIHandler says: playerName set to '" + playerName + "'");
        GameManager.Instance.PlayerName = playerName;
        GameManager.Instance.SaveName();
        Debug.Log("MenuUIHandler says: variable PlayerName saved in GameManager as '" + GameManager.Instance.PlayerName + "'");
        SceneManager.LoadScene(1);
    }

    void Update()
    {
        
    }
    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
