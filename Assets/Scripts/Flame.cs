using UnityEngine;

public class Flame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<RedGrass>())
        {
            other.GetComponent<RedGrass>().IsBurning = true;
        }

        if (other.GetComponent<Monster>())
        {
            other.GetComponent<Monster>().Die(false);
        }
    }
}