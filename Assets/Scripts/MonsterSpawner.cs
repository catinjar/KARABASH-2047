using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public Monster monsterPrefab;
    public float spawnTime;

    private float currentSpawnTime;
    
    private void Update()
    {
        currentSpawnTime += Time.deltaTime;

        if (currentSpawnTime > spawnTime)
        {
            Spawn();
            currentSpawnTime = 0;
        }
    }

    private void Spawn()
    {
        Instantiate(monsterPrefab, GetRandomPointOnBorder(), Quaternion.identity);
    }

    private Vector3 GetRandomPointOnBorder()
    {
        int side = Random.Range(0, 4);

        switch (side)
        {
            default: return new Vector3(10, Random.Range(-4, 4), 0);  // Right
            case 1:  return new Vector3(Random.Range(-8, 8), 6, 0);   // Top
            case 2:  return new Vector3(-10, Random.Range(-4, 4), 0); // Left
            case 3:  return new Vector3(Random.Range(-8, 8), -6, 0);  // Bottom
        }
    }
}
