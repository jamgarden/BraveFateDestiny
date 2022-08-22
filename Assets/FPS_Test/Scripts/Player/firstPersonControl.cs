using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class firstPersonControl : MonoBehaviour
{
    private CharacterController cc;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;

    [Header("Player's Features")]
    [SerializeField] public bool canMove = true;
    [SerializeField] private float walkingSpeed = 3.2f;
    [SerializeField] private float runningSpeed = 4.6f;
    [Space]
    [SerializeField] private float jumpingForce = 1.4f;
    [SerializeField] public bool canJump = true;

    private float inputX, inputZ;
    private float movingSpeed;
    private Vector3 moveDirection;
    private Vector3 velocity;

    //Crouch variables
    private float orginalHeight;
    private float wantedHeight;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
    }


    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;

        //mouseLook = gameObject.GetComponent<MouseLook>();
        cc = gameObject.GetComponent<CharacterController>();
        playerInput = gameObject.GetComponent<PlayerInput>();
        // Debug.Log(playerInput);
        cc.center = new Vector3(0, 1, 0);
        cc.height = 2;
        cc.radius = 0.3f;
        cc.stepOffset = 0.3f;

        //movingSpeed = walkSpeed;

        orginalHeight = cc.height;
        wantedHeight = orginalHeight / 2;
    }

    public void LockItUp()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        if (canMove)
        {
            Inputs();
        }

        AdjustSpeed();
        Move();
    }

    void Inputs()
    {
        // Debug.Log(inputX +" " + inputZ);
        // playerInput.actions.
        inputX = playerInputActions.Player.Movement.ReadValue<Vector2>().x;
        inputZ = playerInputActions.Player.Movement.ReadValue<Vector2>().y;
    }

    void AdjustSpeed()
    {
       if(playerInputActions.Player.Run.IsPressed() && movingSpeed != runningSpeed)
        {
            movingSpeed = runningSpeed;
        }

       else
        {
            movingSpeed = walkingSpeed;
        }
    }

    void Move()
    {
        moveDirection = (transform.right * inputX) + (transform.forward * inputZ);
        cc.Move(moveDirection.normalized * movingSpeed * Time.deltaTime);

        velocity.y -= 9.81f * Time.deltaTime; //Gravity
        cc.Move(velocity * Time.deltaTime);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && canJump)
        {
            if(isGrounded) velocity.y = Mathf.Sqrt(jumpingForce * -2f * Physics.gravity.y);
        }
        //isJumping = true;
        //coolDownJumping = 0.2f;
    }

    private bool isGrounded
    {
        get
        {
            return
                Physics.Raycast(transform.position + new Vector3(0, 0.25f, 0), Vector3.down, 0.5f);
        }
    }
}
