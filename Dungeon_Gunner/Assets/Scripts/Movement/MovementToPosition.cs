using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(MovementToPositionEvent))]
[DisallowMultipleComponent]
public class MovementToPosition : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private MovementToPositionEvent movementToPositionEvent;

    private void Awake()
    {
        rigidbody2D= GetComponent<Rigidbody2D>();
        movementToPositionEvent= GetComponent<MovementToPositionEvent>();
    }

    private void OnEnable()
    {
        movementToPositionEvent.OnMovementToPosition += MovementToPositionEvent_OnMovementToPosition;
    }

    private void OnDisable()
    {
        movementToPositionEvent.OnMovementToPosition -= MovementToPositionEvent_OnMovementToPosition;
    }

    private void MovementToPositionEvent_OnMovementToPosition(MovementToPositionEvent arg1, MovementToPositionArgs arg2)
    {
        MoveRigidBody(arg2.currentPosition, arg2.movePosition, arg2.moveSpeed);
    }

    private void MoveRigidBody(Vector3 currentPosition, Vector3 movePosition, float moveSpeed)
    {
        Vector2 direction = Vector3.Normalize(movePosition- currentPosition);

        rigidbody2D.MovePosition(rigidbody2D.position + (direction * moveSpeed * Time.fixedDeltaTime));
    }
}
