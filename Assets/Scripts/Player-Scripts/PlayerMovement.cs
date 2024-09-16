using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Remove "Escape - GetKeyDown" before release.

    public Camera fpCamera;
    public float movementSpeed = 10.0f;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float movementBackFort = Input.GetAxis("Vertical") * movementSpeed;
        float movementSideways = Input.GetAxis("Horizontal") * movementSpeed;

        movementBackFort *= Time.deltaTime;
        movementSideways *= Time.deltaTime;

        transform.Translate(movementSideways, 0, movementBackFort);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }
}
