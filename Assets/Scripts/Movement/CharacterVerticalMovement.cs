using UnityEngine;

public class CharacterVerticalMovement : MonoBehaviour
{
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] private JumpEvent jumpEvent;
    [SerializeField] private float groundCheckDistance = 0.25f;

    [HideInInspector] private CharacterController characterController;
    private float verticalSpeed;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void OnEnable()
    {
        if (jumpEvent != null)
        {
            jumpEvent.OnJump += HandleJump;
        }
    }

    void OnDisable()
    {
        if (jumpEvent != null)
        {
            jumpEvent.OnJump -= HandleJump;
        }
    }

    private void HandleJump(JumpEvent jumpEvent)
    {
        Jump();
    }

    public void Jump()
    {
        if (IsPlayerGrounded())
        {
            verticalSpeed = jumpForce * -20f * gravity * Time.fixedDeltaTime;
        }
    }

    void FixedUpdate()
    {
        if (!IsPlayerGrounded())
        {
            verticalSpeed += gravity * 10f * Time.fixedDeltaTime;
        }
        else if (verticalSpeed < 0)
        {
            verticalSpeed = 0;
        }
    }

    public bool IsPlayerGrounded()
    {
        RaycastHit hit;
        float distance = characterController.height / 2 + groundCheckDistance;
        Vector3 direction = Vector3.down;

        return Physics.Raycast(transform.position, direction, out hit, distance);
    }

    public Vector3 VerticalMovement
    {
        get { return new Vector3(0, verticalSpeed, 0); }
    }
}
