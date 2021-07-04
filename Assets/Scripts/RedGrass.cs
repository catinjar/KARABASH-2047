using UnityEngine;

public class RedGrass : MonoBehaviour
{
    public float growthRate = 0.35f;

    public float Growth01 { get; set; } = 0.2f;

    private void Update()
    {
        Growth01 += growthRate * Time.deltaTime;
        Growth01 = Mathf.Clamp(Growth01, 0, 1);

        transform.localScale = new Vector3(Growth01, Growth01, 1);
    }
}
