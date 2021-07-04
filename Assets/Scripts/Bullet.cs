using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocity;

    private bool collidedOnThisFrame;
    
    private void Update()
    {
        transform.position += velocity * Time.deltaTime * transform.right;
        
        collidedOnThisFrame = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Car>() != null)
        {
            return;
        }

        if (!collidedOnThisFrame && other.GetComponent<Monster>() != null)
        {
            GameState.Instance.Score += 10;
            
            other.GetComponent<Monster>().Die();
            Destroy(other.gameObject);

            collidedOnThisFrame = true;
        }
        
        Destroy(gameObject);
    }
}
