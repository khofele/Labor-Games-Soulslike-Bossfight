using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stateMachine
{
    //basic state class to enter and exit a state
    public class BaseState : StateMachineBehaviour
    {
        //access to the character scripts
        protected CharacterMovement charMovement;
        protected CharController charController;

        protected float neededStamina = 0f; //stamina needed to perform action

        //basic movement
        protected float targetAngle = 0f; //camera target angle - where the camera shall be pointing at
        protected float angle = 0f; //using targetAngle to get a smoother transition to new angle
        protected float smoothTurnTime = 0.1f; //time so the character turns around smoothly
        protected float smoothTurnVelocity = 0f; //velocity so the character turns around smoothly

        protected CharacterMovement GetCharacterMovement(Animator animator)
        {
            //if it has not yet been set
            if (charMovement == null)
            {
                charMovement = animator.GetComponentInParent<CharacterMovement>();
            }
            return charMovement;
        }    

        protected CharController GetCharController(Animator animator)
        {
            //if it has not yet been set
            if(charController == null)
            {
                charController = animator.GetComponentInParent<CharController>();
            }
            return charController;
        }
    }

}
