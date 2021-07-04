using System.Collections;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float maxVelocity;
    public float acceleration;
    public float rotateSpeed;
    public float velocityDamp;
    
    private new Rigidbody2D rigidbody2D;
    private float currentVelocity;
    private float currentAngle;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(SurvivalBonusRoutine());
    }

    private void FixedUpdate()
    {
        UpdateInput();
    }

    private void UpdateInput()
    {
        var right = transform.right;
        
        if (Input.GetKey(KeyCode.W))
        {
            currentVelocity += acceleration * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentVelocity -= acceleration * Time.deltaTime;
        }
        else
        {
            currentVelocity *= velocityDamp;
        }

        if (Mathf.Abs(currentVelocity) > 0.1)
        {
            if (Input.GetKey(KeyCode.A))
            {
                currentAngle += rotateSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D))
            {
                currentAngle -= rotateSpeed * Time.deltaTime;
            }
        }

        currentVelocity = Mathf.Clamp(currentVelocity, -maxVelocity, maxVelocity);
        
        rigidbody2D.MovePosition(transform.position + currentVelocity * Time.deltaTime * right);
        rigidbody2D.MoveRotation(currentAngle);
    }

    private IEnumerator SurvivalBonusRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            GameState.Instance.Score += 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<RedGrass>() != null)
        {
            TakeDamageFromRedGrass();
        }
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<RedGrass>() != null)
        {
            TakeDamageFromRedGrass();
        }
    }

    private void TakeDamageFromRedGrass()
    {
        GameState.Instance.TakeDamage(10.0f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Gem>() != null)
        {
            GameState.Instance.Score += 100;
            Destroy(other.gameObject);
        }
    }
}
