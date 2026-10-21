using UnityEngine;

public class HazardScript : MonoBehaviour
{

    public Rigidbody2D RB;

    public float xSpeed = 5;
    public float ySpeed = 5;


    
    
    void Update()
    {
        Vector2 vel = new Vector2(0, 0);

        vel.x = xSpeed;

        vel.y = ySpeed;

        RB.linearVelocity = vel;
    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Top Down Wall"))
        {
            ySpeed *= -1;
        }
        if (other.gameObject.CompareTag("Left Right Wall"))
        {
            xSpeed *= -1;
        }
        
    }
    
    
}