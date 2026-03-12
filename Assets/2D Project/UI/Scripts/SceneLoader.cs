using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void loadGame()
    {
        StartCoroutine(LoadGame());
        

        IEnumerator LoadGame()
        {
            //Load the game in here.
            Debug.Log("Loaded Game");
            //get the other scene of the tag.
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync("Schmup");
            while(!loadOperation!.isDone) yield return null;


            GameObject pl = GameObject.Find("Player");
            Debug.Log(pl.name);
        }
    }

    public void loadCredits()
    {
        StartCoroutine(LoadCredits());
        

        IEnumerator LoadCredits()
        {
            //Load the game in here.
            Debug.Log("Loaded Game");
            //get the other scene of the tag.
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync("End");
            while(!loadOperation!.isDone) yield return null;


            GameObject pl = GameObject.Find("Player");
            Debug.Log(pl.name);
        }
    }
}
