using ProtoType;
using UnityEngine;

public class GameController
{
    public static GameController Instance = new GameController(); 
    public PlayerModel Player = new PlayerModel();
    public int Score = 0;
    public int Time = 0;

    public void AddScore(int score)
    {
        Score += score;
    }

    public void IncreaseTime()
    {
        Debug.Log(Time);
        Time++;
    }

}
