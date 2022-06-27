using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stateMachine
{
    public class RollState : BaseState
    {
        //value to roll faster than walking speed
        private float valueFaster = 2f;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //sound
            GetAudioPlayer(animator).PlayRoll();

            //use neededStamina for action
            neededStamina = GetStaminaManager(animator).NeededStaminaRoll;
            GetCharController(animator).UseStamina(neededStamina);
            GetCharController(animator).SetRegStamina(false); //no stamina reg during skill
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //determine roll direction
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            //camera and player rotation
            targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + GetCharacterMovement(animator).GetCam().eulerAngles.y; //angle to point character at
            angle = Mathf.SmoothDampAngle(GetCharacterMovement(animator).transform.eulerAngles.y, targetAngle, ref smoothTurnVelocity, smoothTurnTime); //smoother transition to target angle
            GetCharacterMovement(animator).transform.rotation = Quaternion.Euler(0f, angle, 0f); //set character rotation

            //move character in chosen direction
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            GetCharacterMovement(animator).GetController().Move(moveDir.normalized * (GetCharController(animator).GetMovementSpeed() * valueFaster) * Time.deltaTime);

        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("Roll", false);
            GetCharController(animator).SetRegStamina(true); //regenerate stamina again
        }
    }

}
