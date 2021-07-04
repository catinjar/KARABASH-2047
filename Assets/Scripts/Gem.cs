using UnityEngine;

public class Gem : MonoBehaviour
{
    public float lifeTime = 5;
    public AudioClip pickupSound;

    private float currentLifeTime;
    
    private void Update()
    {
        currentLifeTime += Time.deltaTime;

        if (currentLifeTime > lifeTime)
        {
            Destroy(gameObject);
        }

        float size01 = 1 - currentLifeTime / lifeTime * 0.8f;
        transform.localScale = new Vector3(size01, size01, 0);
    }

    public void Pickup()
    {
        GameState.Instance.Score += 100;
        Destroy(gameObject);
        SoundManager.Instance.PlaySound(pickupSound);
    }
}
