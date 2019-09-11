using System;
using ProtoType;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController
{
    public static GameController Instance = new GameController(); 
    public PlayerModel Player = new PlayerModel();
    public int Score = 0;
    public int Time = 60;
    public int LifeCount = 5;
    public Action TakenDamageAction;
    public GameObject BulletSpawnPoint;

    public void Reset() {
        Player = new PlayerModel();
        Score = 0;
        Time = 60;
        LifeCount = 5;
    }

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

    public void GameOver(){
        // Debug.Log("GameOver!!");
        // 結果画面に遷移
        var rank = "A+";
        var score = Score;

        if (score < 100) {
            rank = "C";
        } else if (score < 200) {
            rank = "B";
        } else if (score < 300) {
            rank = "A";
        }

        Reset();
        ResultScreen.InvokeResultScreen(score, rank, false);
    }

    public void TakenDamage()
    {
        LifeCount--;
        TakenDamageAction?.Invoke();
        if (LifeCount <= 0)
        {
            GameOver();
            return;
        }
    }

    public void ChangeSceneResult()
    {
        SceneManager.LoadScene("");
    }

}
