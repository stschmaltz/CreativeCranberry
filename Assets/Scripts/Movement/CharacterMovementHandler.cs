using UnityEngine;

public class CharacterMovementHandler : MonoBehaviour
{
    private CharacterController characterController;
    private CharacterHorizontalMovement characterHorizontalMovement;
    private CharacterVerticalMovement characterVerticalMovement;

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
    }
}
