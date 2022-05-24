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

    private void Start()
    {
        bossController = GetComponentInParent<BossController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Weapon")
        {
            if (bossController.IsStunnedTimer.TimerOver == true)
            {
                bossController.HitCounter = 0;
                bossController.IsStunnedTimer.StartTimer(10);    // TODO: Balancing
            }
            else
            {
                if (bossController.Player.GetCurrentWeaponObject().GetCurrentAttackType() == "heavy" || bossController.Player.ComboSuccess() == true || bossController.Player.GetCurrentWeaponObject().GetWeaponWeight() == 15)
                {
                    bossController.HitCounter += Random.Range(2, 5);
                }
                else if (bossController.Player.GetCurrentWeaponObject().GetWeaponWeight() == 12)
                {
                    bossController.HitCounter += 2;
                }
                else
                {
                    bossController.HitCounter++;
                }
            }

            if (bossController.HitCounter >= bossController.StunCount && bossController.IsStunnedTimer.TimerOver == false)
            {
                bossController.IsStunned = true;
                bossController.IsStunnedTimer.StartTimer(5);    // TODO: Balancing
            }

            float damage = bossController.Player.GetCurrentWeaponObject().GetDamage();

            if (bossController.IsStunned == false)
            {
                if (bossController.IsFlying == true)
                {
                    if(bossController.Animator.GetCurrentAnimatorStateInfo(0).IsName("Fly Got Hit"))
                    {
                        bossController.Animator.SetTrigger("Hit 3");
                    }
                }
                else if (position == PositionEnum.LEFT)
                {
                    if (bossController.Animator.GetCurrentAnimatorStateInfo(0).IsName("Got Hit 2"))
                    {
                        bossController.Animator.SetTrigger("Hit 2");
                    }
                }
                else if (position == PositionEnum.RIGHT)
                {
                    if (bossController.Animator.GetCurrentAnimatorStateInfo(0).IsName("Got Hit 1"))
                    {
                        bossController.Animator.SetTrigger("Hit 1");
                    }
                }
                else
                {
                    int random = Random.Range(0, 100);
                    if (random % 2 == 0)
                    {
                        bossController.Animator.SetTrigger("Hit 1");
                    }
                    else
                    {
                        bossController.Animator.SetTrigger("Hit 2");
                    }
                }
            }

            bossController.TakeDamage(damage + crit);

        }
    }
        
}
