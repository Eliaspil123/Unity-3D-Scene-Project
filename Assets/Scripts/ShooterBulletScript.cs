using UnityEngine;

public class ShooterBulletScript : MonoBehaviour
{
    public float speed = 20f;
    public GameObject explosionFX;   
    public AudioClip ExplosionSound; 
    public AudioClip WinSound;       


    void Start()
    {
        Destroy(gameObject, 3f);
    }


    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyScore enemyScript = collision.gameObject.GetComponent<EnemyScore>();
            if (enemyScript != null)
            {
                ScoreManager.AddScore(enemyScript.pointValue);
            }
            int remainingEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (remainingEnemies == 1)
            {
                Debug.Log("мийг!");
                if (WinSound != null)
                    AudioSource.PlayClipAtPoint(WinSound, Camera.main.transform.position);
            }
            else
            {
                if (ExplosionSound != null)
                    AudioSource.PlayClipAtPoint(ExplosionSound, transform.position);
            }

            if (explosionFX != null)
                Instantiate(explosionFX, collision.transform.position, Quaternion.identity);

            Destroy(collision.gameObject); 
            Destroy(gameObject);           
        }
    }
}