using UnityEngine;

public class Flame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<RedGrass>())
        {
        }
    }
}