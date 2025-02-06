# if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorCameraRotator : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5.0f;  // Sensitivity of the rotation

    private float yaw = 0.0f;  // Horizontal rotation
    private float pitch = 0.0f;  // Vertical rotation

    private void Start()
    {
        pitch = transform.eulerAngles.x;
        yaw = transform.eulerAngles.y;
    }

    private void Update()
    {
        // Check if the right mouse button is held down
        //if (Mouse.current.leftButton.isPressed)
        if (Input.GetMouseButton(0)) // 1 is for the right mouse button, 0 is for left
        {
            // Get mouse movement
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Adjust yaw (horizontal) and pitch (vertical) based on mouse movement
            yaw += mouseX * rotationSpeed;
            pitch -= mouseY * rotationSpeed;

            // Apply rotation to the camera
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }
}
#endif
