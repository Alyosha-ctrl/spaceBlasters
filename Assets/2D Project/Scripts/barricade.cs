using UnityEngine;

public class barricade : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit barricade");
        
        // todo - destroy the bullet
        if(collision.gameObject.layer == 3 || collision.gameObject.layer == 6) {
            Destroy(collision.gameObject);
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
}
