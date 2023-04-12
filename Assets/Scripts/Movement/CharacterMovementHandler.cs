using UnityEngine;

public class CharacterMovementHandler : MonoBehaviour
{
    private CharacterController characterController;
    private CharacterHorizontalMovement characterHorizontalMovement;
    private CharacterVerticalMovement characterVerticalMovement;
    [SerializeField] private float rotationSpeed = 5f;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        characterHorizontalMovement = GetComponent<CharacterHorizontalMovement>();
        characterVerticalMovement = GetComponent<CharacterVerticalMovement>();
    }

    void Update()
    {
        Vector3 combinedMovement = characterHorizontalMovement.HorizontalMovement + characterVerticalMovement.VerticalMovement;
        characterController.Move(combinedMovement * Time.deltaTime);

        // Rotate the player towards the movement direction
        if (characterHorizontalMovement.HorizontalMovement.magnitude > 0.1f)
        {
            RotatePlayer(characterHorizontalMovement.HorizontalMovement);
        }
    }

    private void RotatePlayer(Vector3 moveDirection)
    {
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
