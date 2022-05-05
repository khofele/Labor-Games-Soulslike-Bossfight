using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharDamagable : MonoBehaviour
{
    [SerializeField] private float crit = 0; //crit is set for every collider on itself
    private CharController charController = null;
    private AttackManager attackManager = null;

    private float dotPercentage = 0.4f; //percentage of damage value that gives damage over time
    private float dotDelay = 30f; //delay for damage dealing over time
    private float dotValuePercentage = 0.1f; //percentage of dot that is dealt at once

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponentInParent<CharController>();
        attackManager = charController.GetAttackManager();
    }


    //called when hit
    private void OnCollisionEnter(Collision collision)
    {
        if (!charController.GetComponentInParent<Animator>().GetBool("Roll"))
        {
            //deal damage according to attack
            float damage = attackManager.CurrentAttack.Damage;

            //call method to calculate damage
            charController.TakeDamage(damage + crit);

            //if special attack with fire, poison or magic - call method to deal damage over time
            if(attackManager.CurrentAttack == attackManager.AttackFlyBreatheFire || attackManager.CurrentAttack == attackManager.AttackFlyBreatheFirePoison || attackManager.CurrentAttack == attackManager.AttackFlyBreatheFireMagic)
            {
                float dot = damage * dotPercentage;
                float valueEveryTime = dot * dotValuePercentage;    //damage value that is dealt every time of damage over time
                charController.StartCoroutine(charController.DamageOverTime(dot, dotDelay, valueEveryTime));
            }
        }
    }

}
