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

    private InputAction lookAction;
    private InputAction leftClickAction;

    private void Start()
    {
        pitch = transform.eulerAngles.x;
        yaw = transform.eulerAngles.y;
    }

    private void OnEnable()
    {
        lookAction = new InputAction(type: InputActionType.Value, binding: "<Mouse>/delta");
        leftClickAction = new InputAction(type: InputActionType.Button, binding: "<Mouse>/leftButton");

        lookAction.Enable();
        leftClickAction.Enable();
    }

    private void OnDisable()
    {
        lookAction.Disable();
        leftClickAction.Disable();
    }

    private void Update()
    {
        //// Check if the right mouse button is held down
        //if (Input.GetMouseButton(0)) // 1 is for the right mouse button, 0 is for left
        //{
        //    // Get mouse movement
        //    float mouseX = Input.GetAxis("Mouse X");
        //    float mouseY = Input.GetAxis("Mouse Y");

        //    // Adjust yaw (horizontal) and pitch (vertical) based on mouse movement
        //    yaw += mouseX * rotationSpeed;
        //    pitch -= mouseY * rotationSpeed;

        //    // Apply rotation to the camera
        //    transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        //}

        if (leftClickAction.ReadValue<float>() > 0.5f)
        {
            Vector2 mouseDelta = lookAction.ReadValue<Vector2>();

            yaw += mouseDelta.x * rotationSpeed * Time.deltaTime;
            pitch -= mouseDelta.y * rotationSpeed * Time.deltaTime;

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
#endif
