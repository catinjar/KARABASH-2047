using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RedGrassSpawner : MonoBehaviour
{
    public RedGrass redGrassPrefab;
    public float spawnRate;

    private float currentSpawnTime;
    
    private void Update()
    {
        currentSpawnTime += Time.deltaTime;

        if (currentSpawnTime > spawnRate)
        {
            Spawn();
            currentSpawnTime = 0;
        }
    }

    private void Spawn()
    {
        var redGrasses = FindObjectsOfType<RedGrass>().Where(r => r.Growth01 > 0.8f).ToList();

        if (redGrasses.Count == 0)
            return;
        
        var redGrass = redGrasses[Random.Range(0, redGrasses.Count)];

        float angle = Random.Range(0, 360);
        var position = redGrass.transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);

        Instantiate(redGrassPrefab, position, Quaternion.identity);
    }
}
