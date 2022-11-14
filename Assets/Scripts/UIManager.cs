using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject GameOverUI;
    public string GameWon = "Game Won";
    public string GameLost = "Game Lost";

    public Text result;
    public Text score;

    private void Start()
    {
        
        
        score.text = GameObject.FindObjectOfType<ScoreManager>().TotalScore.ToString();
    }

    private void OnEnable()
    {
        GridBoard.OnAllCellDead += GameOverAndLost;
        ScoreManager.OnGameWon += GameWonAndGameOver;
    }

    private void OnDisable()
    {
        GridBoard.OnAllCellDead -= GameOverAndLost;
        ScoreManager.OnGameWon -= GameWonAndGameOver;
    }

    public void GameWonAndGameOver()
    {
        GameOverUI.gameObject.SetActive(true);
        result.text = GameWon;
        score.text = GameObject.FindObjectOfType<ScoreManager>().TotalScore.ToString();
    }

    public void GameOverAndLost()
    {
        GameOverUI.SetActive(true);
        result.text = GameLost;
        score.text = GameObject.FindObjectOfType<ScoreManager>().TotalScore.ToString();
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
