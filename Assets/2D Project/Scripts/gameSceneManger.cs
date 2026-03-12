using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameSceneManger : MonoBehaviour
{
    int death_counter = 0;
    public static gameSceneManger Instance{get; private set;}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Enemy.OnEnemyDeath += OnEnemyDeath;
    }

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void OnEnemyDeath(int points)
    {
        death_counter+= 1;
        if(death_counter >= 14)
        {
            loadCredits();
        }
    }

    public void loadCredits()
    {
        death_counter = 0;
        StartCoroutine(LoadCredits());
        

        IEnumerator LoadCredits()
        {
            //Load the game in here.
            Debug.Log("Loaded Game");
            //get the other scene of the tag.
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync("End");
            while(!loadOperation!.isDone) yield return null;


            GameObject pl = GameObject.Find("Player");
        }
    }
}
