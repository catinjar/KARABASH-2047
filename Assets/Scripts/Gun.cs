using UnityEngine;

public class Gun : MonoBehaviour
{
    public Aim aim;
    public Bullet bulletPrefab;
    public Transform shootPoint;
    public float maxSpread = 35;
    public float spreadSpeed = 20;
    public float minReloadTime = 0.15f;
    public float maxReloadTime = 0.35f;
    public float reloadTimeChangeSpeed = 0.1f;
    
    private bool reloading;
    private float currentReloadTime;
    private float spread;
    private float reloadTime;
    
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
        if (Input.GetMouseButton(0))
        {
            if (!reloading)
            {
                reloading = true;

                var rotation = transform.rotation;
                rotation *= Quaternion.Euler(Random.Range(-spread, spread) * Vector3.forward);

                Instantiate(bulletPrefab, shootPoint.position, rotation);
            }

            spread += spreadSpeed * Time.deltaTime;
            reloadTime -= reloadTimeChangeSpeed * Time.deltaTime;
        }
        else
        {
            spread -= spreadSpeed * Time.deltaTime;
            reloadTime += reloadTimeChangeSpeed * Time.deltaTime;
        }

        spread = Mathf.Clamp(spread, 0, maxSpread);
        reloadTime = Mathf.Clamp(reloadTime, minReloadTime, maxReloadTime);
        
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
