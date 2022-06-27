using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stateMachine
{
    public class WalkState : BaseState
    {
        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            //camera and player rotation
            targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + GetCharacterMovement(animator).GetCam().eulerAngles.y; //angle to point character at
            angle = Mathf.SmoothDampAngle(GetCharacterMovement(animator).transform.eulerAngles.y, targetAngle, ref smoothTurnVelocity, smoothTurnTime); //smoother transition to target angle
            GetCharacterMovement(animator).transform.rotation = Quaternion.Euler(0f, angle, 0f); //set character rotation

            //move character in chosen direction
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            GetCharacterMovement(animator).GetController().Move(moveDir.normalized * GetCharController(animator).GetMovementSpeed() * Time.deltaTime);
        }
    }

}
