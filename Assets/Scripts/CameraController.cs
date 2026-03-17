using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 20.0f;     
    public float rotationSpeed = 60.0f; 

    void Update()
    {
        float moveX = 0;
        float moveZ = 0;

        if (Input.GetKey(KeyCode.UpArrow)) moveZ = 1;
        if (Input.GetKey(KeyCode.DownArrow)) moveZ = -1;
        if (Input.GetKey(KeyCode.LeftArrow)) moveX = -1;
        if (Input.GetKey(KeyCode.RightArrow)) moveX = 1;

        Vector3 moveDirection = new Vector3(moveX, 0, moveZ);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        float moveY = 0;
        if (Input.GetKey(KeyCode.Plus) || Input.GetKey(KeyCode.KeypadPlus) || Input.GetKey(KeyCode.Equals))
            moveY = 1;
        if (Input.GetKey(KeyCode.Minus) || Input.GetKey(KeyCode.KeypadMinus))
            moveY = -1;

        transform.Translate(new Vector3(0, moveY, 0) * moveSpeed * Time.deltaTime, Space.World);

        
        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}