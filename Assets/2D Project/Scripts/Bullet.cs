using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public float speed = 5;

    void Start()
    {
        if (this.gameObject.layer == 6)
        {
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * speed;
        }
        else
        {
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * speed;
        }
        
        // Debug.Log("Wwweeeeee");
    }
}
