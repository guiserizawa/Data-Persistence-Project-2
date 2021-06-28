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
    public Text BestScore;
    
    void Start()
    {
        playerName = GameManager.Instance.playerName;        
    }
    public void StartNew()
    {
        playerName = canvas.transform.Find("Player Name").GetComponent<InputField>().text;
        if (playerName == "")
        {
            playerName = GameManager.Instance.playerName;
        }
        else
        {
            GameManager.Instance.playerName = playerName;
        }
        Debug.Log("MenuUIHandler says: playerName set to '" + playerName + "'");
        GameManager.Instance.SaveGame();
        Debug.Log("MenuUIHandler says: variable PlayerName saved in GameManager as '" + GameManager.Instance.playerName + "'");
        SceneManager.LoadScene(1);
    }

    void Update()
    {
        if (GameManager.Instance.highScore == 0)
        {
            BestScore.text = "Best Score:";
        } 
        else
        {
            BestScore.text = "Best Score:" + "\n" + GameManager.Instance.highScoreName + " : " + GameManager.Instance.highScore + " points";
        }
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
