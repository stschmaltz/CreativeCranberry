using UnityEngine;
using UnityEngine.AI;



[RequireComponent(typeof(MovementEvent))]
[RequireComponent(typeof(Animator))]
[DisallowMultipleComponent]
public class AnimationHandler : MonoBehaviour
{
    private Player player;
    private MovementEvent movementEvent;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        movementEvent = GetComponent<MovementEvent>();
    }

    private void OnEnable()
    {
        movementEvent.OnMovement += MovementEvent_AnimateMovement;
    }

    private void OnDisable()
    {
        movementEvent.OnMovement -= MovementEvent_AnimateMovement;
    }

    private void MovementEvent_AnimateMovement(MovementEvent movementEvent, MovementEventArgs args)
    {
        Vector3 globalVelocity = args.moveDirection * args.moveSpeed;
        Vector3 localVelocity = transform.InverseTransformDirection(globalVelocity);

        float speed = localVelocity.magnitude;

        animator.SetFloat("ForwardSpeed", speed);
    }

}
