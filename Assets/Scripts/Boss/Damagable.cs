using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PositionEnum
{
    FRONT, LEFT, RIGHT, BACK
}

public class Damagable : MonoBehaviour
{
    [SerializeField] private float crit = 0;
    [SerializeField] private PositionEnum position;
    private BossController bossController = null;

    private void OnCollisionEnter(Collision collision)
    {
        // TODO: GetSchaden von Spielerwaffe
        
        if(bossController.IsFlying == true)
        {
            bossController.Animator.SetTrigger(""); // TODO: Animations Task FlyHit
        }
        else if(position == PositionEnum.LEFT)
        {
            bossController.Animator.SetTrigger(""); // TODO: Animations Task Hit2
        }
        else if (position == PositionEnum.RIGHT)
        {
            bossController.Animator.SetTrigger(""); // TODO: Animations Task Hit1
        }
        else
        {
            int random = Random.Range(0, 100);
            if(random%2 == 0)
            {
                bossController.Animator.SetTrigger(""); // TODO: Animations Task
            }
            else
            {
                bossController.Animator.SetTrigger(""); // TODO: Animations Task
            }
        }

        //bossController.TakeDamage(waffenSchaden + crit);

    }
}
