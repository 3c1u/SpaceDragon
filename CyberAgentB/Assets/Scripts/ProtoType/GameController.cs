using System;
using ProtoType;
using UnityEngine;

public class GameController
{
    public static GameController Instance = new GameController(); 
    public PlayerModel Player = new PlayerModel();
    public int LimitTime = 10;
    public int Score = 0;
    public int Time = 10;
    public int MaxLife = 3;
    public int LifeCount = 3;
    public Action TakenDamageAction;

    public void AddScore(int score)
    {
        Score += score;
    }

    public void DecreaseTime()
    {
        Time--;
        if (Time <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("GameOver!!");
    }

    public void TakenDamage()
    {
        LifeCount--;
        TakenDamageAction?.Invoke();
    }

}
