using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;

    public float speed = 10f;

    public float dashDistance = 30;

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        UnityEngine.Debug.Log("Ouch!");
        
        // todo - destroy the bullet
        if(collision.gameObject.layer == 6) {
            Destroy(collision.gameObject);
            
            // todo - trigger death animation
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3 || collision.gameObject.layer == 6) {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    void resetDash()
    {
        dash = true;
    }
}
