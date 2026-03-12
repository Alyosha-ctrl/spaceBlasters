using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Threading.Tasks;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;

    public float speed = 10f;

    public float dashDistance = 30;

    public AudioSource ow;
     public AudioSource pew;

    bool dash = true;

    void Start()
    {
        // todo - get and cache animator
    }
    
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
            Debug.Log("Bang!");

            // todo - destroy the bullet after 3 seconds
            Destroy(shot, 3f);
            // todo - trigger shoot animation
            Animator animator = GetComponent<Animator>();
            animator.SetTrigger("Shoot");
            pew.Play();
        }
        int direction = 0;
        if (Keyboard.current.aKey.isPressed)
        {
            direction = 1;
            transform.Translate(new Vector3(0f, speed*direction, 0f));
        }else if (Keyboard.current.dKey.isPressed)
        {
            direction = -1;
            transform.Translate(new Vector3(0f, speed*direction, 0f));
        }

        //Smovement baby. set up my beautiful, beautiful dash. 
        //Go for sudden movement on dash
        if (Keyboard.current.shiftKey.isPressed && dash)
        {
            Debug.Log("Dashed");
            transform.Translate(new Vector3(0f, dashDistance*direction, 0f)*Time.deltaTime);
            //Add a woosh sound

            //Add a dash available indicator maybe with making the main character 
            //white and then darken back to right color over the course of a second
            //Maybe make an animation of that.

            dash = false;
            Invoke("resetDash", 1);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3 || collision.gameObject.layer == 6) {
            //Try to do something to set score to zero.
            Debug.Log("Killed Player");
            ow.Play();
            Animator animator = GetComponent<Animator>();
            animator.SetTrigger("dead");
            
            Destroy(collision.gameObject);
            // Destroy(this.gameObject, 1f);
            Invoke("loadCredits", 2.1f);
        }
    }

    void resetDash()
    {
        dash = true;
    }

    public void loadCredits()
    {
        Debug.Log("inside Load Credits");
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
