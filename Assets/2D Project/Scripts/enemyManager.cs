using System.Numerics;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    //Keep control of all the enemies, increase their speed when neccesary and grab a random enemy to eat once in a while.

    public float gunInterval = 3f;
    float time = 0f;

    float moveTime = 0f;
    public float moveInterval = 1f;

    public GameObject bulletPrefab;

    int direction = 1;

    bool switching = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Enemy.OnEnemyDeath += OnEnemyDeath;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= gunInterval)
        {
            shoot();
            time = 0f;
        }

        moveTime += Time.deltaTime;
        if(moveTime >= moveInterval)
        {
            move();
            moveTime = 0f;
        }

        //Do the movement here.
    }

    void shoot()
    {
        Debug.Log("No shooting yet");

        UnityEngine.Vector3 shootPostition = new UnityEngine.Vector3(100,0,0);

        //Make a list of all your children and use a random ones position as a anchor for getting shot.
        foreach (Transform child in transform)
        {
            shootPostition = child.position;
        }
            

        GameObject shot = Instantiate(bulletPrefab, shootPostition, UnityEngine.Quaternion.identity);
        Debug.Log("Bang!");

        // todo - destroy the bullet after 3 seconds
        Destroy(shot, 3f);
    }

    void move()
    {
        //Grab them here and move them all here.
        //manipulate time above and have whats below done in if
        foreach (Transform child in transform)
        {
            // UnityEngine.Debug.Log("Movement activated");            //Get the position
            //Move to next animation position

            //if direction is negative check the left
            UnityEngine.Vector2 pos = child.position;
            if(switching || (direction < 0 && child.position.x <= -14) || (direction > 0 && child.position.x >= 14))
            {
                // UnityEngine.Debug.Log("Down activated"); 
                pos.y -= 1.5f;
                if(switching != true) direction *= -1;
                switching = true;
            }
            else
            {
             pos.x += direction;   
            }
            
            child.position = pos;
        }
        switching = false;
    }

    void OnEnemyDeath(int points)
        {
            moveInterval *= .9f;
            gunInterval *= .9f;
        }
}
