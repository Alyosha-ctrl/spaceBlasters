using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    int score = 0;

    //Replace that high score with loading from player prefs
    int highScore = 0;

    //Have an interval in her that tells a random enemy to shoot.
    float shootInterval = 5;

    void Start()
    {
       // todo - sign up for notification about enemy death 
       Enemy.OnEnemyDeath += OnEnemyDeath;
       highScore = PlayerPrefs.GetInt("highScore", 0);
       string dummyHighScore = highScoreText.text;
       dummyHighScore = String.Format("High Score: {0:0000}", highScore);
       highScoreText.text = dummyHighScore;
    }

    void OnEnemyDeath(int points)
    {
        // Debug.Log("Enemy Died");
        // Debug.Log(points);
        score += points;
        string dummyScore = "Score:" + score;
        string dummyHighScore = highScoreText.text;
        if(highScore < score)
        {
            dummyHighScore = "High Score:" + score;
            highScore = score;
            //Do something in here with playerPrefs.
            PlayerPrefs.SetInt("highScore", highScore);
            PlayerPrefs.Save();
        }
        
        for(int extras = 4 - dummyScore.Length; extras > 0; extras--)
        {
            dummyScore = dummyScore.Insert(0, "0");
            if(highScore <= score)
            {
                dummyHighScore = dummyHighScore.Insert(0, "0");
            }

         }
        scoreText.text = dummyScore;
        highScoreText.text = dummyHighScore;
        //Also tell all the enemies to speed up by lowering the interval by timesing it by .1
    }
}
