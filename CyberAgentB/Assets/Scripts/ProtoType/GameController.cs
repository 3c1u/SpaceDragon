using System.Collections;
using System.Collections.Generic;
using ProtoType;
using UnityEngine;

public class GameController
{
    public static GameController Instance = new GameController(); 
    public PlayerModel Player = new PlayerModel();
    public int Score = 0;
    public int Time = 0;

    public void SetTime(int time)
    {
        Time = time;
    }

    public void AddScore(int score)
    {
        Score = score;
    }

}
