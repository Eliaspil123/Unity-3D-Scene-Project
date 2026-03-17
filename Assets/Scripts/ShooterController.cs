using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public float currentSpeed = 15.0f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    private float[] speedLevels = { 5f, 10f, 15f, 20f, 25f };
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) currentSpeed = speedLevels[0];
        if (Input.GetKeyDown(KeyCode.Alpha2)) currentSpeed = speedLevels[1];
        if (Input.GetKeyDown(KeyCode.Alpha3)) currentSpeed = speedLevels[2];
        if (Input.GetKeyDown(KeyCode.Alpha4)) currentSpeed = speedLevels[3];
        if (Input.GetKeyDown(KeyCode.Alpha5)) currentSpeed = speedLevels[4];
       


        float moveX = 0;
        float moveZ = 0;
        if (Input.GetKey(KeyCode.J)) 
            moveX = -1; 
        if (Input.GetKey(KeyCode.L)) 
            moveX = 1;  
        if (Input.GetKey(KeyCode.I)) 
            moveZ = 1;  
        if (Input.GetKey(KeyCode.K)) 
            moveZ = -1; 

        Vector3 movement = new Vector3(moveX, 0, moveZ);
        transform.Translate(movement * currentSpeed * Time.deltaTime, Space.World);
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            Debug.LogError("Δεν έχεις σύρει το BulletPrefab ή το FirePoint στο Inspector!");
        }
    }
}