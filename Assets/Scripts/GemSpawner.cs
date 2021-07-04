using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    public Gem gemPrefab;
    public float spawnTime = 5;

    private float currentSpawnTime;

    private void Update()
    {
        currentSpawnTime += Time.deltaTime;

        if (currentSpawnTime > spawnTime)
        {
            var position = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);
            Instantiate(gemPrefab, position, Quaternion.identity);
            currentSpawnTime = 0;
        }
    }
}
