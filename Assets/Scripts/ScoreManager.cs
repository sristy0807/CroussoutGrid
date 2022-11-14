using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour,IResult
{

    public static event Action OnGameWon;

    [SerializeField] private int winScore = 60;

    public int TotalScore { get; private set; }

    public int tempScore { get; set; }

    
    private void Start()
    {
       
    }


    public void AddScore(int score)
    {
        TotalScore += score;
        tempScore = 0;
        CellController.AddValueToScore();
    }

    
    public void RemoveTemporaryScore(int score)
    {
        AddTemporaryScoreAndCheckForAddingWithScore(-1 * score);
    }

    public void AddTemporaryScoreAndCheckForAddingWithScore(int score)
    {
        tempScore += score;
        
        CheckScore();
    }

    public void AddTemporaryScoreWithScoreAtGameEnd()
    {
        TotalScore += tempScore;
    }

    public static void PlayerWon()
    {
        OnGameWon?.Invoke();
    }

    private void CheckScore()
    {
        if(tempScore == 21)
        {
            AddScore(21);

        }else if(tempScore > 21)
        {
            AddScore(tempScore / 2);
        }
        else
        {
            //do nothing
        }

        if (isWon())
        {
            PlayerWon();
        }

    }

    public bool isWon()
    {
        if (TotalScore >= 60)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
