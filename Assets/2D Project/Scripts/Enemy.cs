using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int points = 10;
    public delegate void EnemyDeathFunct(int points);
    public static event EnemyDeathFunct OnEnemyDeath;

    public delegate void EnemyBorderFunct();

    public static event EnemyBorderFunct OnEnemyBorder;
    public int enemyType = 1;

    float time = 0;

    float interval = 1;

    int direction = 1;
    void OnCollisionEnter2D(Collision2D collision)
    {
        UnityEngine.Debug.Log("Ouch!");
        
        // todo - destroy the bullet
        if(collision.gameObject.layer == 3) {
            Destroy(collision.gameObject);
            
            // todo - trigger death animation
            Destroy(this.gameObject);
            OnEnemyDeath?.Invoke(enemyType);
        }
    }

    void Update()
    {
        //Do stuff with time
        time += Time.deltaTime;

        //Every interval move to the direction if not on the edge
        //If on edge go down.
        if(time >= interval)
        {
            time = 0;
            // UnityEngine.Debug.Log("Movement activated");            //Get the position
            Vector2 position = GetComponent<Transform>().position;
            //Move to next animation position

            //if direction is negative check the left
            if((direction < 0 && position.x <= -15) || (direction > 0 && position.x >= 15))
            {
                // UnityEngine.Debug.Log("Down activated"); 
                position.y -= 1.5f;
                direction *= -1;
            }
            else
            {
                position.x += direction;
            }

            GetComponent<Transform>().position = position;
        }
    }

    void OnDestroy()
    {
        
    }

    public void playTic()
    {
        // UnityEngine.Debug.Log("tic");
    }

    public void playTac()
    {
        // UnityEngine.Debug.Log("tac");
    }

    
}
