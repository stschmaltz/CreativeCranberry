using UnityEngine;
using UnityEngine.AI;

[DisallowMultipleComponent]
public class AnimationHandler : MonoBehaviour
{
    private Player player;
    private MovementEvent movementEvent;
    private Animator animator;
    private void Awake()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        player.movementEvent.OnMovement += MovementEvent_AnimateMovement;
    }

    private void OnDisable()
    {
        player.movementEvent.OnMovement -= MovementEvent_AnimateMovement;
    }

    private void MovementEvent_AnimateMovement(MovementEvent movementEvent, MovementEventArgs args)
    {
        Vector3 globalVelocity = args.moveDirection * args.moveSpeed;
        Vector3 localVelocity = transform.InverseTransformDirection(globalVelocity);

        float speed = localVelocity.magnitude;

        animator.SetFloat("ForwardSpeed", speed);
    }

}
