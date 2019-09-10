using ProtoType;
using UnityEngine;

public class GameObject
{
    public static GameObject Instance = new GameObject(); 
    public PlayerModel Player = new PlayerModel();
    public int Score = 0;
    public int Time = 0;

    public void AddScore(int score)
    {
        Score += score;
    }

    public void IncreaseTime()
    {
        Time++;
    }

}
