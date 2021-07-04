using UnityEngine;
using Random = UnityEngine.Random;

public class Monster : MonoBehaviour
{
    public float selectWanderingTargetRange;
    public float wanderingVelocity;
    public float chaseVelocity;
    public float triggerChaseRange;

    public RedGrass redGrassPrefab;

    public AudioClip deathSound;
    
    private Car car;
    private Vector3 wanderingTarget;
    private bool chasing;

    private void Start()
    {
        car = FindObjectOfType<Car>();
        SelectWanderingTarget();
    }

    private void Update()
    {
        var direction = (chasing ? car.transform.position : wanderingTarget) - transform.position;
        var velocity = chasing ? chaseVelocity : wanderingVelocity;

        transform.position += velocity * Time.deltaTime * direction.normalized;
        transform.rotation = Quaternion.Euler(0, 0, Vector3.SignedAngle(Vector3.right, direction, Vector3.forward));

        if (direction.magnitude < triggerChaseRange)
            chasing = true;
        
        if (direction.magnitude < 0.1)
            SelectWanderingTarget();

        if ((car.transform.position - transform.position).magnitude < 0.5f)
        {
            GameState.Instance.TakeDamage(5.0f * Time.deltaTime);
        }
    }

    private void SelectWanderingTarget()
    {
        wanderingTarget = new Vector3(Random.Range(-selectWanderingTargetRange, selectWanderingTargetRange),
                                      Random.Range(-selectWanderingTargetRange, selectWanderingTargetRange), 0);
        wanderingTarget.x = Mathf.Clamp(wanderingTarget.x, -9, 9);
        wanderingTarget.y = Mathf.Clamp(wanderingTarget.y, -5, 5);
    }

    public void Die(bool spawnGrass = true)
    {
        Destroy(gameObject);
        
        if (spawnGrass)
            Instantiate(redGrassPrefab, transform.position, Quaternion.identity);
        
        SoundManager.Instance.PlaySound(deathSound);
    }
}
