using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class endScrene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("loadStart", 5f);
    }

    public void loadStart()
    {
        StartCoroutine(LoadStart());
        

        IEnumerator LoadStart()
        {
            //Load the game in here.
            Debug.Log("Loaded Main Menu");
            //get the other scene of the tag.
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync("Start");
            while(!loadOperation!.isDone) yield return null;


            GameObject pl = GameObject.Find("Player");
            Debug.Log(pl.name);
        }
    }
}
