using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public float speed = 5.0f;
    public float moveDistance = 10.0f;
    public float dropAmount = 2.0f;

    private Vector3 startPos;
    private int phase = 0;

    
    public GameObject bulletPrefab;
    public float minShootTime = 2.0f;
    public float maxShootTime = 10.0f;
    private float shootTimer;

    void Start()
    {
        startPos = transform.position;
        ResetShootTimer();
    }

    void Update()
    {
        MoveEnemy();
        HandleShooting();
    }

    void MoveEnemy()
    {
        
        if (phase == 0)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x >= startPos.x + moveDistance) phase = 1;
        }
        
        else if (phase == 1)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x <= startPos.x) phase = 2;
        }
       
        else if (phase == 2)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x <= startPos.x - moveDistance) phase = 3;
        }
        else if (phase == 3)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x >= startPos.x) phase = 4;
        }
        else if (phase == 4)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - dropAmount, transform.position.z);
            phase = 0;
        }
    }

    void HandleShooting()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            Shoot();
            ResetShootTimer();
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }

    void ResetShootTimer()
    {
        shootTimer = Random.Range(minShootTime, maxShootTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Shooter")
        {
            Destroy(collision.gameObject);
            Debug.Log("GAME OVER - Σε ακούμπησε εξωγήινος!");
        }
    }
}