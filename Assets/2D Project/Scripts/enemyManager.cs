using UnityEngine;

public class enemyManager : MonoBehaviour
{
    //Keep control of all the enemies, increase their speed when neccesary and grab a random enemy to eat once in a while.

    public float gunInterval = 3f;
    float time = 0f;

    public GameObject bulletPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

        //Do the movement here.
    }

    void shoot()
    {
        Debug.Log("No shooting yet");

        Vector3 shootPostition = new Vector3(0,0,0);

        //Make a list of all your children and use a random ones position as a anchor for getting shot.
        foreach (Transform child in transform)
        {
            shootPostition = child.position;
        }
            

        GameObject shot = Instantiate(bulletPrefab, shootPostition, Quaternion.identity);
        Debug.Log("Bang!");

        // todo - destroy the bullet after 3 seconds
        Destroy(shot, 3f);
    }
}
