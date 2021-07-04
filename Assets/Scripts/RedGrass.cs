using UnityEngine;

public class RedGrass : MonoBehaviour
{
    public float growthRate = 0.35f;
    public float burnLifeTime = 2.5f;
    public GameObject flame;

    public float Growth01 { get; set; } = 0.2f;

    public bool IsBurning { get; set; }

    private float burningTime;
    private float lifeTime;
    
    private void Update()
    {
        Growth01 += growthRate * Time.deltaTime;
        Growth01 = Mathf.Clamp(Growth01, 0, 1);

        float fluctuation = Mathf.Sin(lifeTime) * 0.2f;
        transform.localScale = new Vector3(Growth01 + fluctuation, Growth01 + fluctuation, 1);

        if (IsBurning)
        {
            burningTime += Time.deltaTime;

            if (burningTime > burnLifeTime)
            {
                Destroy(gameObject);

                GameState.Instance.Score += 5;
            }
            
            flame.SetActive(true);
        }

        lifeTime += Time.deltaTime;
    }
}
