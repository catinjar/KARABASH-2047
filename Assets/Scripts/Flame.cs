using UnityEngine;

public class Flame : MonoBehaviour
{
    public AudioClip burnSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<RedGrass>())
        {
            other.GetComponent<RedGrass>().IsBurning = true;
            SoundManager.Instance.PlaySound(burnSound);
        }
    }
}