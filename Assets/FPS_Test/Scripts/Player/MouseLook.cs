using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float cameraheight = 1.4f;

    [SerializeField] private float mouseSensitivity = 8f;

    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;

    [SerializeField]public bool canTurn = true;
    private float mouseX, mouseY;
    private float xRotation;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    private void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }

        mainCamera.transform.position = transform.position + new Vector3(0, cameraheight, 0);
        mainCamera.transform.parent = transform;

        xRotation = 0;
    }

    private void Update()
    {
        if (canTurn)
        {
            RotateCamera();
            RotatePlayer();
        }
    }

    void RotatePlayer()
    {
        mouseX = playerInputActions.Player.MouseX.ReadValue<float>() * mouseSensitivity * Time.deltaTime;
        mouseY = playerInputActions.Player.MouseY.ReadValue<float>() * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
    }

    void RotateCamera()
    {
        xRotation -= mouseY;

        // Limit mouse
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
