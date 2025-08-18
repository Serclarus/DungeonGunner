using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[DisallowMultipleComponent]
public class AnimatePlayer : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player= GetComponent<Player>();
    }

    private void OnEnable()
    {
        player.movementByVelocityEvent.OnMovementByVelocity += MovementByVelocityEvent_OnMovementByVelocity;

        player.idleEvent.OnIdle += IdleEvent_OnIdle;

        player.aimWeaponEvent.OnWeaponAim += AimWeaponEvent_OnWeaponAim;
    }

    private void OnDisable()
    {
        player.movementByVelocityEvent.OnMovementByVelocity -= MovementByVelocityEvent_OnMovementByVelocity;

        player.idleEvent.OnIdle -= IdleEvent_OnIdle;

        player.aimWeaponEvent.OnWeaponAim -= AimWeaponEvent_OnWeaponAim;
    }

    private void MovementByVelocityEvent_OnMovementByVelocity(MovementByVelocityEvent movementByVelocityEvent, MovementByVelocityArgs movementByVelocityArgs)
    {
        SetMovementAnimationParamaters();
    }

    private void AimWeaponEvent_OnWeaponAim(AimWeaponEvent aimWeaponEvent, AimWeaponEventArgs aimWeaponEventArgs)
    {
        InitializeAnimationParameters();
        SetAimWeaponAnimationParameters(aimWeaponEventArgs.aimDirection);
    }

    private void IdleEvent_OnIdle(IdleEvent idleEvent)
    {
        SetIdleAnimationParamaters();
    }

    private void InitializeAnimationParameters()
    {
        player.animator.SetBool(Settings.aimUp, false);
        player.animator.SetBool(Settings.aimUpRight, false);
        player.animator.SetBool(Settings.aimUpLeft, false);
        player.animator.SetBool(Settings.aimRight, false);
        player.animator.SetBool(Settings.aimLeft, false);
        player.animator.SetBool(Settings.aimDown, false);

    }

    private void SetMovementAnimationParamaters()
    {
        player.animator.SetBool(Settings.isIdle, false);
        player.animator.SetBool(Settings.isMoving, true);
    }

    private void SetIdleAnimationParamaters()
    {
        player.animator.SetBool(Settings.isIdle, true);
        player.animator.SetBool(Settings.isMoving, false);
    }

    private void SetAimWeaponAnimationParameters(AimDirection aimDirection)
    {
        // Set aim direction
        switch (aimDirection)
        {
            case AimDirection.Up:
                player.animator.SetBool(Settings.aimUp, true);
                break;

            case AimDirection.UpRight:
                player.animator.SetBool(Settings.aimUpRight, true);
                break;

            case AimDirection.UpLeft:
                player.animator.SetBool(Settings.aimUpLeft, true);
                break;

            case AimDirection.Right:
                player.animator.SetBool(Settings.aimRight, true);
                break;

            case AimDirection.Left:
                player.animator.SetBool(Settings.aimLeft, true);
                break;

            case AimDirection.Down:
                player.animator.SetBool(Settings.aimDown, true);
                break;
        }
    }


}
