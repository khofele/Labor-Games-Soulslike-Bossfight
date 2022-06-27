using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stateMachine
{
    public class RunState : BaseState
    {
        //value to run faster than walking speed
        private float valueFaster = 1.5f;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //needed stamina for action per frame
            neededStamina = 0.1f;
            GetCharController(animator).SetRegStamina(false); //no stamina reg during running
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                GetCharController(animator).UseStamina(neededStamina);


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
            else
            {
                animator.SetBool("Run", false);
            }

        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (animator.GetBool("Run"))
            {
                animator.SetBool("Run", false);
            }

            GetCharController(animator).SetRegStamina(true); //regenerate stamina again
        }
    }

}
