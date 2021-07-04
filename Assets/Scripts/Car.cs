using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    public float maxVelocity;
    public float maxVelocityInRedGrass;
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

        if (GameState.Instance.Health <= 0)
        {
            GameResult.Result = GameState.Instance.Score;
            if (GameResult.Result > GameResult.BestResult)
                GameResult.BestResult = GameResult.Result;
            
            SceneManager.LoadScene("RestartScreen");
        }
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private IEnumerator SurvivalBonusRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            GameState.Instance.Score += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<RedGrass>() != null)
        {
            TakeDamageFromRedGrass();
        }
        
        if (other.GetComponent<Gem>() != null)
        {
            other.GetComponent<Gem>().Pickup();
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<RedGrass>() != null)
        {
            TakeDamageFromRedGrass();

            currentVelocity = Mathf.Min(currentVelocity, maxVelocityInRedGrass);
        }
    }

    private void TakeDamageFromRedGrass()
    {
        GameState.Instance.TakeDamage(2.5f * Time.deltaTime);
    }
}
