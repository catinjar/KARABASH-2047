using UnityEngine;

public class Gun : MonoBehaviour
{
    public Aim aim;
    public Bullet bulletPrefab;
    public Transform shootPoint;
    public float reloadTime = 0.25f;

    private bool reloading;
    private float currentReloadTime;
    
    private void Update()
    {
        UpdateDirection();
        UpdateShooting();
    }

    private void UpdateDirection()
    {
        var direction = aim.transform.position - transform.position;
        direction.z = 0;
        transform.rotation = Quaternion.Euler(0, 0, Vector3.SignedAngle(Vector3.right, direction, Vector3.forward));
    }

    private void UpdateShooting()
    {
        if (!reloading && Input.GetMouseButton(0))
        {
            reloading = true;

            var rotation = transform.rotation;
            rotation *= Quaternion.Euler(Random.Range(-10, 10) * Vector3.forward);
            
            Instantiate(bulletPrefab, shootPoint.position, rotation);
        }

        if (reloading)
        {
            currentReloadTime += Time.deltaTime;
            if (currentReloadTime > reloadTime)
            {
                currentReloadTime = 0;
                reloading = false;
            }
        }
    }
}
