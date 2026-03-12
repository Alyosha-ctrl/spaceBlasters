using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections;
public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public AudioSource kaboom;
    // public static GameManager Instance{get; private set;}
    int score = 0;

    int death_counter = 0;

    //Replace that high score with loading from player prefs
    int highScore = 0;

    
    void Start()
    {
        
       // todo - sign up for notification about enemy death 
       Enemy.OnEnemyDeath += OnEnemyDeath;
       kaboom = GetComponent<AudioSource>();
       highScore = PlayerPrefs.GetInt("highScore", 0);
       string dummyHighScore = highScoreText.text;
       dummyHighScore = String.Format("High Score: {0:0000}", highScore);
       highScoreText.text = dummyHighScore;
    }

    void OnEnemyDeath(int points)
    {
        // Debug.Log("Enemy Died");
        // Debug.Log(points);
        kaboom.Play();
        death_counter += 1;
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
        // if(death_counter >= 14)
        // {
        //     loadCredits();
        // }
    }

    // public void loadCredits()
    // {
    //     StartCoroutine(LoadCredits());
        

    //     IEnumerator LoadCredits()
    //     {
    //         //Load the game in here.
    //         Debug.Log("Loaded Game");
    //         //get the other scene of the tag.
    //         AsyncOperation loadOperation = SceneManager.LoadSceneAsync("End");
    //         while(!loadOperation!.isDone) yield return null;


    //         GameObject pl = GameObject.Find("Player");
    //     }
    // }
}
