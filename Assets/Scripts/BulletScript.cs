using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject explosionFX;    
    public AudioClip PlayerHitSound;  

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name == "Ground")
        {
            Destroy(gameObject);
        }

     
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.name == "Shooter")
        { 
            if (PlayerHitSound != null)
            {
                AudioSource.PlayClipAtPoint(PlayerHitSound, Camera.main.transform.position);
            }

            if (explosionFX != null)
            {
                Instantiate(explosionFX, collision.transform.position, Quaternion.identity);
            }

            Debug.Log("GAME OVER!"); 

            Destroy(collision.gameObject); 
            Destroy(gameObject);           
        }
    }
}